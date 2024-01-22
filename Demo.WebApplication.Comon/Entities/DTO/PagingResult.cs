namespace B1.Demo.WebApplication.Common.Entities.DTO
{
    public class PagingResult
    {
        public List<Employee> Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi t/m điều kiện
        /// </summary>
        public int TotalReccord { get; set; }
    }
}
