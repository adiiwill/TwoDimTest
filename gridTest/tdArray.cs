using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridTest
{
    internal class tdArray
    {
        public int[,] arrayOfNumbers;

        public int a;
        public int b;

        public tdArray(int a, int b)
        { 
            arrayOfNumbers = new int[a, b];
            this.a = a;
            this.b = b;
            FillArray();
        }

        /// <summary>
        /// Returns an array with the following neighbour indexes: <br />
        /// 0 1 2<br />
        /// 3 x 4<br />
        /// 5 6 7
        /// </summary>
        /// <param name="location">A number from the array</param>
        /// <returns>int[]</returns>
        public int[] Neighbors(int location)
        {
            return new int[] { TOP_LEFT(location), TOP(location), TOP_RIGHT(location), LEFT(location), RIGHT(location), BOTTOM_LEFT(location), BOTTOM(location), BOTTOM_RIGHT(location) };
        }

        /// <summary>
        /// Returns a [y, x] coordinate.
        /// </summary>
        /// <param name="number">A number from the array</param>
        /// <returns>int[]</returns>
        public int[] Find(int number)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (arrayOfNumbers[i, j] == number) return new int[] { i, j };
                }
            }

            return Array.Empty<int>();
        }

        /// <summary>
        /// Length of the array (eg.: 5x5 array's length = 25)
        /// </summary>
        public int Len
        {
            get
            {
                return arrayOfNumbers.Length;
            }
        }

        #region SIDES
        public int TOP_LEFT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] - 1, Find(location)[1] - 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
            
        }
        public int TOP(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] - 1, Find(location)[1]];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int TOP_RIGHT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] - 1, Find(location)[1] + 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int LEFT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0], Find(location)[1] - 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int RIGHT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0], Find(location)[1] + 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int BOTTOM_LEFT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] + 1, Find(location)[1] - 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int BOTTOM(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] + 1, Find(location)[1]];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int BOTTOM_RIGHT(int location)
        {
            try
            {
                return arrayOfNumbers[Find(location)[0] + 1, Find(location)[1] + 1];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        #endregion

        #region PRIVATE
        private void FillArray()
        {
            Random rnd = new Random();

            int rndNumber = 0;

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    while (true)
                    {
                        rndNumber = rnd.Next(1, Len + 1);
                        if (!Has(rndNumber)) break;
                    }

                    arrayOfNumbers[i, j] = rndNumber;
                }
            }

        }
        private bool Has(int value)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (arrayOfNumbers[i, j] == value) return true;
                }
            }

            return false;
        }
        #endregion
    }
}
