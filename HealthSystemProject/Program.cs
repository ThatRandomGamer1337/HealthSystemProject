using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemProject
{
    internal class Program
    {
        // the important intergers
        static int health;
        static string healthStatus;
        static int shields;
        static int lives;
        static int score;
        static float time;

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

            enemyDamage = 15;
            enemyValue = 10;

            regularPoints = 1;
            doublePoints = 2;
            triplePoints = 3;

            //- - - - - - -

            // Simulated Gameplay

            ShowHUD(); // Establishes the default hud to make sure all the values are properly registered.

            damageCountingShields(enemyDamage); // Testing the Damage Output.
            scoreCounting(enemyValue, regularPoints);
            scoreCounting(enemyValue, doublePoints); // Testing the Points System and the multipliers.
            scoreCounting(enemyValue, triplePoints);
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

            resetValues();
            ShowHUD();

            UnitTest();

            Console.ReadKey(true);

            // Simulated Gameplay

            //- - - - - - -

        }

        //V V V Methods and Values and Calculations V V V
        static void ShowHUD() // The HUD System itself.
        {
            Console.WriteLine();
            Console.WriteLine("{ - - - }");
            Console.WriteLine("Player Score: " + score);
            Console.WriteLine("Time: " + time);
            Console.WriteLine("Player Health: " + health + ", Lives Remaining: " + lives);
            Console.WriteLine("Player Health Status: " + healthStatus);
            Console.WriteLine("Shield Percent: " + shields);
            Console.WriteLine("{ - - - }");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void status()
        {
            
        }

        static void scoreCounting(int points, int multiplyer) // Calculates the score the player gets
        {

            if (points < 0)
            {
                points = 0;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            if (multiplyer < 0)
            {
                multiplyer = 1;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to default. I wonder how that happened."); // prevents negative numbers
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

        Console.WriteLine("Taken " + damage + " hull damage!");

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

        static void resetValues() // As the name states, it returns all your values back to the default settings.
        {
            health = 100;
            shields = 100;
            lives = 3;
            score = 0;
            Console.WriteLine("Resetting Values...");
        }

        static void timerCount(float timer) // In game timer which increases every second. Simple lol.
        {

            if (timer < 0.0f)
            {
                timer = 0.0f;
                Console.WriteLine("ERROR: Negative Value Detected. Reverting Value to 0. I wonder how that happened."); // prevents negative numbers
            }

            time = time + timer;
        }

        static void UnitTest() // This setting is a full proper test of all the safety features to prevent values from going haywire.
        {
            
            resetValues();
            ShowHUD();

            scoreCounting(-10, -10);
            damageCountingShields(-10);
            damageCountingHealth(-10);
            liveCounter(-10);
            heal(-10);
            shieldRegen(-10);
            timerCount(-10.0f);

            ShowHUD();
        }


    }
}
