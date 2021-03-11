using System;
namespace MedivalTournament
{
    class Human
    {
        public double health { get; set; }
        public double endurance { get; set; }
        public double strenght { get; set; }
        public double balance { get; set; }
        public int luck { get; set; }

        public Human()
        { }

        public Human(double self_health, double self_endurance, double self_strenght, double self_balance, int self_luck)
        {
            health = self_health;
            endurance = self_endurance;
            strenght = self_strenght;
            balance = self_balance;
            luck = self_luck;
        }
        public double punch()
        {
            double damage = strenght + Math.Floor((endurance * (new Random().Next(luck, 11)) / 10.0)) + Math.Floor(0.1 * balance * (new Random().Next(luck, 11)) / 10.0);
            return damage;
        }

        virtual public void print_stats()
        {
            Console.WriteLine("Health    :: " + health);
            Console.WriteLine("Endurance :: " + endurance);
            Console.WriteLine("Strenght  :: " + strenght);
            Console.WriteLine("Balance   :: " + balance);
            Console.WriteLine("Luck      :: " + luck);
        }

        public bool isDead()
        {
            if (health > 0)
                return false;
            else
                return true;
        }

        virtual public double absorb_damage(double damage_dealt_by_enemy)
        {
            double luck_factor = new Random().Next(luck, 11) / 10.0;
            double damage_absorbed_by_endurance = Math.Floor(0.3 * endurance * luck_factor);
            double damage_absorbed_by_balance = Math.Floor(0.1 * balance * luck_factor);

            double reduced_damage_value = damage_dealt_by_enemy - damage_absorbed_by_endurance - damage_absorbed_by_balance;

            if (reduced_damage_value < 0)
                health -= 5;

            else
                health -= reduced_damage_value;


            if ((endurance > 0) && (balance > 1.5 * damage_absorbed_by_endurance))
                endurance -= 1.5 * damage_absorbed_by_endurance;
            else
                endurance = 0;

            if (luck_factor < 0.45 && balance > damage_absorbed_by_balance)
                balance -= damage_absorbed_by_balance;
            else if (luck_factor < 0.45 && balance < damage_absorbed_by_balance)
                balance = 0;

            return reduced_damage_value;
        }

    } // Human
}