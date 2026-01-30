//Dice d1 = new Dice(6);
//Console.WriteLine(d1.upperFaceValue);
//d1.roll();
//Console.WriteLine(d1.upperFaceValue);

Hand player = new Hand(2);
Random rnd = new Random();

int currentLowerThreshold = 2;
int currentUpperTHreshold = 12;

while (true)
{
    Encounter e = new Encounter(GeneralStuff.names[rnd.Next(0, 4)], 
                                currentLowerThreshold, 
                                currentUpperTHreshold, 
                                new List<DiceModifier>());

    Console.WriteLine("You face the mighty " + e.name + 
                      ". Have your roll land between " + e.lowerThreshold + " and " + e.upperThreshold + 
                      " to move on!\n" +
                      "type anything to roll!. ");
    Console.ReadLine();
    
    player.tossDices();
    Console.WriteLine("your roll ammounts to " + player.sum + ".\n");

    if (player.sum >=  e.lowerThreshold && player.sum <= e.upperThreshold)
    {
        Console.WriteLine("Victory! Choose a reward: (0 to upgrade a dice, 1 to modify a dice, 2 to get another dice or 3 to remove a dice):");

        int c = int.Parse(Console.ReadLine()); //choice for reward.

        switch (c)
        {
            case 0:
                Console.WriteLine("Choose a dice to upgrade (you have " + player.dices.Count + "):");
                player.showDices();
                int diceToUpgrade = int.Parse(Console.ReadLine());

                Console.WriteLine("Upgrading dice " + diceToUpgrade + " ...");
                player.dices[diceToUpgrade-1].sideCount += player.sideCountUpgrade;
                break;

            case 1:
                Console.WriteLine("Choose a dice to modify (you have " + player.dices.Count + "):");
                player.showDices();
                int diceToModify = int.Parse(Console.ReadLine());

                Console.WriteLine("Type 0 to add a modifier, or 1 to remove a modifier: ");
                int modifyChoice = int.Parse(Console.ReadLine());
                if (modifyChoice == 0)
                {
                    List<DiceModifier> rndMods = new List<DiceModifier>();
            
                    var l = Enum.GetValues<DiceModifier>();
                    string randomMods = "";
                    for (int i = 0; i < 3; ++i)
                    {
                        var v = (DiceModifier)rnd.Next(l.Length);
                        rndMods.Add(v);
                        randomMods += $"{i} - {v}\n";
                    }                  

                    Console.WriteLine($"choose one of the following modifiers to add to dice {diceToModify + 1}:\n{randomMods}");
                    int chosenMod = int.Parse(Console.ReadLine());
                    player.dices[diceToModify-1].modifierList.Add(rndMods[chosenMod]);

                    Console.WriteLine($"Adding modifier {rndMods[chosenMod]} to {diceToModify}...");
                }
                else if (modifyChoice == 1)
                {
                    Console.WriteLine($"choose one of the following modifiers to remove from dice {diceToModify}: ");
                    int j = 0;
                    foreach (DiceModifier m in player.dices[diceToModify].modifierList)
                    {
                        Console.WriteLine($"{j} - {m}");
                    }

                    int chosenRemovedMod = int.Parse(Console.ReadLine());
                    player.dices[diceToModify-1].modifierList.RemoveAt(chosenRemovedMod);                    
                }
                else
                {
                    Console.WriteLine("Wrong!!! You lost your turn for being cheeky. Figures.");
                }
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

        int randomThresholdModifier = rnd.Next(0, 4);
        currentLowerThreshold += randomThresholdModifier;  
        currentUpperTHreshold += randomThresholdModifier;  
    }
    else
    {
        Console.WriteLine("not this time.");
        return;
    }
}
