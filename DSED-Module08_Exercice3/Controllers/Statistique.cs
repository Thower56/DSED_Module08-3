namespace DSED_Module08_Exercice3.Controllers
{
    public static class Statistique
    {
        public static List<Appel> GetAppels() => m_Appels;
        public static Appel GetByIdAppel(int p_id) => m_Appels.SingleOrDefault(appel => appel.Id == p_id);
        public static void AddAppel(Appel p_Appel)
        {
            if (p_Appel is null)
            {
                throw new ArgumentNullException(nameof(p_Appel));
            }
            if(p_Appel.IdAgent <= 0) 
            {
                throw new ArgumentException(nameof(p_Appel));
            }
            m_Appels.Add(p_Appel);
        }

        private static List<Appel> m_Appels = new List<Appel>()
            {
                new Appel()
                {
                    Id = 1,
                    IdAgent = 1,
                    DebutAppel = new DateTime(2024, 1, 1, 8, 0, 0),
                    FinAppel = new DateTime(2024, 1, 1, 8, 10, 0)
                },
                new Appel()
                {
                    Id = 2,
                    IdAgent = 2,
                    DebutAppel = new DateTime(2024, 1, 1, 8, 0, 0),
                    FinAppel = new DateTime(2024, 1, 1, 8, 10, 0)
                },
                new Appel()
                {
                    Id = 3,
                    IdAgent = 3,
                    DebutAppel = new DateTime(2024, 1, 1, 8, 0, 0),
                    FinAppel = new DateTime(2024, 1, 1, 8, 10, 0)
                },
                new Appel()
                {
                    Id = 4,
                    IdAgent = 4,
                    DebutAppel = new DateTime(2024, 1, 1, 8, 0, 0),
                    FinAppel = new DateTime(2024, 1, 1, 8, 10, 0)
                },
            };
        public static int NombreAppels => m_Appels.Count;
        public static double DureeMoyenneAppels => m_Appels.Average(a => a.DureeAppel);
        public static int DernierId => m_Appels.Last().Id;
        public static int NombreAgent => m_Appels.DistinctBy(appel => appel.IdAgent).Count();


    }
}
