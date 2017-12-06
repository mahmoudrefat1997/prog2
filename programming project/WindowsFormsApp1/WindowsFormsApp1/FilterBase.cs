using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class ConvolutionFilterBase
    {
        public abstract string FilterName
        {
            get;
        }

        public abstract double Factor
        {
            get;
            set;
        }

        public abstract double Bias
        {
            get;
        }

        public abstract double[,] FilterMatrix
        {
            get;
        }
    }
}
