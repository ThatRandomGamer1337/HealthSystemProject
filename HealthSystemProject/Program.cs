using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemProject
{
    internal class Program
    {

        static int health;
        static int shields;
        static int lives;
        static int score;
        static int reservedamage;

        static void Main(string[] args)
        {
            // Assigning intergers and values
            int enemyDamage;
            int enemyValue;

            int regularPoints;
            int doublePoints;
            int triplePoints;

            //- - - - - - -

            health = 91;
            lives = 3;
            shields = 100;
            score = 0;

            enemyDamage = 15;
            enemyValue = 10;

            regularPoints = 1;
            doublePoints = 2;
            triplePoints = 3;

            //- - - - - - -

            // Simulated Gameplay

            ShowHUD(); // Establishes the default hud to make sure all the values are properly registered.


            damageCounting(enemyDamage); // Testing the Damage Output.
            ScoreCounting(enemyValue, regularPoints);
            ScoreCounting(enemyValue, doublePoints); // Testing the Points System and the multipliers.
            ScoreCounting(enemyValue, triplePoints);
            ShowHUD();


            heal(10); // Testing the Healing Mechanic.
            ShowHUD();


            shieldRegen(30); // Testing the Shield Regeneration.
            ShowHUD();


            damageCounting(10); // Testing the Error Message.
            liveCounter(1); // Testing the Lives system.
            ShowHUD();



            Console.ReadKey();

            // Simulated Gameplay

            //- - - - - - -

        }

        //- - - the funny values and methods and stuff

        static void ShowHUD() // The HUD System itself.
        {
            Console.WriteLine("{ - - - }");
            Console.WriteLine("Player Score: " + score);
            Console.WriteLine("Player Health: " + health + ", Lives Remaining: " + lives);
            Console.WriteLine("Shield Percent: " + shields);
            Console.WriteLine("{ - - - }");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void ScoreCounting(int points, int multiplyer)
        {

            if (points < 0)
            {
                points = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            score = score + points;
            score = score * multiplyer;

            points = points * multiplyer;


            Console.WriteLine("Gained " + points + " points!");

        }

        static void damageCounting(int damage) // WIP Damage System. WIP because the player takes double damage than the shields do
        {
           if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            reservedamage = 0;

            shields = shields - damage;

            if (shields <= 0)
            {
                reservedamage = damage - shields;
                health = (health - reservedamage);

                shields = 0;
                reservedamage = 0;

                if (health < 0)
                {
                    health = 0;
                }
            }

            reservedamage = 0;


            Console.WriteLine("You have taken " + damage + " damage!");
        
        }
        static void liveCounter(int lostLife) // Lost a life Device (retrofit to allow recovering as well).
        {

            if (lostLife < 0)
            {
                lostLife = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            lives = lives - lostLife;

            if (lives <= 0) // If your lives hit 0, you d i e.
            {
                lives = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[ ! ]");
                Console.WriteLine("OUT OF LIVES. GAME OVER.");
                Console.WriteLine("[ ! ]");
                Console.WriteLine();
                Console.WriteLine();
            }

            if (lives > 0) // if you still have lives, you just lose one and get notified.
            {

                health = 100;
                shields = 100;
                Console.WriteLine("Watch out! You just lost " + lostLife + " life!");

            }

        }

        static void heal(int healing) // Player gets healed.
        {
            if (healing < 0)
            {
                healing = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            health = health + healing;

            if (health > 100) // prevents you from overhealing past 100 health.
            {
                health = 100;
            }


            Console.WriteLine("You have recovered " + healing + " health!");
        }

        static void shieldRegen(int regen) // Player regens shields.
        {
            if (regen < 0)
            {
                regen = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            shields = shields + regen;

            if (shields > 100) // prevents overshielding yourself past 100 shield.
            {
                shields = 100;
            }

            Console.WriteLine("Your shields regenerated by " + regen + "!");
        }
        
        static void UnitTest()
        {
            ShowHUD();
        }
    }
}
