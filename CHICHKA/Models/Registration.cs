namespace CHICHKA.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string SubUserName { get; set; }
        public string SubUserPassword { get; set; }
        public string CardNumber { get; set; }
        public int YearExpire { get; set; }
        public int MonthExpire { get; set; }
        public string CW2 { get; set; }
    }
}

/*
UserName
UserPassword 
SubUserName 
SubUserPassword 
CardNumber 
YearExpire 
MonthExpire 
CW2
*/
