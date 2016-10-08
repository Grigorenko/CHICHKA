namespace Model.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; }
        public Account Account { get; set; }
        public byte[] Image { get; set; }
    }
}
