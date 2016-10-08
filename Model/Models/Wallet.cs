namespace Model.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int YearExpire { get; set; }
        public int MonthExpire { get; set; }
        public string CW2 { get; set; }
    }
}
