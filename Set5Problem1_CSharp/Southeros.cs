using System;
using System.Collections.Generic;

namespace Set5Problem1_CSharp
{
    public sealed class Southeros
    {
        //Private Variables
        private string currentRuler;

        //Private Constructor, so outsiders do not have access. We initialize Current Ruler as 'none'
        private Southeros()
        {
            currentRuler = "None";
        }

        //Static method to provide access to the Singleton Instance of this class
        public static Southeros Instance { get; } = new Southeros();

        //Public Methods
        public void BeginShanConquest()
        {
            #region REQUIRED VARIABLES

            //Current message holder
            var currentMessage = "";

            //For this scenario, we initialize the Space Kingdom as the Conqueror
            var conqueror = new Kingdom("Space", "Gorilla");
            
            //Then we initialize a list of remaining kingdoms
            List<Kingdom> allKingdoms = new List<Kingdom>
            {
                new Kingdom("Land", "Panda"),
                new Kingdom("Water", "Octopus"),
                new Kingdom("Ice", "Mammoth"),
                new Kingdom("Air", "Owl"),
                new Kingdom("Fire", "Dragon")
            };

            //We display the current state in Southeros
            Console.WriteLine("Current ruler of Southeros: {0}", currentRuler);
            Console.WriteLine("Current Allies of Ruler: None");

            #endregion

            #region INPUT

            Console.WriteLine('\n');

            Console.WriteLine("King Shan now begins his conquest of Southeros...");

            Console.WriteLine('\n');

            //Now sending messages to all kingdoms
            for (var i = 0; i < allKingdoms.Count; i++)
            {
                Console.WriteLine("Enter Message for the {0} Kingdom: ", allKingdoms[i].GetKingdomName());
                currentMessage = Console.ReadLine();
                conqueror.SendMessage(currentMessage, allKingdoms[i]);
            }

            #endregion

            #region LOGIC

            //Ruler of Southeros is King Shan if his Allies are 3 or more
            if (conqueror.GetNumberOfAllies() >= 3)
            { currentRuler = "King Shan"; }

            #endregion

            #region OUTPUT

            Console.WriteLine('\n');

            Console.WriteLine("Input Messages to Kingdoms from King Shan:");

            Console.WriteLine('\n');

            //Display the messages sent by King Shan
            for (var i = 0; i < allKingdoms.Count; i++)
            {
                if (allKingdoms[i].GetIncomingMessage() != "")
                {
                    Console.WriteLine("Input: {0}, {1}", allKingdoms[i].GetKingdomName(), allKingdoms[i].GetIncomingMessage());
                }
            }

            //Display the Ruler of Southeros and his Allies
            Console.WriteLine('\n');
            Console.WriteLine("Who is the Ruler of Southeros?");

            if (currentRuler != "")
            {
                Console.WriteLine(currentRuler);
            }

            Console.WriteLine('\n');

            Console.WriteLine("Allies of Ruler?");

            //Request the Conqueror to display a list of his Aliies
            conqueror.DisplayAllies();

            #endregion
        }
    }
}
