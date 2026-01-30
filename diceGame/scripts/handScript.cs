public class Hand
{
    public List<Dice> dices = new List<Dice>();
    public int sum = 0;
    public int rerollCount = 0;
    public int sideCountUpgrade = 2;
    
    public Hand(int newDiceCount)
    {
        for (int i = 0; i < newDiceCount; ++i)
        {   
            addDice(6);
        }
    }

    public void tossDices()
    {
        sum = 0;
        foreach (Dice d in dices)
        {
            d.roll();
            sum += d.upperFaceValue;
        }
    }

    public void addDice(int newSideCount)
    {
        dices.Add(new Dice(newSideCount));
    }

    public void addDiceModifier(int i, DiceModifier d)
    {
        dices[i].modifierList.Add(d);        
    }

    public void upgradeDice(int i)
    {
        dices[i].sideCount += sideCountUpgrade;
    }

    public void removeDice(int i)
    {
        //I don't really like this. Just here in case it's needed.
        dices.RemoveAt(i);
    }
}