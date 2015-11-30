using System;

namespace DAL.Entities
{
    public class DailyIntake
    {
        public int Id { get; set; }
        public int SamletProtein { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}