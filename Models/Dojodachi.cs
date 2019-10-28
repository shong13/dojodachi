using System;
namespace dojodachi.Models
{
    public class Dojodachi
    {
        public int Happiness;
        public int Fullness;
        public int Energy;
        public int Meals;
        public bool Game;

        public Dojodachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Game = true;
        }

        public string Feed(){
            if(this.Meals > 0)
            {
                this.Meals -= 1;
                Random rand = new Random();
                int fullNum = rand.Next(5,11);
                this.Fullness += fullNum;
                //this.Check();
                return $"You fed your Dojodachi! Fullness +{fullNum}, Meal -1";
            }
            else
            {
                return "You don't have any more meals!!";
            }

        }
        public string Play()
        {
            if(this.Energy >= 5)
            {
                this.Energy -= 5;
                Random rand = new Random();
                int happyNum = rand.Next(5,11);
                this.Happiness += happyNum;
                // this.Check();
                return $"You played with your Dojodachi! Happiness +{happyNum}, Energy -5";
            }
            else
            {
                return "You do not have enough energy!";
            }
        }
        public string Work()
        {
            if(this.Energy >= 5)
            {
                this.Energy -= 5;
                Random rand = new Random();
                int mealNum = rand.Next(1,4);
                this.Meals += mealNum;
                return $"You worked! Meal +{mealNum}, Energy -5";
            }
            else
            {
                return "You do not have enough energy!";
            }
        }
        public string Sleep()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            // this.Check();
            return "Your Dojodachi slept! Energy +15, Happiness -5, Fullness -5";
        }

        public string Check()
        {
            if(this.Energy >= 100 && this.Fullness >= 100 && this.Happiness >= 100)
            {
                this.Game = false;
                return "Congratulations! You won!";
            }
            if(this.Fullness == 0 || this.Happiness == 0)
            {
                this.Game = false;
                return "Your Dojodachi has passed away";
            }
            return "";
        }

    }
}