using System;
using System.Collections.Generic;

namespace RacingChampionship
{
  
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public int PerformanceLevel { get; set; }
        
        public abstract void Upgrade(Player player);
    }

    public class Car : Vehicle
    {
        public Car()
        {
            Name = "Sports Car";
            PerformanceLevel = 1;
        }

        public override void Upgrade(Player player)
        {
            int upgradeCost = 50;
            if (player.Points >= upgradeCost)
            {
                player.Points -= upgradeCost;
                PerformanceLevel++;
                Console.WriteLine($"{Name} upgraded! New Performance Level: {PerformanceLevel}");
            }
            else
            {
                Console.WriteLine("Not enough points to upgrade.");
            }
        }
    }

    public class Bike : Vehicle
    {
        public Bike()
        {
            Name = "Racing Bike";
            PerformanceLevel = 1;
        }

        public override void Upgrade(Player player)
        {
            int upgradeCost = 30;
            if (player.Points >= upgradeCost)
            {
                player.Points -= upgradeCost;
                PerformanceLevel++;
                Console.WriteLine($"{Name} upgraded! New Performance Level: {PerformanceLevel}");
            }
            else
            {
                Console.WriteLine("Not enough points to upgrade.");
            }
        }
    }

   
    public class Track
    {
        public string Name { get; set; }
        public bool IsUnlocked { get; set; }
        public int UnlockCost { get; set; }

        public Track(string name, bool isUnlocked, int unlockCost)
        {
            Name = name;
            IsUnlocked = isUnlocked;
            UnlockCost = unlockCost;
        }
    }


    public class Player
    {
        public string Name { get; set; }
        public Vehicle SelectedVehicle { get; set; }
        public int Points { get; set; }

        public Player(string name)
        {
            Name = name;
            Points = 0; 
        }
    }

   
    public class Race
    {
        public Track CurrentTrack { get; set; }

        public Race(Track track)
        {
            CurrentTrack = track;
        }

        public void StartRace(Player player)
        {
            if (!CurrentTrack.IsUnlocked)
            {
                Console.WriteLine($"Cannot race. {CurrentTrack.Name} is locked.");
                return;
            }

            Console.WriteLine($"\n--- Starting race on {CurrentTrack.Name} with {player.SelectedVehicle.Name} ---");
            
            Random rand = new Random();
            int position = rand.Next(1, 6); 
            
            Console.WriteLine($"{player.Name} finished in position: {position}");
            AssignPoints(player, position);
        }

        private void AssignPoints(Player player, int position)
        {
            int pointsEarned = 0;
            switch (position)
            {
                case 1: pointsEarned = 100; break;
                case 2: pointsEarned = 75; break;
                case 3: pointsEarned = 50; break;
                case 4: pointsEarned = 25; break;
                default: pointsEarned = 10; break;
            }

            player.Points += pointsEarned;
            Console.WriteLine($"Earned {pointsEarned} points! Total Points: {player.Points}");
        }
    }

    class Championship
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== RACING CHAMPIONSHIP GAME ===");

     
            Player player1 = new Player("Racer One");

        
            player1.SelectedVehicle = new Car(); 
            Console.WriteLine($"{player1.Name} selected a {player1.SelectedVehicle.Name}.");

           
            Track track1 = new Track("Beginner Circuit", true, 0);
            Track track2 = new Track("Pro Circuit", false, 150);

         
            Race race1 = new Race(track1);
            race1.StartRace(player1);

            player1.SelectedVehicle.Upgrade(player1);

          
            if (player1.Points >= track2.UnlockCost && !track2.IsUnlocked)
            {
                player1.Points -= track2.UnlockCost;
                track2.IsUnlocked = true;
                Console.WriteLine($"Unlocked {track2.Name}!");
            }

            Console.WriteLine("\nChampionship cycle complete.");
        }
    }
}
