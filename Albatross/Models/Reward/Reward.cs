using System;
namespace Albatross.Models
{
    public class Reward
    {
        public int RewardId { get; set; }

        public int ItemId { get; set; } //2.nøkkel:

        public Item Item { get; set; } //*
    }
}