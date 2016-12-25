using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinLib
{
    public class Vector
    {
        private int col = 0, row = 0;
        private int valueCount
        {
            get { return col * row; }
        }
        int columns
        {
            get { return col; }
        }
        int rows
        {
            get { return row; }
        }
        
        double[] values;


        /// <summary>
        /// Creates an empty Vector with no dimensions and no values.
        /// </summary>
        public Vector()
        {
            row = 0;
            col = 0;
            values = new double[0];
        }

        /// <summary>
        /// Creates a zero Vector with [c] cols and [r] rows.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        public Vector(int c, int r)
        {

            col = c;
            row = r;
            values = new double[r * c];
            for (int i = 0; i < values.Length; i++) values[i] = 0;

        }

        /// <summary>
        /// Creates a vector of size (c,r) and fills it with values from [vals]
        /// This will truncate any values that are left over, and will fill any 
        /// empty spots with 0.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="r"></param>
        /// <param name="vals"></param>
        public Vector(int c, int r, double[] vals)
        {

            col = c;
            row = r;
            values = new double[r * c];
            for (int i = 0; i < values.Length; i++) values[i] = (i < vals.Length) ? vals[i] : 0;

        }

        /// <summary>
        /// Creates an Identity matrix of width and height [size]
        /// </summary>
        /// <param name="size"></param>
        public Vector(int size)
        
        {
            int count = 0;
            row = size;
            col = size;
            values = new double[size * size];
            for (int i = 0; i < values.Length; i++) {
                if(i%col == i/col)
                {
                    values[i] = 1;
                    count++;
                }
                else
                {
                    values[i] = 0;
                }
            }
        }

        /// <summary>
        /// Creates a Vector with the dimensions and values of the 2D input.
        /// </summary>
        /// <param name="vals"></param>
        public Vector(double [,] vals)
        {
            row = vals.GetLength(0);
            col = vals.GetLength(1);
            values = new double[col * row];
            for(int i = 0; i < valueCount; i++)
            {
                values[i] = vals[i / col, i % col];
            }

        }

        public double[,] To2DArray()
        {
            double[,] output = new double[row,col];
            for (int i = 0; i < valueCount; i++) // This can be parallelized
            {
                output[i / col, i % col] = values[i];
            }

            return output;
        }


        public override String ToString()
        {
            String output = "Vector: " + col + " x " + row + "\n";
            for(int y = 0; y < row; y++)
            {
                output += "[";
                for(int x = 0; x < col; x++)
                {
                    output += values[col * y + x] + ((x == col-1)?"":", ");
                }
                output += "]\n";
            }
            return output;
        }

        public double ReadAt(int c, int r)
        {
            return values[r * col + c];
        }

        public void WriteAt(int c, int r, double val)
        {
            values[r * col + c] = val;
        }

        public Vector Squared()
        {
            int size = Math.Max(row, col);
            Vector output = new Vector(size, size);
            for(int i = 0; i < this.valueCount; i++)
            {
                output.WriteAt(i % col, i / col, values[i]);
            }
            return output;
        }
    }
}
