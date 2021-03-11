using System;

namespace MedivalTournament
{
    class Swordsman : Human
    {
        public double fury { get; set; }
        public double heavy_armour { get; set; }
        public double sword_damage { get; set; }

        public Swordsman()
        { }

        public Swordsman(double self_health, double self_endurance, double self_strenght, double self_balance, int self_luck, double self_fury, double self_heavy_armour, double self_sword_damage) : base(self_health, self_endurance, self_strenght, self_balance, self_luck)
        {
            fury = self_fury;
            heavy_armour = self_heavy_armour;
            sword_damage = self_sword_damage;
        }

        override public void print_stats()
        {
            Console.WriteLine("Health        :: " + health);
            Console.WriteLine("Endurance     :: " + endurance);
            Console.WriteLine("Strenght      :: " + strenght);
            Console.WriteLine("Balance       :: " + balance);
            Console.WriteLine("Fury          :: " + fury);
            Console.WriteLine("Heavy armour  :: " + heavy_armour);
            Console.WriteLine("Sword damage  :: " + sword_damage);

        }

        public virtual double sword_attack()
        {
            double luck_factor = new Random().Next(luck, 11) / 10.0;
            double dealt_damage = Math.Floor(sword_damage + strenght + luck_factor * (0.4 * endurance + 0.2 * balance + 0.5 * fury));

            return dealt_damage;

        }

        public override double absorb_damage(double damage_dealt_by_enemy)
        {
            double luck_factor = new Random().Next(luck, 11) / 10.0;
            double damage_absorbed_by_endurance = Math.Floor(0.4 * endurance * luck_factor);
            double damage_absorbed_by_balance = Math.Floor(0.2 * balance * luck_factor);
            double damage_absorbed_by_fury = Math.Floor(0.1 * fury * luck_factor);

            double reduced_damage_value = damage_dealt_by_enemy - damage_absorbed_by_endurance - damage_absorbed_by_balance - damage_absorbed_by_fury - heavy_armour;

            if (reduced_damage_value < 0)
            {
                reduced_damage_value = 2;
                health -= reduced_damage_value;
                fury += 0.2;
            }

            else
            {
                health -= reduced_damage_value;
                fury += 3;
            }




            if ((endurance > 0) && (balance > 0.7 * damage_absorbed_by_endurance))
                endurance -= Math.Floor(0.7 * damage_absorbed_by_endurance * (0.2 * fury));
            else
                endurance = 0;

            if (luck_factor < 0.40 && balance > damage_absorbed_by_balance)
                balance -= damage_absorbed_by_balance;
            else if (luck_factor < 0.40 && balance < damage_absorbed_by_balance)
                balance = 0;

            return reduced_damage_value;
        }


    }

}