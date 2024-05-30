namespace Assignment_For_Carseer.Domain
{
    public class Response<T>
    {
        public DateTime ResponseTime = DateTime.UtcNow;
        public string ErrorMeassage { get; set; }
        public bool IsSuccess
        {
            get
            {
                return string.IsNullOrWhiteSpace(ErrorMeassage);
            }
        }

        public T Data { get; set; }

        public Response(T data) => Data = data;
        public Response(string errorMeassage) => ErrorMeassage = errorMeassage;

        public static Response<T> Success(T data) => new Response<T>(data);
        public static Response<T> Error(string errorMessage) => new Response<T>(errorMessage);
    }
}
