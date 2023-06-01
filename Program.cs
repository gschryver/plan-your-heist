using System;
using System.Collections.Generic;

class Program
{
    class TeamMember
    {
        public string? Name { get; set; }
        public int SkillLevel { get; set; }
        public int CourageFactor { get; set; }
    }

    static void Main()
    {
        // Prompt the user to enter the difficulty level of the bank.
        Console.WriteLine("Enter the difficulty level:");
        int bankDifficultyLevel = int.Parse(Console.ReadLine());

        // Prompt the user to enter the number of team members.
        Console.WriteLine("Enter the number of team members:");
        int numberOfTeamMembers = int.Parse(Console.ReadLine());

        // Create a way to store several team members.
        List<TeamMember> teamMembers = new List<TeamMember>();

        // Loop through each team member and prompt the user to enter their information.
        while (teamMembers.Count < numberOfTeamMembers)
        {
            Console.WriteLine(
                "Enter a team member's name (leave blank to stop adding team members):"
            );
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.WriteLine("Enter a team member's skill level:");
            int skillLevel = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a team member's courage factor:");
            int courageFactor = int.Parse(Console.ReadLine());

            TeamMember teamMember = new TeamMember()
            {
                Name = name,
                SkillLevel = skillLevel,
                CourageFactor = courageFactor
            };

            teamMembers.Add(teamMember);
        }

        // Prompt the user to enter the number of trial runs the program should perform.
        Console.WriteLine("Enter the number of trial runs:");
        int numberOfTrials = int.Parse(Console.ReadLine());

        int successCount = 0;
        int failureCount = 0;

        // Loop through the difficulty/skill level calculation based on the user-entered number of trial runs.
        for (int i = 0; i < numberOfTrials; i++)
        {
            // Create a random number between -10 and 10 for the heist's luck value.
            Random random = new Random();
            int luckValue = random.Next(-10, 10);

            // Add the luck value to the bank's difficulty level.
            int modifiedBankDifficultyLevel = bankDifficultyLevel + luckValue;

            // Sum the skills of the team.
            int teamSkillLevel = 0;
            foreach (TeamMember member in teamMembers)
            {
                teamSkillLevel += member.SkillLevel;
            }

            // Display a report that shows the team's combined skill level and the bank's difficulty level.
            Console.WriteLine($"Trial {i + 1}:");
            Console.WriteLine($"Team Skill Level: {teamSkillLevel}");
            Console.WriteLine($"Bank Difficulty Level: {bankDifficultyLevel}");

            // Compare the team's skill level with the bank's difficulty level. If the team's skill level is greater than or equal to the bank's difficulty level, display a success message, otherwise display a failure message.
            if (teamSkillLevel >= bankDifficultyLevel)
            {
                successCount++;
                Console.WriteLine(
                    "I'm making a note here: Great Success! We have enough skill to rob the bank!"
                );
            }
            else
            {
                failureCount++;
                Console.WriteLine(
                    "What a bunch of losers! We don't have the talent to pull off this heist."
                );
            }

            Console.WriteLine("------------------");
        }

        // Display a report showing the number of successful runs and the number of failed runs.
        Console.WriteLine($"Number of successful runs: {successCount}");
        Console.WriteLine($"Number of failed runs: {failureCount}");
    }
}
