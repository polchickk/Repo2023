using PhotoEnhancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    internal class InvertParameters : IParameters
    {
        public ParameterInfo[] GetDecription() => new ParameterInfo[0];

        public void SetValues(double[] values) { }
    }
}
