namespace Riid.DTO.Loan
{
    public class UserLoanDTO
    {
        public long Id { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Book_Name { get; set; }
        public string Book_Image { get; set; }
    }
}
