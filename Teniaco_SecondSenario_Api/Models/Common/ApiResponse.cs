namespace Teniaco_SecondSenario_Api.Models.Common
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int? TotalCount { get; set; }
        public bool IsSuccessFull { get; set; }
        public T Data { get; set; }
        public string Status { get; set; }
    }
}
