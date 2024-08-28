using Newtonsoft.Json;

namespace PublicSharing.Api.Model
{
    public class ApiResponse
    {
        public ApiResponse()
        {
        }

        public ApiResponse(string message)
        {
            Succeeded = false;
            Message = message;

        }
        public int Status { get; set; } = 200!;
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public T Data { get; set; }

    }
}



