namespace DAL.Entities
{
    public class FoodStuffs
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Protein100Gr { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }

    }
}