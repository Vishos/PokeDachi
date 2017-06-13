using System;
namespace dachi{

    public class Dachi{
        public int fullness {get;set;}
        public int happiness {get;set;}
        public int meals{get;set;}
        public int energy{get;set;}
        
        public Random rand{get;set;}
        public Dachi(){
            fullness = 20;
            happiness = 20;
            energy = 50;
            meals = 3;
            rand = new Random();

        }
        public string[] Feed(){
            string message;
            string status;
            if(meals < 1){
                message = "You don't have enough food to feed Pikachu. \nTry working.";
                status= "red";
                return new string[]{message,status};
            }
            meals -= 1;
            if(rand.Next(5)>0){
                int result = rand.Next(5,11);
                fullness += result;
                message = String.Format($"Pikachu gained {result} fullness.");
                status = "green";
                return new string[]{message,status};
            }
            else{
                message = "You fed Pikachu, but he's really hungry today and didn't gain any fullness.";
                status = "red";
                return new string[]{message,status};
            }
        }

        public string[] Play(){
            string message;
            string status;
            if(energy < 5)
            {
                message = "You don't have enough energy to play with Pikachu. \nTry sleeping.";
                status = "red";
                return new string[]{message,status};
            }
            energy -= 5;
            if(rand.Next(5)>0)
            {
                int result = rand.Next(5,11);
                happiness += result;
                message = string.Format($"You played with Pikachu and he gained {result} happiness.");
                status = "green";
                return new string[]{message,status};
            }
            else{
                message = "You played with Pikachu, but he is very needy today and hasn't gained any happiness.";
                status = "red";
                return new string[]{message,status};
            }
            
            

        }

        public string[] Work(){
            string message;
            string status;
            if(energy < 5){
                status = "red";
                message = "You don't have enough energy to work. \nTry sleeping.";
                return new string[]{message,status};
            }
            energy -=5;
            int result = rand.Next(1,4);
            meals += result;
            message = string.Format($"You worked hard and earned {result} meals.");
            status = "green";
            return new string[]{message,status};


        }

        public string[] Sleep(){
            energy += 15;
            fullness -= 5;
            happiness -= 5;
            string message = "You let Pikachu have a nap and he has gained 15 energy, but his happiness and fullness have decreased.";
            string status = "green";
            return new string[]{message,status};
        }

        public string[] Reset(){
            fullness = 20;
            happiness = 20;
            energy = 50;
            meals = 3;
            string message = "The game has been reset. Have fun!";
            string status = "green";
            return new string[]{message,status};
        }
    }
}
