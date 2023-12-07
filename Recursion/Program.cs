
string filePath = @"C:\Users\milja\OneDrive\Desktop\programiranje\Sve u jednom folderu\Sve u jednom folderu\recursion-first-assignment\recursion.txt";
//change path to fix your root
string[] test = File.ReadAllLines(filePath);
string[] string202 = new string[test.Length * 3];
int[]    Child = new int[test.Length];
int[]    parentId = new int[test.Length];
string[] text = new string[test.Length];
string[] strah = new string[test.Length * 3];
int y = 0;
foreach (var line in test)
{
    string202 = line.Split(',');
    Child[y] = int.Parse(string202[0]);
    text[y] = string202[1];
    parentId[y] = int.Parse(string202[2]);
    y++;
}
Rek(Child, parentId, text, 0, 0);

static void Rek(int[] Child, int[] parentId, string[] text, int parent, int level)
{
    string crtatica = new string('-', level);
    for (int i = 0; i < Child.Length; i++)
    {
        if (parentId[i] == parent)
        {
            Console.WriteLine(crtatica + text[i]);
            Rek(Child, parentId, text, Child[i], level + 1);
        }
    }
}