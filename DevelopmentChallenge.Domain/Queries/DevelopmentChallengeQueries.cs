

namespace DevelopmentChallenge.Domain.Queries
{
    public class DevelopmentChallengeQueries
    {
        public static string GetAllMDR()
        {
            return "SELECT Id, Adquirente FROM MDRs";
        }

        public static string GetAllTaxas()
        {
            return "SELECT Bandeira, Credito, Debito, MDRId FROM Taxas";
        }

        public static string searchInformationCalculateValue(string tipo)
        {
            if (tipo == "Credito")
            {
                return @"SELECT Credito
                            FROM Taxas tx
                            JOIN MDRs mdr ON tx.MDRId = mdr.Id
                            WHERE tx.Bandeira = @Bandeira
                            AND mdr.Adquirente = @Adquirente";
            }
            else
            {
                return @"SELECT Debito
                            FROM Taxas tx
                            JOIN MDRs mdr ON tx.MDRId = mdr.Id
                            WHERE tx.Bandeira = @Bandeira
                            AND mdr.Adquirente = @Adquirente";
            }
        }
    }
}