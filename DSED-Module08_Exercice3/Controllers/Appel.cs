namespace DSED_Module08_Exercice3.Controllers
{
    public class Appel
    {
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public DateTime DebutAppel { get; set; }
        public DateTime FinAppel { get; set; }
        public double DureeAppel => FinAppel > DebutAppel  ? (double)(FinAppel - DebutAppel).TotalMinutes : 0 ;
           
    }
}
