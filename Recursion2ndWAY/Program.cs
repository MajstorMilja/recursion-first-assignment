// See https://aka.ms/new-console-template for more information

string rootpath = @"C:\Users\milja\OneDrive\Desktop\programiranje\Sve u jednom folderu\Sve u jednom folderu\rekurzija final\recursion.txt";
string[] proba = File.ReadAllLines(rootpath).ToArray();

int[] Child = new int[proba.Length], parentId = new int[proba.Length];
string[] text = new string[proba.Length], stah = new string[proba.Length * 3];

int brojacJedan = 0, brojacDva = 0, brojacTri = 0;

string textFile = "";
bool boolJedan = true;

for (int i = 0; i < proba.Length; i++)
{
    textFile += proba[i];
}

stah = textFile.Split(',', ' ');

for (int i = 1; i < stah.Length + 1; i++)
{
    if (i % 3 == 0 && i != 0)
    {
        parentId[brojacJedan] = int.Parse(stah[i - 1]);
        brojacJedan++;
    }
    else if (boolJedan && brojacDva != 7)
    {
        Child[brojacDva] = int.Parse(stah[i - 1]);
        brojacDva++;
        boolJedan = false;
    }
    else if (boolJedan != true)
    {
        text[brojacTri] = stah[i - 1];
        brojacTri++;
        boolJedan = true;
    }
}

WildCard(Child, parentId, text, 0, 0);


static void WildCard(int[] Child, int[] parentId, string[] text, int parent, int level)
{
    string crta = new string('-', level);
    for (int i = 0; i < Child.Length; i++)
    {
        if (parentId[i] == parent)
        {
            Console.WriteLine(crta + text[i]);
            WildCard(Child, parentId, text, Child[i], level + 1);
        }
    }
}