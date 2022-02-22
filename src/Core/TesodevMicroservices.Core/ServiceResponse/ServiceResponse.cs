namespace TesodevMicroservices.Core.ServiceResponse
{
    public class ServiceResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }


        public ServiceResponse(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Data = default(T);
        }


        public ServiceResponse(bool isSuccess, string message, T data):this(isSuccess, message)
        {
            this.Data = data;
        }


        public ServiceResponse()
        {
                
        }
    }
}