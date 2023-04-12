using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class IntegerMultiplication
    {
        public static byte[] paddingZerosAtLeft(byte[] myfindSumOutPut, long N, long R)
        {
            byte[] a = new byte[N];
            long size_myfindSumOutPut = myfindSumOutPut.GetLength(0);
            byte[] e = myfindSumOutPut;
            long diff = N - size_myfindSumOutPut;
            long c = diff - R;

            long i = 0;
            //if (c < 0) { c = 0; }
            for (; i < size_myfindSumOutPut; i++)
            {
                if (c >= 0)
                {
                    a[c] = e[i];
                }

                c++;
            }
            return a;
        }
        public static byte[] paddingZerosAtLeft_int(long myfindSumOutPut, int N)
        {
            byte[] a = new byte[N];

            long e = myfindSumOutPut;
            for (int i = N - 1; i >= 0; i--)
            {
                a[i] = (byte)(e % 10);
                e = e / 10;
            }
            return a;
        }
        public static byte[] paddingZerosAtRight(long myfindSumOutPut, int N)
        {

            byte[] ar = new byte[N];
            long e = myfindSumOutPut;

            int ee = 1;
            if (ee > 0)
                ee = (int)Math.Floor(Math.Log10(e) + 1);
            if (ee < 0) { ee = ee * -1; }
            for (int i = ee - 1; i >= 0; i--)
            {
                ar[i] = (byte)(e % 10);
                e = e / 10;
            }
            return ar;
        }
        public static bool isSmaller(byte[] str1, byte[] str2)
        {//88  1079
            // Calculate lengths of both string
            int n1 = str1.GetLength(0), n2 = str2.GetLength(0);//2 4

            if (n1 < n2) //2<4? =true
                return true;
            if (n2 < n1) //4<2? false
                return false;

            for (int i = 0; i < n1; i++)
            {
                if (str1[i] < str2[i])
                    return true;
                else if (str1[i] > str2[i])
                    return false;
            }
            return false;
        }
        static byte[] findDiff(byte[] str1, byte[] str2)
        {
            // Before proceeding further,
            // make sure str1 is not smaller
            if (isSmaller(str1, str2))
            {
                byte[] t = str1.ToArray();
                str1 = str2.ToArray();
                str2 = t.ToArray();
            }

            // Take an empty string for
            // storing result
            //String str = "";
            byte[] str = new byte[Math.Max(str1.GetLength(0), str2.GetLength(0))];
            // Calculate lengths of both string
            int n1 = str1.Length, n2 = str2.Length;//after swap 4 2
            int diff = n1 - n2; //4-2 =2

            // Initially take carry zero
            int carryDiff = 0;

            // Traverse from end of both strings
            int c = 0;
            for (int i = n2 - 1; i >= 0; i--)//2-1=1  is 1>=0 ? yes
            {//i=0
                // Do school mathematics, compute
                // difference of current digits and carry
                int sub = (((int)str1[i + diff]) //str1[1+2]=9  //str1[0+2]=7
                           - ((int)str2[i]) - carryDiff);//str2[1]=8  carry=0 sub=9-8-0=1
                                                         //str2[0]=8  carry=0 sub=7-8-0=-1
                if (sub < 0)//2st iteration at i=0 sub is -1 (-)
                {
                    sub = sub + 10; //9  (keep in mind 17-8=9)
                    carryDiff = 1;
                }
                else
                    carryDiff = 0;//1st iteration at i=1 sub is 1(+)

                str[c] = (byte)sub;
                c++;
            }

            // subtract remaining digits of str1[]
            int cc = c;
            for (int i = n1 - n2 - 1; i >= 0; i--)
            {

                if ((str1[i] == 0) && carryDiff > 0)
                {
                    str[cc] = (byte)9;//all zeroz before num we borrow it is become 9
                    cc++;
                    continue;
                }                                   //str1[i] ) - carry = 1-1=0
                int sub = (((int)str1[i]) - carryDiff);//after borrow 1 from origin we subtract it 
                if (i > 0 || sub > 0) // remove preceding 0's
                    str[cc] = (byte)sub;
                carryDiff = 0;
                cc++;
            }

            // reverse resultant string
            /*
            byte[] ch2 = str.ToArray();
            Array.Reverse(ch2);
            */
            byte[] aa = str.ToArray();
            Array.Reverse(aa);
            return aa;
        }
        static byte[] findSum(byte[] str1, byte[] str2)
        {
            // Before proceeding further, make sure length
            // of str2 is larger.
            if (str1.GetLength(0) > str2.GetLength(0))
            {
                //Array1 = Array2.ToArray();
                byte[] t = str1.ToArray();
                str1 = str2.ToArray();
                str2 = t.ToArray();
            }

            // Take an empty string for storing result
            byte[] str = new byte[Math.Max(str1.GetLength(0), str2.GetLength(0))];
            byte[] strCopyPlusLastElement = new byte[1 + Math.Max(str1.GetLength(0), str2.GetLength(0))];
            // Calculate length of both string
            int n1 = str1.Length, n2 = str2.Length;
            int diff = n2 - n1;

            // Initially take carry zero
            long carry = 0;

            // Traverse from end of both strings
            int c = 0;
            for (int i = n1 - 1; i >= 0; i--)
            {                                   //        2
                // Do school mathematics, compute sum of  10
                // current digits and carry//////out > 2
                long sum = ((int)(str1[i]) +
                        (int)(str2[i + diff]) + carry);
                str[c] = (byte)((sum % 10));
                //str += 
                carry = sum / 10;
                c++;
            }

            // Add remaining digits of str2[]
            int cc = c; //1
            for (int i = n2 - n1 - 1; i >= 0; i--) //i=0
            {
                long sum = ((int)(str2[i]) + carry); //1+0  out >1
                str[cc] = (byte)((sum % 10));
                carry = sum / 10;
                cc++;
            }

            // Add remaining carry
            if (carry > 0)
            {
                for (int i = 0; i < Math.Max(str1.GetLength(0), str2.GetLength(0)); i++)
                { strCopyPlusLastElement[i] = str[i]; }
                //strCopyPlusLastElement = str.ToArray();
                strCopyPlusLastElement[Math.Max(str1.GetLength(0), str2.GetLength(0))] = (byte)((carry));
                //carry = 0;
            }


            // reverse resultant string
            byte[] ch2 = str.ToArray();
            Array.Reverse(ch2);
            byte[] ch3 = strCopyPlusLastElement.ToArray();
            Array.Reverse(ch3);
            if (carry > 0) { return ch3; }
            return ch2;
            //return ch2;//new byte(ch2);
        }
        static public byte[] rMultiply(byte[] X, byte[] Y, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            int sizeOfX = X.GetLength(0);
            int sizeOfY = Y.GetLength(0);
            if (sizeOfX == 1 || sizeOfY == 1)
            {
                if (X.GetLength(0) == 2)
                {
                    string combinedNum = X[0].ToString() + X[1].ToString();
                    X[0] = byte.Parse(combinedNum);
                }
                if (Y.GetLength(0) == 2)
                {
                    string combinedNum2 = Y[0].ToString() + Y[1].ToString();
                    Y[0] = byte.Parse(combinedNum2);
                }



                long num = (int)(X[0] * Y[0]); //5*9=45 >> 45%10=5 45/10=4

                int ee = 1;
                if (num != 0)
                    ee = (int)Math.Floor(Math.Log10(num) + 1);


                byte[] myReturn = new byte[ee];



                //ممكن اعكس اللوب عشان حوار الريفيرس بتاع البايت ارراى من الدكتور
                for (int i = ee - 1; i >= 0; i--)
                {
                    myReturn[i] = (byte)(num % 10);//2 [0]0 [1]2  >> 27  [0]2 [1]7
                    num = num / 10;
                }


                return myReturn;
            }
            else
            {


                // byte[] arr1 = { 1, 0, 0, 4, 2, 0 };
                N = X.GetLength(0);
                byte[] b = new byte[N / 2];
                byte[] a = new byte[N / 2];
                byte[] d = new byte[N / 2];
                byte[] c = new byte[N / 2];


                X = X;
                Y = Y;
                N = N;


                //string a = "", b = "", c = "", d = "";
                int halfOfArrayX = X.GetLength(0) / 2;
                int halfOfArrayY = Y.GetLength(0) / 2;
                int j = halfOfArrayX;
                int jj = halfOfArrayY;
                //int k = halfOfArrayY;
                //for Large int X , Y
                // string str_b = "";
                // string str_a = "";
                // string str_d = "";
                //string str_c = "";
                for (int i = 0; i < halfOfArrayX;)
                {
                    b[i] = X[i];
                    //  str_b = str_b + X[i].ToString();
                    a[i] = X[j];
                    //  str_a = str_a + X[j].ToString();
                    d[i] = Y[i];
                    //  str_d = str_d + Y[i].ToString();
                    c[i] = Y[j];
                    //  d[i] = Y[i];
                    //  str_d = str_d + Y[i].ToString();
                    //  if (halfOfArrayX == j) { c[i] = Y[jj]; }
                    //  else
                    //  c[i] = Y[j];
                    /*
                    try
                    {
                        c[i] = Y[j];
                    }
                    catch (Exception e)
                    {
                        //j = j - 1;
                        //int avoidExc = j / 2;
                        //c[i] = Y[avoidExc];
                        if (halfOfArrayX != j) { c[i] = Y[j-halfOfArrayX]; }
                        if (halfOfArrayX == j) { c[i] = Y[jj]; }
                        
                    }
                    */
                    //  str_c = str_c + Y[j].ToString();
                    i++;
                    j++;
                    //jj++;
                }
                /*
                for (int i = 0; i < halfOfArrayY;)
                {

                    d[i] = Y[i];
                    //  str_d = str_d + Y[i].ToString();
                    c[i] = Y[j];
                    //if (halfOfArrayX == j) { c[i] = Y[jj]; }
                    //else
                    //c[i] = Y[j];

                    i++;
                    j++;
                    //jj++;
                }
                */
                /*
                 ac>>padding zeros at left
                bd>>padding zeros as N at right 
                temp>> padding zeros as N/2 at right
                */

                byte[] bd = rMultiply(b, d, N / 2);
                byte[] MyfindSum_cd = findSum(c, d);
                byte[] MyfindSum_ab = findSum(a, b);
                if ( (MyfindSum_ab.GetLength(0) % 2 != 0 && MyfindSum_ab.GetLength(0) > 1) || (MyfindSum_cd.GetLength(0) % 2 != 0 && MyfindSum_cd.GetLength(0) > 1) )
                {
                    MyfindSum_cd = paddingZerosAtLeft(MyfindSum_cd, N, 0);
                
                    MyfindSum_ab = paddingZerosAtLeft(MyfindSum_ab, N, 0);
                }
                byte[] temp = rMultiply(MyfindSum_ab, MyfindSum_cd, N / 2);
                byte[] ac = rMultiply(a, c, N / 2);
                string combined_bd = "";
                string combined_temp = "";
                string combined_ac = "";
                for (int i = 0; i < bd.GetLength(0); i++)
                {
                    combined_bd = combined_bd + bd[i].ToString();
                }
                for (int i = 0; i < ac.GetLength(0); i++)
                {
                    combined_ac = combined_ac + ac[i].ToString();
                }
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    combined_temp = combined_temp + temp[i].ToString();
                }
                //لما كانت int.Parse رجعلى ان الرقم كبير جدا عليه اعتقد 
                //ف اعتقد هيضرب اكسبشن ان الرقم كبير جدا لو الداتا تايب زى انتجر ا لونج ميستحملهوش
                //لذلك حولته ل لونج دلوقتى عشان اشوف بس التيست كيسز

                long bd_int = long.Parse(combined_bd);//02
                long temp_int = long.Parse(combined_temp);//50
                long ac_int = long.Parse(combined_ac);//27
                /*
                long z;
                z = (long)Math.Abs(Math.Abs( temp_int -ac_int) - bd_int);
                z = z *(long) Math.Pow(10, N/2);
                 */
                byte[] z = findDiff(findDiff(temp, ac), bd);
                //bd_int = bd_int * (long)Math.Pow(10, N);


                ac = paddingZerosAtLeft(ac, 2 * N, 0);
                bd = paddingZerosAtLeft(bd, 2 * N, N);
                temp = paddingZerosAtLeft(z, 2 * N, N / 2);
                //temp = paddingZerosAtLeft_int(z, N/2);

                // for (int k = 0; k < temp.GetLength(0) + (N / 2); k++)//4/2=2
                // { 

                // }

                //مش عارف اخلى 3 ديناميك ف الفنكشن 
                //طب لو ال 3 بقت اربعة المفروض يخلى عدد الديجيت 4 يعنى يحط صفر ع الشمال ولكن مش هيعمل
                // لسة عايز احول ال زد ل بايت ارراى
                //byte division_temp = (byte)(z / 10);
                //byte  carry_temp = (byte)(z % 10);
                //temp[0] = division_temp; temp[1] = carry_temp;  
                //       ([0]>0 [1]>2 ,[0]>4 [1]>8) = 
                //                      [0]>5 [1]>0
                byte[] myOutput = findSum(bd, (findSum(temp, ac)));
                //2    bd[3]
                // 21  temp
                //  27 ac[3]
                /*
                bd      >> 2000
                temp=z=21>>2100
                ac>>       0027
                ---------------
                           4127
                    */
                //byte[] zzz = { 0 };
                return myOutput;
            }


        }
        static public byte[] IntegerMultiply(byte[] X, byte[] Y, int N)
        {
            Array.Reverse(X);
            Array.Reverse(Y);

            byte[] dddddd = rMultiply(X, Y,N);
            Array.Reverse(dddddd);
            return dddddd;
        }
        //x[65536] .. x[65543]=6 3 3 2 3 5 4 >> a
        //y[65536] .. y[65543]=2 5 2 9 1 6 9 >> c

        //#endregion
    }
}
