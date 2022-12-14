namespace EverLight.DTOs
{
    public class Order
    {
        public int Id { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? ErrorType { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee? DoneBy { get; set; }  // orderből elhérhető direktben az emplees 
    }
}