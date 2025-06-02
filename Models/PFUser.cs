namespace ProjetoInterdisciplinar.Models
{
    public class PFUser : AppUsers
    {
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Sex { get; set; }
    }
}
