namespace Model.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public User User { get; set; }
        public Wallet Wallet { get; set; }
        //public Game Game { get; set; }
    }
}
