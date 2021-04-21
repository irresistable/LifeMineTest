using System;



namespace lIFE

{

    class Program

    {

        static void Main(string[] args)

        {

            //field options here

            int length = 230; //

            int height = 30;

            int initial_random_points = 500;

            bool[,] lifeField = new bool[length, height];

            bool[] genome = new bool[9];

            int cellCount = 0;

            ConsoleKeyInfo cont;

            int left, right, top, bottom;

            int population = 0;

            int timer = 0;



            //Random field fill

            Random rnd = new Random();

            for (int i = 0; i < initial_random_points; i++)

            {

                lifeField[rnd.Next(0, length), rnd.Next(0, height)] = true;

            }



            //manual cell programm

            //lifeField[0, 0] = true;

            //lifeField[0, 1] = true;

            //lifeField[0, 2] = true;



            //Printout field fill

            for (int i = 0; i < height; i++)

            {

                for (int j = 0; j < length; j++)

                {

                    if (lifeField[j, i])

                        Console.Write("O");

                    else

                    {

                        Console.Write("-");

                    }

                }

                Console.WriteLine("\n");

            }



            //Here we start

            for (; ; )

            //do



            {

                for (int i = 0; i < height; i++)

                {

                    for (int j = 0; j < length; j++)

                    {

                        left = j - 1;

                        right = j + 1;

                        top = i - 1;

                        bottom = i + 1;



                        if (j == 0)

                        {

                            left = length - 1;

                        }

                        if (j == length - 1)

                        {

                            right = 0;

                        }



                        if (i == 0)

                        {

                            top = height - 1;

                        }



                        if (i == height - 1)

                        {

                            bottom = 0;

                        }



                        genome[0] = lifeField[j, i];

                        genome[1] = lifeField[left, top];

                        genome[2] = lifeField[j, top];

                        genome[3] = lifeField[right, top];

                        genome[4] = lifeField[right, i];

                        genome[5] = lifeField[right, bottom];

                        genome[6] = lifeField[j, bottom];

                        genome[7] = lifeField[left, bottom];

                        genome[8] = lifeField[left, i];



                        if (genome[0]) //клетка в центре жива

                        {

                            cellCount = 0;

                            for (int genomeCircle = 1; genomeCircle < 9; genomeCircle++)

                            {

                                if (genome[genomeCircle])

                                    cellCount++;

                            }



                            if (cellCount < 2 || cellCount > 3) //если соседей 1 или больше 4

                            {

                                genome[0] = false; // клетка умирает

                            }

                            else

                            {

                                genome[0] = true; // клетка живет

                            }

                        }

                        else //клетка в центре мертва

                        {

                            cellCount = 0;

                            for (int genomeCircle = 1; genomeCircle < 9; genomeCircle++)

                            {

                                if (genome[genomeCircle])

                                    cellCount++;

                            }



                            if (cellCount == 3)

                            {

                                genome[0] = true; // клетка живет

                            }

                        }



                        lifeField[j, i] = genome[0];

                        lifeField[left, top] = genome[1];

                        lifeField[j, top] = genome[2];

                        lifeField[right, top] = genome[3];

                        lifeField[right, i] = genome[4];

                        lifeField[right, bottom] = genome[5];

                        lifeField[j, bottom] = genome[6];

                        lifeField[left, bottom] = genome[7];

                        lifeField[left, i] = genome[8];



                    } //закрываем цикл по горизонтали

                } //закрываем цикл по вертикали



                //population count







                //итерация кончилась

                //cont = Console.ReadKey();

                Console.SetCursorPosition(0, 0);





                //Printout field fill

                for (int i = 0; i < height; i++)

                {

                    for (int j = 0; j < length; j++)

                    {

                        if (lifeField[j, i])

                            Console.Write("О");

                        else

                        {

                            Console.Write("-");

                        }

                    }

                    Console.WriteLine("\n");

                }



                population = 0;

                for (int k = 0; k < height; k++)

                {

                    for (int m = 0; m < length; m++)

                    {

                        if (lifeField[m, k])

                            population++;

                    }

                }

                timer++;



                Console.WriteLine();

                Console.WriteLine($"time: {timer}, population: {population}");



                System.Threading.Thread.Sleep(100);

            }

            //while (cont.Key != ConsoleKey.Escape);



        }

    }



    //    PublicClass MyArray

    //    Private int[] _array = new int[5];

    //    //индексатор –

    //    Public int this[int index]

    //    Get { return _array[index]};

    //Set { _array[index] = value};



}