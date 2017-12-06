using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class filter : ConvolutionFilterBase
    {
        public override string FilterName
        {
            get { return "custom filter"; }
        }

        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
            set { factor = value; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        public double[,] filterMatrix= { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } } ;
      
        
        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
        }
    }
}
