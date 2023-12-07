

string FilePath = @"C:\csharp\rekurzija.txt";


List<string> Lines = File.ReadAllLines(FilePath).ToList();
List<Podaci> Data = new List<Podaci>();


foreach (var line in Lines)
{
    string[] entries = line.Split(',');
    Podaci MnogoPodataka = new Podaci();
    MnogoPodataka.Child = int.Parse(entries[0]);
    MnogoPodataka.Text = entries[1];
    MnogoPodataka.ParentId = int.Parse(entries[2]);
    
    Data.Add(MnogoPodataka);
}


int p = Data.Count - 1;

Rek(Data,0, 0,p);

static void Rek(List<Podaci> Data ,int parent, int level,int p)
{    
    string crtatica = new string('-', level);
    for (int i = 0; i < Data[p].Child; i++)
    {
       if (Data[i].ParentId == parent)
        {
            Console.WriteLine(crtatica + Data[i].Text);
            Rek(Data, Data[i].Child, level + 1, p);
        }
    }
}
class Podaci
{
    public int Child { get; set; }
    public string Text { get; set; }
    public int ParentId { get; set; }
}

//Rek(MnogoPoadata.Child, MnogoPoadata.ParentId, MnogoPoadata.Text, 0, 0);

//static void Rek(MnogoPoadata.Child, int[] parentId, string[] text, int parent, int level)
//{
//    string crtatica = new string('-', level);
//    for (int i = 0; i < Child.Length; i++)
//    {
//        if (parentId[i] == parent)
//        {
//            Console.WriteLine(crtatica + text[i]);
//            Rek(Child, parentId, text, Child[i], level + 1);
//        }
//    }
//}

