using System;
using UnityEngine;
using Random = System.Random;

namespace SomeAnyBird.Data
{
    public class DistanceRange
    {
        private float _proportion;
        
        public float Max;
        public float Min;
        
        public float Proportion
        {
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new Exception("[DistanceRange] Proportion must be between 0 and 1.");
                }

                _proportion = value;
            }
            
            get => _proportion;
        }

        public float Value
        {
            get => Proportion * (Max - Min) + Min;
            private set {}
        }

        public DistanceRange()
        {
            Max = 0.0f;
            Min = 0.0f;
            Proportion = 0.0f;
        }

        public DistanceRange(float min, float max, float proportion)
        {
            Min = min;
            Max = max;
            Proportion = proportion;
        }

        public static float GetRandomProportion(int quality = 100)
        {
            return (float) new Random().Next(0, quality + 1) / quality;
        }
    }
}