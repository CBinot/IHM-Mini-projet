using System.Data;

namespace Mini_projet.DAO
{
    class Categorie : DAO
    {
        private int codeCat;
        private string libelleCat;

        public Categorie() : base()
        {
            sqlSelect = "SELECT * " +
                        "FROM categorie;";

            sqlInsert = "INSERT INTO categorie (codeCat, libelleCat) " +
                        "VALUES (@codeCat, @libelleCat);";

            sqlUpdate = "UPDATE categorie " +
                        "SET libelleCat = @libelleCat " +
                        "WHERE codeCat = @codeCat;";

            sqlDelete = "DELETE FROM categorie " +
                        "WHERE codeCat = @codeCat;";

            sqlParams.Add(new DAOParam("@codeCat", SqlDbType.Int, 1, "codeCat"));
            sqlParams.Add(new DAOParam("@libelleCat", SqlDbType.NVarChar, 50, "libelleCat"));

            Initialiser();
        }
    }
}
