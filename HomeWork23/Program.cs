using System;

namespace HomeWork23
{
    class Program
    {
        public static double ToDouble(string str)
        {
            double chislo = 0;
            int i = 0; //вспомогательный индекс для просмотра элементов строки в циклах
            int namberOfDelimiters = 0; //количество точек и запятых в строке
            int numberOfDecimal = 0; //количество цифр дробной части
            bool negativeNumber = false; //флаг для проверки наличия знака "-" в строке, false - положительное число, true - отрицательное
            int kodSimbol;
            
            //Проверка наличия разделителя (точки или запятой) в строке
            while(i < str.Length && namberOfDelimiters <= 1)
            {
                if(str[i] == '.' || str[i] == ',') namberOfDelimiters++; //количество разделителей в строке
                if (namberOfDelimiters == 1 && str[i] != '.' && str[i] != ',') numberOfDecimal++; //количество цифр дробной части
                    i++;
            }

            //Если в строке разделителей больше одного - выход из метода, возврат 0
            if (namberOfDelimiters > 1)
            {
                Console.WriteLine("Число некорректно");
                return 0;
            }

            i = 0; 
            
            //Проверка наличия знака "-" в начале строки
            if (str[0] == '-')
            {
                negativeNumber = true; //число отрицательное
                i = 1;
            }
            
            //При наличии знака "+" в начале строки - переход к следующему элементу
            if (str[0] == '+') i = 1;

            //Цикл преобразования элементов строки в цифры
            while(i < str.Length)
            {
                kodSimbol = str[i] & 0x0F;
                if (kodSimbol >= 0 && kodSimbol <= 9)
                {
                    chislo = chislo + kodSimbol;
                    chislo = chislo * 10;
                }
                else
                {
                    if (str[i] != '.' && str[i] != ',') //Если в строке есть символы отличные от цифр или разделителей - выход из цикла, возврат 0
                    {
                        Console.WriteLine("Число некорректно");
                        return 0;
                    }
                }
                i++;
            }
            
            if (negativeNumber) chislo = (-1) * chislo; //Если в начале строки "-" - умножение числа на "-1"
            Console.WriteLine(chislo * (Math.Pow(10, (-1)*numberOfDecimal)) / 10); //Вывод числа
            return chislo * (Math.Pow(10, (-1)*numberOfDecimal) / 10); //Возврат числа
        }
        
        static void Main(string[] args)
        {
            Console.Write("Введите вещественное число (разделитель - точка): "); string str = Console.ReadLine();
            ToDouble(str);
        }
    }
}
