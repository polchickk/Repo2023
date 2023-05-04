﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LeftParameters:IParameters
    {
        public double AngleInDegrees { get; set; }

        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Угол в град",
                    MinValue = 0,
                    MaxValue = 85,
                    DefaultValue = 0,
                    Increment = 5
                }
            };

        }

        public void SetValues(double[] values)
        {
            AngleInDegrees = values[0];
        }
    }
}
