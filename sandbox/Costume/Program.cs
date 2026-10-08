namespace Costume;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Costume> myCostumes = new List<Costume>();
        Costume detective = new Costume();
        detective._headwear = "fedora";
        detective._upperGarment = "trench coat";
        detective._lowerGarment = "slacks";
        detective._footwear = "dress shoes";
        detective._accessories = "fingerprint kit";
        myCostumes.Add(detective);

        Costume nurse = new Costume();
        nurse._headwear = "hairnet";
        nurse._upperGarment = "scrubs";
        nurse._lowerGarment = "scrubs";
        nurse._footwear = "orthopedic shoes";
        nurse._accessories = "mask";
        myCostumes.Add(nurse);

    }
}
