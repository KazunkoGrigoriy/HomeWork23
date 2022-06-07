using System;

namespace HomeWork23
{
    class Program
    {
        public static double ToDouble(string str)
        {
            double chislo = 0;
            int i = 0;
            int k = 0;
            int j = 0;
            bool f = false;
            for(i = 0; i < str.Length; i++)
            {
                if(str[i] == '.') k++;
                if (k == 1) j++;
            }

            if (k > 1) return 0;

            i = 0;
            if (str[0] == '-')
            {
                f = true;
                i = 1;
            }
            if (str[0] == '+') i = 1;

            for (i = 0; i < str.Length; i++)
            {
                if (str[i] >= 0x30 && str[i] <= 0x39)
                {
                    chislo = chislo + (str[i] & 0x0F);
                    chislo = chislo * 10;
                }
                else
                if (str[i] != '.')
                {
                    Console.WriteLine("Строка содержит символы отличные от цифр и точки");
                    return 0;
                }
            }
            if (i == str.Length)
            {
                if (f) chislo = (-1) * chislo;
                Console.WriteLine(chislo * (Math.Pow(10, (-1)*(j-1)))/10);
                return chislo * (Math.Pow(10, (-1) * (j - 1))) / 10;
            }
            else
            {
                return 0;
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("Введите вещественное число (разделитель - точка): "); string str = Console.ReadLine();
            ToDouble(str);
        }
    }
}
