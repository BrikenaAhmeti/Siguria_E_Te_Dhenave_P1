

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESready
{
    public class DES
    {


        //Permutacioni fillestar  
        private int[] pf = new int[] { 58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,
                                       62,54,46,38,30,22,14,6,64,56,48,40,32,24,16,8,
                                       57,49,41,33,25,17,9,1,59,51,43,35,27,19,11,3,
                                       61,53,45,37,29,21,13,5,63,55,47,39,31,23,15,7 };
        

        //Permutacioni per komp
        private int[] komp = new int[] { 14,17,11,24,1,5,3,28,15,6,21,10,
                                        23,19,12,4,26,8,16,7,27,20,13,2,
                                        41,52,31,37,47,55,30,40,51,45,33,48,
                                        44,49,39,56,34,53,46,42,50,36,29,32 };
        
        //Permutacioni per zgjerim  
        private int[] zgj = new int[] { 32,1,2,3,4,5,4,5,6,7,8,9,
                                        8,9,10,11,12,13,12,13,14,15,16,17,
                                        16,17,18,19,20,21,20,21,22,23,24,25,
                                        24,25,26,27,28,29,28,29,30,31,32,1 };
        //S Box 
        private int[,] sbox = new int[8, 64] { { 14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7,
                                                0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8,
                                                4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0,
                                                15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13 },
                                              { 15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10,
                                                3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5,
                                                0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15,
                                                13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9 },
                                              { 10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8,
                                                13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1,
                                                13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7,
                                                1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12 },

                                              { 7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15,
                                                13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9,
                                                10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4,
                                                3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14 },
                                              { 2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9,
                                                14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6,
                                                4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14,
                                                11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3 },
                                              { 12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11,
                                                10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8,
                                                9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6,
                                                4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13 },
                                              { 4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1,
                                                13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6,
                                                1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2,
                                                6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12 },
                                              { 13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7,
                                                1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2,
                                                7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8,
                                                2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11 } };
        
         //P Box  
        private int[] pbox = new int[] { 16,7,20,21,29,12,28,17,1,15,23,26,5,18,31,10,
                                         2,8,24,14,32,27,3,9,19,13,30,6,22,11,4,25 };
        
        //Permutacioni final  
        private int[] fp = new int[] { 40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                                       38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                                       36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                                       34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25 };

        int[] plaintexti = new int[5000];
        char[] plainchar;
        int[] ciphertexti = new int[5000];
        char[] cipherchar;
        int[] celesi = new int[64];
        char[] celesichar;
        int[] plainblloku = new int[64];
        int[] cipherblloku = new int[64];
        int[] pbPerzier = new int[64];
        int[] cbPerzier = new int[64];
        int[] pbMajtas = new int[32];
        int[] pbDjathtas = new int[32];
        int[] cbMajtas = new int[32];
        int[] cbDjathtas = new int[32];
        int[] celesi56 = new int[56];
        int[] pbDtemp = new int[32];
        int[] pbMtemp = new int[32];
        int[] celesiComp = new int[48];
        int[] cbMzgj = new int[48];

        int[] pbDzgj = new int[48];
        int[] pDxor = new int[48];
        int[] pMxor = new int[48];
        int[] rreshti = new int[2];
        int rreshtiindex;
        int[] kolona = new int[4];
        int kolonaindex;
        int sboxvlera;
        int[] arrSboxTemp = new int[4];
        int[] pbDsbox = new int[32];
        int[] cbMsbox = new int[32];
        int[] cbMpbox = new int[32];
        int[] pbDpbox = new int[32];
        int[] pbKomplet = new int[64];
        int[] cbKomplet = new int[64];
        int[] pbFp = new int[64];
        int[] cbFp = new int[64];

            private int GetASCII(char ch)
            {
                int n = ch;

                
                return n;
            }

            private int TekstNeBita(char[] chararray, int[] savedarray)
            {
                int j = 0;
                for (int i = 0; i < chararray.Length; ++i)
                {
                    int[] ba = BitArray.ToBits(GetASCII(chararray[i]), 8);
                    j = i * 8;
                    vargu1TeVarguB(ba, savedarray, j);
                }

                return (j + 8);
            }

            private void vargu1TeVarguB(int[] array1, int[] array2, int fromIndex)
            {
                int x, y;
                for (x = 0, y = fromIndex; x < array1.Length; ++x, ++y)
                    array2[y] = array1[x];
            }

         private int ShtoZerot(int[] appendedarray, int len)
        {
            int zeroes;
            if (len % 64 != 0)
            {
                zeroes = (64 - (len % 64));

                for (int i = 0; i < zeroes; ++i)
                    appendedarray[len++] = 0;
            }
            return len;
        }

        private void LargimiBitit8()
        {
            for (int i = 0, j = 0; i < 64; i++)
            {
                if ((i + 1) % 8 == 0)
                    continue;
                celesi56[j++] = celesi[i];
            }
        }

        private void permutacioniFillestar(int[] sentarray, int[] savedarray)
        {
            int tmp;
            for (int i = 0; i < 64; i++)
            {
                tmp = pf[i];
                savedarray[i] = sentarray[tmp - 1];
            }
        }

        private void ndarjaBllokutNeLPTdheRPT(int[] sentarray, int[] savedLPT, int[] savedRPT)
        {
            for (int i = 0, k = 0; i < 32; i++, ++k)
            {
                savedLPT[k] = sentarray[i];
            }

            for (int i = 32, k = 0; i < 64; i++, ++k)
            {
                savedRPT[k] = sentarray[i];
            }
        }

        private void RuajtjaBllokutDjatht(int[] fromHPT, int[] toHPT)
        {
            for (int i = 0; i < 32; i++)
            {
                toHPT[i] = fromHPT[i];
            }
        }
        
        private void Kompresimi()
        {
            int temp;
            for (int i = 0; i < 48; i++)
            {
                temp = komp[i];
                celesiComp[i] = celesi56[temp - 1];
            }
        }

        private void Zgjerimi(int[] HPT, int[] ExpandedHPT)
        {
            int temp;
            for (int i = 0; i < 48; i++)
            {
                temp = zgj[i];
                ExpandedHPT[i] = HPT[temp - 1];
            }
        }
