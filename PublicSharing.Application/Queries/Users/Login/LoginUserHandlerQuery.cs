using MediatR;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Domain.UserAggregate;

namespace PublicSharing.Application.Queries.Users.Login
{
    public class LoginUserHandlerQuery(IUserRepository userRepository, IJwtService jwtService) : IRequestHandler<LoginUserQuery, LoginUserResponseQuery>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;


        public async Task<LoginUserResponseQuery> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (user is null)
                throw new UserNotFoundWithEmailException(request.Email);

            if (user.Password != request.Password)
                throw new PasswordIncorrectException();

            var token = _jwtService.GenerateToken(user);

            return new LoginUserResponseQuery(token);


           
        }
    }
}
