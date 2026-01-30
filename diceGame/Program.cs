//Dice d1 = new Dice(6);
//Console.WriteLine(d1.upperFaceValue);
//d1.roll();
//Console.WriteLine(d1.upperFaceValue);

Hand player = new Hand(2);

int currentLowerThreshold = 2;
int currentUpperTHreshold = 12;

while (true)
{
    Encounter e = new Encounter(GeneralStuff.names[new Random().Next(0, 4)], 
                                currentLowerThreshold, 
                                currentUpperTHreshold, 
                                new List<DiceModifier>());

    Console.WriteLine("You face the mighty " + e.name + 
                      ". Have your roll land between " + e.lowerThreshold + " and " + e.upperThreshold + 
                      " to move on!");

    player.tossDices();
    Console.WriteLine("your roll ammounts to " + player.sum + ".");

    if (player.sum >=  e.lowerThreshold && player.sum <= e.upperThreshold)
    {
        Console.WriteLine("Victory! Choose a reward: (0 to upgrade a dice, 1 to modify a dice, 2 to get another dice or 3 to remove a dice):");
        int c = int.Parse(Console.ReadLine()); //choice for reward.

        switch (c)
        {
            case 0:
                Console.WriteLine("Choose a dice to upgrade (you have " + player.dices.Count + "):");
                int diceToUpgrade = int.Parse(Console.ReadLine());

                Console.WriteLine("Upgrading dice " + diceToUpgrade + " ...");
                player.dices[diceToUpgrade-1].sideCount += player.sideCountUpgrade;
                break;

            case 1:
                Console.WriteLine("Choose a dice to modify (you have " + player.dices.Count + "):");
                int diceToModify = int.Parse(Console.ReadLine());

                Console.WriteLine("Modifying dice " + diceToModify + " ...");
                break;

            case 2:
                Console.WriteLine("Adding a standard 6-sided dice to your hand...");
                player.addDice(6);
                break;

            case 3:
                Console.WriteLine("Choose a dice to remove (you have " + player.dices.Count + "):");
                int diceToRemove = int.Parse(Console.ReadLine());

                Console.WriteLine("Removing dice " + diceToRemove + " ...");
                player.removeDice(diceToRemove-1);
                break;

            default:
                Console.WriteLine("how the hell did we get here.");
                break;
        }

        int randomThresholdModifier = new Random().Next(0, 4);
        currentLowerThreshold += randomThresholdModifier;  
        currentUpperTHreshold += randomThresholdModifier;  
    }
    else
    {
        Console.WriteLine("not this time.");
        return;
    }
}
