namespace Riid.DTO.Loan
{
    public class LoanDTOBookInfo
    {
        public long Id { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Book_Name { get; set; }
        public string Book_Image { get; set; }
        public string Book_Author {  get; set; }
        public string Book_Category { get; set; }
        public string Book_Description { get; set; }
    }
}
