using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
     LA 5: Dice Pool
    
    Institution: Bow Valley College
    Program: Software Development
    Course: SODV1202: Introduction to Object Oriented Programming
    Instructor: Sohaib Bajwa
    Student Name: Sasha Greene
    Student ID: 435097
     */




namespace MyDicePool
{

       
    public class Dice
    {
        // TODO create Dice classes
        int sides;

        public Dice(int sides)
        {
            this.sides = sides;
        }
        public int Roll()
        {
            Random randomNum = new Random();
            return randomNum.Next(1, sides);
        }

        public int getSide()
        {
            return sides;
        }
    }
    public class DicePool
    {
        public List<Dice> dpool= new List<Dice>();

        // TODO create DicePool classes
        public void addDice(int sides)
        {
            dpool.Add(new Dice(sides));
        }

        public void removeDice(int sides)
        {
            for(int i = 0; i <dpool.Count; i++)
            {
                if (dpool[i].getSide() == sides)
                {
                    dpool.Remove(dpool[i]);
                }
            }
        }

        public void rollAllDice()
        {
            foreach(Dice dice in dpool)
            {
                Console.WriteLine("Dice {0}, Roll Result: {1}", dice.getSide(), dice.Roll());
                
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DicePool obj = new DicePool();
            string command;

            do
            {
                Console.WriteLine("Enter Command:");
                command = Console.ReadLine();
                command = command.Trim();
                command = command.ToLower();
                string[] split = command.Split();
                if (split[0] == "adddice")
                {

                    int sides = int.Parse(split[1]);
                    Console.WriteLine("Adding Dice {0}...", sides);
                    obj.addDice(sides);
                }
                else if (split[0] == "remove")
                {
                    int sides = int.Parse(split[1]);
                    Console.WriteLine("Removing Dice {0}...", sides);
                    obj.removeDice(sides);
                }
                else if (split[0] == "roll")
                {
                    int sides = int.Parse(split[1]);
                    foreach (Dice dice in obj.dpool)
                    {
                        if (sides == dice.getSide())
                        {
                            Console.WriteLine("Dice {0}, Roll Result: {1}", dice.getSide(), dice.Roll());
                        }

                    }
                }
                else if (split[0] == "rollall")
                {
                    Console.WriteLine("Rolling all Dice:");
                    obj.rollAllDice();
                }
            } while (command != "exit");
        }
    }
}
