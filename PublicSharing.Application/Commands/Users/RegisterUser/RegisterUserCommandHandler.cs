using MediatR;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Domain.DomainItems;
using PublicSharing.Domain.UserAggregate;

namespace PublicSharing.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtService jwtService, IEventStore eventStore) : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IJwtService _jwtService = jwtService;
        private readonly IEventStore _eventStore=eventStore;
        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsExistsWithEmailAsync(request.Email, cancellationToken))
                throw new EmailAlreadyExistsException(request.Email);

            User user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);
            await _eventStore.SaveEventsAsync(user.Id.Value.ToString(), user.Events);
            _userRepository.Add(user);
            string token = _jwtService.GenerateToken(user);

            await _unitOfWork.CommitAsync(cancellationToken);
            user.ClearEvents();

            return new RegisterUserCommandResponse(token);

        }
    }
}
