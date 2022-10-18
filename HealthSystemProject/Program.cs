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

        static void Main(string[] args)
        {
            // Assigning intergers and values
            int enemyDamage;
            int enemyValue;

            int regularPoints;
            int doublePoints;
            int triplePoints;

            //- - - - - - -

            health = 100;
            lives = 3;
            shields = 100;
            score = 0;

            enemyDamage = 10;
            enemyValue = 10;

            regularPoints = 1;
            doublePoints = 2;
            triplePoints = 3;

            //- - - - - - -

            // Simulated Gameplay

            ShowHUD(); // Establishes the default hud to make sure all the values are properly registered.

            damageCountingShields(enemyDamage); // Testing the Damage Output.
            ScoreCounting(enemyValue, regularPoints);
            ScoreCounting(enemyValue, doublePoints); // Testing the Points System and the multipliers.
            ScoreCounting(enemyValue, triplePoints);
            ShowHUD();

            damageCountingHealth(enemyDamage);
            ShowHUD();

            heal(10); // Testing the Healing Mechanic.
            ShowHUD();

            shieldRegen(30); // Testing the Shield Regeneration.
            ShowHUD();

            damageCountingShields(-10); // Testing one of the many established Error Messages.
            liveCounter(1); // Testing the Lives system.
            ShowHUD();

            ResetValues();
            ShowHUD();

            Console.ReadKey();

            // Simulated Gameplay

            //- - - - - - -

        }
        
        //V V V Methods and Values and Calculations V V V
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

        static void ScoreCounting(int points, int multiplyer) // Calculates the score the player gets
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

        static void damageCountingShields(int damage) // Damage when applied to Shields.
        {
           if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            shields = shields - damage;

            Console.WriteLine("You have taken " + damage + " damage to your shields!");

        if (shields < 0)
            {
                shields = 0;

                Console.WriteLine("Shields have flared! You'll need energy cores in order to restore their power!"); // This causes access damage to be removed.
            }
        }
        static void damageCountingHealth(int damage)
        {
            if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            health = health - damage;

            Console.WriteLine("You have taken " + damage + " hull damage!");

            if (health > 100)
            {
                Console.WriteLine("Systems Fully Operational!");
            }

            if (health > 75)
            {
                Console.WriteLine("Systems Operational!");
            }
           
            if (health > 50)
            {
                Console.WriteLine("Systems Damaged!");
            }

            if (health > 25)
            {
                Console.WriteLine("Systems Severely Damaged!");
            }

            if (health < 0)
            {
                health = 0;

                Console.WriteLine("Systems Critical! I repeat, Systems Critical!");
            }

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

        static void ResetValues()
        {
            health = 100;
            shields = 100;
            lives = 3;
            score = 0;
            Console.WriteLine("Resetting Values...");
        }
    }
}
