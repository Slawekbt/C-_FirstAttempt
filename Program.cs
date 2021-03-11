using System;
using System.Threading; // for Sleep() facility

namespace MedivalTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            double tmp_dealt = 0.0;
            double tmp_absorbed = 0.0;
            int turn = 1;


            Human human1, human2;
            human1 = new Human(80, 15, 15, 10, 2);
            human2 = new Human(100, 17, 14, 14, 3);

            // fight human1 vs human 2

            Archer archer;
            Marksman marksman;
            Swordsman swordsman;
            ShieldBearer shielder;

            archer = new Archer(450, 30, 10, 15, 4, 7, 20, 30);
            marksman = new Marksman(280, 40, 12, 18, 4, 9, 15, 35);

            swordsman = new Swordsman(400, 30, 50, 20, 2, 8, 50, 50);
            shielder = new ShieldBearer(450, 45, 35, 25, 3, 3, 40, 55, 15);

            while (true) // human1 vs human2
            {   
                Console.WriteLine("Fight human1 vs human 2 ::  Turn " + turn);

                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Human 1 current stats");
                human1.print_stats();
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Human 2 current stats");
                human2.print_stats();
                Thread.Sleep(2500);

                if (human1.isDead() || human2.isDead())
                {
                    Console.WriteLine("The fight is over");
                    turn = 1;
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
                }

                tmp_dealt = human1.punch();
                tmp_absorbed = human2.absorb_damage(tmp_dealt);
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Human 1 dealt " + tmp_dealt + " [dmg] Human 2 took " + tmp_absorbed + "[ dmg ]");
                Thread.Sleep(2500);

                tmp_dealt = human2.punch();
                tmp_absorbed = human1.absorb_damage(tmp_dealt);
                Console.WriteLine("Human 2 dealt " + tmp_dealt + " [dmg] Human 1 took " + tmp_absorbed + "[ dmg ]");
                Thread.Sleep(2500);

                turn++;
                Console.Clear();

            }

            while (true) // marksman vs archer
            {
                Console.WriteLine("Fight archer vs marksman ::  Turn " + turn);

                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Archer current stats");
                archer.print_stats();
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Marksman current stats");
                marksman.print_stats();
                Thread.Sleep(2500);

                if (archer.isDead() || marksman.isDead())
                {
                    Console.WriteLine("The fight is over");
                    Thread.Sleep(3500);
                    Console.Clear();
                    turn = 1;
                    break;
                    
                }

                tmp_dealt = archer.shoot();
                tmp_absorbed = marksman.absorb_damage(tmp_dealt);
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Archer dealt " + tmp_dealt + " [dmg] Marksman took " + tmp_absorbed + "[ dmg ]");
                Thread.Sleep(2500);

                if (turn % 3 == 0) // Marksman tries to headshot
                {
                    tmp_dealt = marksman.head_shot();
                    if (tmp_dealt != 0.0)
                    {
                        Console.WriteLine("Marksman dealt performs head shot - Successfully !");
                        tmp_absorbed = archer.absorb_damage(tmp_dealt);
                        Console.WriteLine("Marksman's head shot dealt " + tmp_dealt + " [dmg] Archer took " + tmp_absorbed + "[ dmg ]");
                    }

                    else
                    {
                        Console.WriteLine("Marksman dealt performs head shot - Unsuccessfully ...");
                    }
                }

                else
                {
                    tmp_dealt = marksman.shoot();
                    tmp_absorbed = archer.absorb_damage(tmp_dealt);
                    Console.WriteLine("Marksman dealt " + tmp_dealt + " [dmg] Archer took " + tmp_absorbed + "[ dmg ]");
                    
                }
                Thread.Sleep(2500);
                turn++;
                Console.Clear();
            }



            while (true) // swordsman vs shielder
            {
                Console.WriteLine("Fight swordsman vs shielder ::  Turn " + turn);

                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Swordsman current stats");
                swordsman.print_stats();
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Shield bearer current stats");
                shielder.print_stats();
                Thread.Sleep(2500);

                if (swordsman.isDead() || shielder.isDead())
                {
                    Console.WriteLine("The fight is over");
                    Thread.Sleep(3500);
                    turn = 1;
                    break;

                }

                tmp_dealt = swordsman.sword_attack();
                tmp_absorbed = shielder.absorb_damage(tmp_dealt);
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Swordsman dealt " + tmp_dealt + " [dmg] Shield bearer took " + tmp_absorbed + "[ dmg ]");
                Thread.Sleep(2500);

                if (turn % 4 == 0) // Shielder performs bash and then sword attack
                {
                    Console.WriteLine("Shield bearer performs bash attact with his shield");
                    tmp_dealt = shielder.bash();
                    tmp_absorbed = swordsman.absorb_damage(tmp_dealt);
                    Console.WriteLine("Shield bearer dealt " + tmp_dealt + " [dmg] Swordsman took " + tmp_absorbed + "[ dmg ]");
                    Thread.Sleep(2000);
                }

                
                
                tmp_dealt = shielder.sword_attack();
                tmp_absorbed = swordsman.absorb_damage(tmp_dealt);
                Console.WriteLine("Shield bearer dealt " + tmp_dealt + " [dmg] Swordsman took " + tmp_absorbed + "[ dmg ]");

                
                Thread.Sleep(2500);
                turn++;
                Console.Clear();
            }
        }
    }
}












