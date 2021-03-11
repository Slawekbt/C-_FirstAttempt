using System;
namespace MedivalTournament
{

    class Marksman : Archer
    {
        public Marksman()
        { }

        public Marksman(double self_health, double self_endurance, double self_strenght, double self_balance, int self_luck, double self_concentration, double self_light_armour, double self_bow_damage) : base(self_health, self_endurance, self_strenght, self_balance, self_luck, self_concentration, self_light_armour, self_bow_damage)
        { }

        public double head_shot()
        {
            int luck_factor = new Random().Next(luck, 11) - 3;
            if (luck_factor > concentration)
            {
                return 666.0;
            }
            else
            {
                return 0.0;
            }

        }
    }

}