public class Dice
{
    int luck = 0; //gotta think about a way to add this to the upperFaceValue

    public int sideCount = 1;
    public int upperFaceValue = 1;

    public List<DiceModifier> modifierList = new List<DiceModifier>();

    public Dice(int newSideCount)
    {
        sideCount = newSideCount;
    }

    public void roll()
    {
        upperFaceValue = new Random().Next(1, sideCount);
        processModifiers();
    }

    public void processModifiers()
    {
        foreach (DiceModifier m in modifierList)
        {
            switch (m)
            {
                case DiceModifier.BabySteps:
                    if (upperFaceValue < sideCount/2)
                    {
                        Console.Write("Baby Steps triggered! ");
                        upperFaceValue += 1;
                    }
                    break;

                case DiceModifier.MiddleOfTheRoad:
                    if (upperFaceValue == sideCount/2)
                    {
                        Console.Write("Middle Of The Road triggered! ");
                        upperFaceValue *= 2;
                    }
                    break;
                
                case DiceModifier.HydrogenBomb:
                    if (upperFaceValue < sideCount/2)
                    {
                        Console.Write("Hydrogen Bomb triggered! ");
                        upperFaceValue = 0;
                    }
                    break;
            }
        }
        Console.WriteLine();
    }
    
    public override string ToString()
    {
        string n = $"sides: {sideCount} - luck: {luck} - active modifiers: ";
        
        if (modifierList.Count == 0)
        {
            n += "None";
        }
        else
        {
            foreach (DiceModifier m in modifierList)
            {
                n += m + " - ";
            }
        }
        return n;
    }

}
