namespace Model.Models
{
    public class Account_Game
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public Account Account { get; set; }
        public int Count { get; set; }
        public int Quantity { get; set; }
    }
}
