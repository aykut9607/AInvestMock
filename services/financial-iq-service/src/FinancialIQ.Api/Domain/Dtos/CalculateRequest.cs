   namespace FinancialIQ.Api.Domain.Dtos;
  
    public class CalculateRequest
    {
        public string UserId { get; set; } = string.Empty;
        public decimal CashReserve { get; set; }
        public decimal MonthlyExpenses { get; set; }
    }