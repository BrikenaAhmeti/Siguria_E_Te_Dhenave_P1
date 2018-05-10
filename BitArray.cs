using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESready
{
    public class BitArray
    {
        public static int[] ToBits(int decimalnumber, int numberofbits)
        {
            int[] bitarray = new int[numberofbits];
            int k = numberofbits - 1;
            char[] bd = Convert.ToString(decimalnumber, 2).ToCharArray();

            for (int i = bd.Length - 1; i >= 0; --i, --k)
            {
                if (bd[i] == '1')
                    bitarray[k] = 1;
                else
                    bitarray[k] = 0;
            }

            while (k >= 0)
            {
                bitarray[k] = 0;
                --k;
            }

            return bitarray;
        }
