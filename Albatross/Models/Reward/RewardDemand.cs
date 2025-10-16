using System;
namespace Albatross.Models
{
    public class RewardDemand
    {
        public int RewardDemandId { get; set; }
        
        public int RewardId { get; set; } //2.nøkkel:
        
         public Reward Reward { get; set; } //*
    }
}