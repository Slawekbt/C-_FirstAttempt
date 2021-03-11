using System;
namespace MedivalTournament
{
    class Archer : Human
    {
        public double concentration;
        public double light_armour;
        public double bow_damage;

        public Archer()
        { }

        public Archer(double self_health, double self_endurance, double self_strenght, double self_balance, int self_luck, double self_concentration, double self_light_armour, double self_bow_damage) : base(self_health, self_endurance, self_strenght, self_balance, self_luck)
        {
            concentration = self_concentration;
            light_armour = self_light_armour;
            bow_damage = self_bow_damage;
        }

        override public void print_stats()
        {
            Console.WriteLine("Health         :: " + health);
            Console.WriteLine("Endurance      :: " + endurance);
            Console.WriteLine("Strenght       :: " + strenght);
            Console.WriteLine("Balance        :: " + balance);
            Console.WriteLine("Luck           :: " + luck);
            Console.WriteLine("Concentration  :: " + concentration);
            Console.WriteLine("Light armour   :: " + light_armour);
            Console.WriteLine("Bow damage     :: " + bow_damage);
        }

        public double shoot()
        {
            double luck_factor = new Random().Next(luck, 11) / 10.0;

            double dealt_damage = Math.Floor(bow_damage + 0.2 * strenght + luck_factor * (0.3 * endurance + 0.4 * balance + 0.8 * concentration));

            return dealt_damage;
        }

        public override double absorb_damage(double damage_dealt_by_enemy)
        {
            double luck_factor = new Random().Next(luck, 11) / 10.0;

            double damage_absorbed_by_endurance = Math.Floor(0.3 * endurance * luck_factor);
            double damage_absorbed_by_balance = Math.Floor(0.1 * balance * luck_factor);


            double reduced_damage_value = damage_dealt_by_enemy - damage_absorbed_by_endurance - damage_absorbed_by_balance - 0.7 * light_armour;

            if (reduced_damage_value < 0)
            {
                reduced_damage_value = 5;
                health -= reduced_damage_value;
            }

            else
                health -= reduced_damage_value;


            if ((endurance > 0) && (balance > 1.2 * damage_absorbed_by_endurance))
            {
                endurance -= Math.Floor(1.2 * damage_absorbed_by_endurance);
                concentration -= 1;
            }

            else
                endurance = 0;

            if (luck_factor < 0.45 && balance > damage_absorbed_by_balance)
                balance -= damage_absorbed_by_balance;
            else if (luck_factor < 0.45 && balance < damage_absorbed_by_balance)
                balance = 0;

            return reduced_damage_value;
        }
    }

}