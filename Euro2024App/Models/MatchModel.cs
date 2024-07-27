﻿namespace Euro2024App.Models
{
    public class MatchModel
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; } 
        public int AwayTeamId { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
    }
}
