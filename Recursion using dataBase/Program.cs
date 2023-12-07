using System.Data.SqlClient;


List<Podaci> Data = new List<Podaci>();

SqlConnection connection = new SqlConnection();
   
using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnPodaci))
{
    using (SqlCommand komanda = new SqlCommand("SelectAll", konekcija))
    {
        konekcija.Open();
        SqlDataReader dr = komanda.ExecuteReader();
        while (dr.Read())
        {
            Podaci p1 = new Podaci
            {
                ID = dr.GetInt32(0),           
                Tekst = dr.GetString(1),
                ParentId = dr.GetInt32(2),
            };      
            Data.Add(p1);
        }
        konekcija.Close();
    }
}

int p = Data.Count - 1;

Rek(Data, 0, 0, p);

static void Rek(List<Podaci> Data, int parent, int level, int p)
{
    string crtatica = new string('-', level);
    for (int i = 0; i < Data[p].ID; i++)
    {
        if (Data[i].ParentId == parent)
        {
            Console.WriteLine(crtatica + Data[i].Tekst);
            Rek(Data, Data[i].ID, level + 1, p);
        }
    }
}

class Podaci{
    public int ID { get; set; }
    public string Tekst { get; set; }
    public int ParentId { get; set; }
}
static class Konekcija
{
    public static string cnnPodaci = @"Data Source=DESKTOP-C70UD3Q\SQLEXPRESS;Initial Catalog=Vezba;Integrated Security=true";
}