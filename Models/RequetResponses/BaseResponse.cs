namespace Sampas_Mobil_Etkinlik.Models.RequetResponses
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        public int Sonuc { get; private set; }

        protected BaseResponse(T data)
        {
            Success = true;
            Message = string.Empty;
            Data = data;
        }

        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }

        protected BaseResponse(string message, int sonuc)
        {
            Success = false;
            Message = message;
            Sonuc = sonuc;
        }

        protected BaseResponse(bool success)
        {
            Success = success;
        }


    }
}
