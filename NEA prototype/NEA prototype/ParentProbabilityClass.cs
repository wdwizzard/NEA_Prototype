using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NEA_prototype
{
    internal class ParentProbabilityClass
    {
        protected double probability, expectedvalue, varience;
        public ParentProbabilityClass()
        {
            
        }
        protected double GetEX()
        {
            return expectedvalue;
        }
        protected double GetVarX()
        {
            return varience;
        }
    }
}