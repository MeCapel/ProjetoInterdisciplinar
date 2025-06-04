using Microsoft.EntityFrameworkCore;
using ProjetoInterdisciplinar.Models;

namespace ProjetoInterdisciplinar.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        [Precision(8,2)]
        //public string Descricao { get; set; }
        public decimal? Salario { get; set; }
        public DateTime Post { get; set; }
        //public bool Able { get; set; }

        public string? PJId { get; set; }
        public PJUser PJ { get; set; }


        public Vaga()
        {
            Post = DateTime.Now;
        }
    }
}
