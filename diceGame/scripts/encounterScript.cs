public class Encounter
{
    public string name = "blank";

    public int lowerThreshold = 2;
    public int upperThreshold = 12;

    public List<DiceModifier> modifierList = new List<DiceModifier>();

    public Encounter(string newName, 
                     int newLowerThreshold, int newUpperThreshold, 
                     List<DiceModifier> newModifierList)
    {
        name = newName;
        lowerThreshold = newLowerThreshold;
        upperThreshold = newUpperThreshold;
        modifierList = newModifierList;
    }

    public void addNegativeModifiers(Hand h)
    {
        foreach(Dice d in h.dices)
        {
            foreach (DiceModifier m in modifierList)
            {
                d.modifierList.Add(m);
            }
        }        
    }

    public void removeNegativeModifiers(Hand h)
    {
        foreach(Dice d in h.dices)
        {
            foreach (DiceModifier m in d.modifierList)
            {
                switch (m)
                {
                    case DiceModifier.HydrogenBomb:
                        d.modifierList.Remove(m);
                        break;
                }
            }
        }
    }
}