using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lw._8._13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        Random rnd = new Random();

        int[,] MassRabbit = new int[1000, 6]; //выделение массива под хранение данных о кроликах
        int[,] MassWolf = new int[500, 9]; //выделение массива под хранение данных о волках
        double[]MassWolfPoints= new double[500]; // выделение массива для хранения очков волков

        int RndX; //объявление переменных
        int RndY;

        int k = 0;

        int RabbitCount;
        int WolfCount;
        private void button2_Click(object sender, EventArgs e) //распределение
        {
            if (k == 0) // проверка: Не нажимали ли на кнопку больше 1 раза?
            {
                k++;

                //создание поля 20х20 клеток
                dataGridView1.RowCount = 20;
                dataGridView1.ColumnCount = 20;

                //присваивание наального количества существ
                RabbitCount = int.Parse(textBox1.Text);
                WolfCount = int.Parse(textBox2.Text);

                int CurrentCount = 1;
                while (CurrentCount <= RabbitCount)
                {
                    RndX = rnd.Next(0, 20);
                    RndY = rnd.Next(0, 20);
                    //MassRabbit[CurrentCount, 0] = 0; //тип
                    MassRabbit[CurrentCount, 1] = RndX;
                    MassRabbit[CurrentCount, 2] = RndY;
                    MassRabbit[CurrentCount, 3] = 1; //статус - жив
                    MassRabbit[CurrentCount, 4] = 0; // действий не совершал
                    dataGridView1.Rows[RndX].Cells[RndY].Value = "r".ToString();
                    CurrentCount++;
                }
                CurrentCount = 1;
                while (CurrentCount <= WolfCount)
                {
                    RndX = rnd.Next(0, 20);
                    RndY = rnd.Next(0, 20);
                   //MassWolf[CurrentCount, 0] = 1;// тип: 0-кролик, 1-волк
                    MassWolf[CurrentCount, 1] = RndX; // х-координата
                    MassWolf[CurrentCount, 2] = RndY;//у-координата
                    MassWolf[CurrentCount, 3] = 1; //статус - жив
                    MassWolf[CurrentCount, 4] = 0; // действий не совершал
                    MassWolf[CurrentCount, 5] = rnd.Next(0,1); // пол:0-самец, 1 - самка.
                    MassWolf[CurrentCount, 6] = 0; // перерыв

                    MassWolfPoints[CurrentCount] = 1; // текущее количество очков.
                    dataGridView1.Rows[RndX].Cells[RndY].Value = "W".ToString();
                    CurrentCount++;
                }

            }
        }

        int RabbitMove(int EntityNumber, int x, int y) //функция перемещения кролика
        {
            Random rnd = new Random();
            int RndСoordinates = rnd.Next(1, 9); //направление передвижения выбирается случайным образом
            if (RndСoordinates == 1 && x-1>=0 && y-1>=0)   //проверка на существование такой координаты, в случае успеха запеняет старую позицию новой
            {
                MassRabbit[EntityNumber, 1]=x-1;
                MassRabbit[EntityNumber, 2]=y-1;
            }
            if (RndСoordinates == 2 && y - 1 >= 0)
            {
                MassRabbit[EntityNumber, 2] = y - 1;
            }
            if (RndСoordinates == 3 && x + 1 < 20 && y - 1 >= 0)
            {
                MassRabbit[EntityNumber, 1] = x + 1;
                MassRabbit[EntityNumber, 2] = y - 1;
            }
            if (RndСoordinates == 4 && x - 1 >= 0)
            {
                MassRabbit[EntityNumber, 1] = x - 1;
            }
            if (RndСoordinates == 5)
            {
                MassRabbit[EntityNumber, 1] = x;
                MassRabbit[EntityNumber, 2] = y;
            }
            if (RndСoordinates == 6 && x + 1 < 20)
            {
                MassRabbit[EntityNumber, 1] = x + 1;
            }
            if (RndСoordinates == 7 && x - 1 >= 0 && y + 1 < 20)
            {
                MassRabbit[EntityNumber, 1] = x - 1;
                MassRabbit[EntityNumber, 2] = y + 1;
            }
            if (RndСoordinates == 8 && y + 1 < 20)
            {
                MassRabbit[EntityNumber, 2] = y + 1;
            }
            if (RndСoordinates == 9 && x + 1 < 20 && y + 1 < 20)
            {
                MassRabbit[EntityNumber, 1] = x + 1;
                MassRabbit[EntityNumber, 2] = y + 1;
            }
            return 0;
        }

        int WolfMove(int EntityNumber, int x, int y) //функция перемещения волка
        {
            Random rnd = new Random();
            int RndСoordinates = rnd.Next(1, 9); //направление передвижения выбирается случайным образом
            if (RndСoordinates == 1 && x - 1 >= 0 && y - 1 >= 0)   //проверка на существование такой координаты, в случае успеха запеняет старую позицию новой
            {
                MassWolf[EntityNumber, 1] = x - 1;
                MassWolf[EntityNumber, 2] = y - 1;
            }
            if (RndСoordinates == 2 && y - 1 >= 0)
            {
                MassWolf[EntityNumber, 2] = y - 1;
            }
            if (RndСoordinates == 3 && x + 1 < 20 && y - 1 >= 0)
            {
                MassWolf[EntityNumber, 1] = x + 1;
                MassWolf[EntityNumber, 2] = y - 1;
            }
            if (RndСoordinates == 4 && x - 1 >= 0)
            {
                MassWolf[EntityNumber, 1] = x - 1;
            }
            if (RndСoordinates == 5)
            {
                MassWolf[EntityNumber, 1] = x;
                MassWolf[EntityNumber, 2] = y;
            }
            if (RndСoordinates == 6 && x + 1 < 20)
            {
                MassWolf[EntityNumber, 1] = x + 1;
            }
            if (RndСoordinates == 7 && x - 1 >= 0 && y + 1 < 20)
            {
                MassWolf[EntityNumber, 1] = x - 1;
                MassWolf[EntityNumber, 2] = y + 1;
            }
            if (RndСoordinates == 8 && y + 1 < 20)
            {
                MassWolf[EntityNumber, 2] = y + 1;
            }
            if (RndСoordinates == 9 && x + 1 < 20 && y + 1 < 20)
            {
                MassWolf[EntityNumber, 1] = x + 1;
                MassWolf[EntityNumber, 2] = y + 1;
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e) //Следубщий цикл
        {
            int CurrentCount = 1;
            int Current = 0;
            while (CurrentCount <= RabbitCount) //перебор всех кролико основываясь на их количестве
            {
                if (MassRabbit[CurrentCount, 4] != 0 ) // если кролик выполнял в этом цикле ход
                {
                    CurrentCount++;
                }
                else

                if (MassRabbit[CurrentCount,3]==1) //если кролик жив
                {
                    //textBox4.Text = MassRabbit[CurrentCount, 3].ToString();
                    dataGridView1.Rows[MassRabbit[CurrentCount, 1]].Cells[MassRabbit[CurrentCount, 2]].Value = "".ToString(); //стрирается старое местоположение кролика на поле

                    RabbitMove(CurrentCount, MassRabbit[CurrentCount, 1], MassRabbit[CurrentCount, 2]); //вызов функции перемещения. Передаётся текущий номер кролика в массиве данных, а так же его х- и у-координаты

                    dataGridView1.Rows[MassRabbit[CurrentCount, 1]].Cells[MassRabbit[CurrentCount, 2]].Value = "r".ToString(); //отрисовывается новое положение кролика на поле

                    int Chance = rnd.Next(1, 5);
                    if (Chance == 1) //установка шанса вызова следующей функции в 20%
                    {
                        Current = 1;  //сброс  счётчика
                        while (Current <= RabbitCount + 1) //выполнять до тех пор пока количество записей о кроликах в массиве не будет совпадать с числом кроликов
                        {
                            if (MassRabbit[Current, 3] != 1) //проверяет состояние кролика. Если кролик умер - новорождённый записывается на его место
                            {
                                MassRabbit[Current, 3] = 1; //присваивает статус кролику "Живой"
                                MassRabbit[Current, 1] = MassRabbit[CurrentCount, 1]; //присваивает новорождённому кролику х-координату
                                MassRabbit[Current, 2] = MassRabbit[CurrentCount, 2];//присваивает новорождённому кролику у-координату
                                RabbitCount++;

                                break;
                            }
                            else
                                Current++;
                        }
                    }
                }


                CurrentCount++;
                textBox3.Text = RabbitCount.ToString();
                /*
                int kol = 0;
                for (int i = 0; i < 500; i++)
                    if (MassRabbit[i, 3] != 1)
                        kol++;
                textBox4.Text = kol.ToString();
                */
            }
            CurrentCount = 1;
            Current= 0;
            while (CurrentCount <= WolfCount) //перебор всех волков основываясь на их количестве
            {

                MassWolf[CurrentCount, 4] = 0;

                int j = 1;
                while (j < RabbitCount) // цикл на проверку есть ли вокруг волка кролик
               //for (j=0; j<500; j++)
                {
                    if (MassRabbit[j, 3] == 1)
                    {
                       // j++;
                        for (int i = 1; i <= 9; i++)
                        {
                            int x = MassWolf[CurrentCount, 1];
                            int y = MassWolf[CurrentCount, 2];

                            if (i == 5 && MassRabbit[j, 1] == x && MassRabbit[j, 2] == y)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x;
                                MassWolf[CurrentCount, 2] = y;
                                MassRabbit[j, 3] = 0;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolfPoints[CurrentCount] += 1;
                                MassWolf[CurrentCount, 4]++;

                            }
                            else

                            if (i == 1 && x - 1 >= 0 && y - 1 >= 0 && MassRabbit[j, 1] == x - 1 && MassRabbit[j, 2] == y - 1)   
                                //проверка на существование такой координаты, в случае успеха запеняет старую позицию новой
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x - 1;
                                MassWolf[CurrentCount, 2] = y - 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 2 && y - 1 >= 0 && MassRabbit[j, 1] == x && MassRabbit[j, 2] == y - 1)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 2] = y - 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 3 && x + 1 < 20 && y - 1 >= 0 && MassRabbit[j, 1] == x + 1 && MassRabbit[j, 2] == y - 1)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x + 1;
                                MassWolf[CurrentCount, 2] = y - 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 4 && x - 1 >= 0 && MassRabbit[j, 1] == x - 1 && MassRabbit[j, 2] == y)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x - 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 6 && x + 1 < 20 && MassRabbit[j, 1] == x + 1 && MassRabbit[j, 2] == y)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x + 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 7 && x - 1 >= 0 && y + 1 < 20 && MassRabbit[j, 1] == x - 1 && MassRabbit[j, 2] == y + 1)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x - 1;
                                MassWolf[CurrentCount, 2] = y + 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 8 && y + 1 < 20 && MassRabbit[j, 1] == x && MassRabbit[j, 2] == y + 1)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 2] = y + 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                            else

                            if (i == 9 && x + 1 < 20 && y + 1 < 20 && MassRabbit[j, 1] == x + 1 && MassRabbit[j, 2] == y + 1)
                            {
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString();
                                MassWolf[CurrentCount, 1] = x + 1;
                                MassWolf[CurrentCount, 2] = y + 1;
                                MassRabbit[j, 3] = 0;
                                MassWolfPoints[CurrentCount] += 1;
                                dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString();
                                RabbitCount--;
                                MassWolf[CurrentCount, 4]++;
                            }
                        }
                    }
                }

                if (MassWolf[CurrentCount, 3] == 1) // если жив               
                {
                    if (MassWolf[CurrentCount, 4] == 0) //если действий не совершал
                    {
                        if (MassWolf[CurrentCount, 5] == 0)// если самец
                        {
                            if (MassWolf[CurrentCount, 6] == 0)//если перерыв окончен
                            {
                                if (MassWolfPoints[CurrentCount] > 0.1)// если текущих очков >0.1
                                {
                                    for (int i = 0; i <= 9; i++)
                                    {
                                        int x = MassWolf[CurrentCount, 1];
                                        int y = MassWolf[CurrentCount, 2];
                                        int Num = 0;
                                        while (Num < WolfCount)
                                        {
                                            int Wx = MassWolf[Num, 1];
                                            int Wy = MassWolf[Num, 2];
                                            int act = 0;

                                            if (MassWolf[Num, 5] == 1 && MassWolf[Num, 3] == 1 && MassWolf[Num, 6] == 0)//если самка,если жива, если нет перерыва
                                            {

                                                if (i == 1 && x - 1 >= 0 && y - 1 >= 0 && x - 1 == Wx && y - 1 == Wy)   //проверка на существование самки в соседних координатах, в случае успеха запеняет старую позицию новой
                                                {
                                                    MassWolf[CurrentCount, 1] = x - 1;
                                                    MassWolf[CurrentCount, 2] = y - 1;
                                                    act++;
                                                }
                                                if (i == 2 && y - 1 >= 0 && x == Wx && y - 1 == Wy)
                                                {
                                                    MassWolf[CurrentCount, 2] = y - 1;
                                                    act++;
                                                }
                                                if (i == 3 && x + 1 < 20 && y - 1 >= 0 && x + 1 == Wx && y - 1 == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x + 1;
                                                    MassWolf[CurrentCount, 2] = y - 1;
                                                    act++;
                                                }
                                                if (i == 4 && x - 1 >= 0 && x - 1 == Wx && y == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x - 1;
                                                    act++;
                                                }
                                                if (i == 5 && x == Wx && y == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x;
                                                    MassWolf[CurrentCount, 2] = y;
                                                    act++;

                                                }
                                                if (i == 6 && x + 1 < 20 && x + 1 == Wx && y == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x + 1;
                                                    act++;
                                                }
                                                if (i == 7 && x - 1 >= 0 && y + 1 < 20 && x - 1 == Wx && y + 1 == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x - 1;
                                                    MassWolf[CurrentCount, 2] = y + 1;
                                                    act++;
                                                }
                                                if (i == 8 && y + 1 < 20 && x == Wx && y + 1 == Wy)
                                                {
                                                    MassWolf[CurrentCount, 2] = y + 1;
                                                    act++;
                                                }
                                                if (i == 9 && x + 1 < 20 && y + 1 < 20 && x + 1 == Wx && y + 1 == Wy)
                                                {
                                                    MassWolf[CurrentCount, 1] = x + 1;
                                                    MassWolf[CurrentCount, 2] = y + 1;
                                                    act++;
                                                }


                                                if (act != 0)
                                                {
                                                    int CurrentCh = 0;

                                                    while (CurrentCh <= WolfCount + 1) //выполнять до тех пор пока количество записей о волках в массиве не будет совпадать с числом волков
                                                    {
                                                        if (MassWolf[CurrentCh, 3] != 1) //проверяет состояние волк. Если кролик умер - новорождённый записывается на его место
                                                        {
                                                            MassWolf[CurrentCh, 3] = 1; //присваивает статус волку "Живой"
                                                            MassWolf[CurrentCh, 1] = MassWolf[CurrentCount, 1]; //присваивает новорождённому волку х-координату
                                                            MassWolf[CurrentCh, 2] = MassWolf[CurrentCount, 2];//присваивает новорождённому волку у-координату
                                                            WolfCount++;

                                                            MassWolfPoints[CurrentCh] = 1;//начальное значение очков
                                                            MassWolf[CurrentCh, 6] = 6; //перерыв от размножения на 6 ходов 
                                                            MassWolf[CurrentCount, 6] = 4; //перерыв для самца от размножения на 6 ходов 
                                                            MassWolf[Num, 6] = 4;//перерыв для скамки от размножения на 6 ходов 

                                                            MassWolfPoints[CurrentCount] -= 0.1;//отнимаем очки за перемещение к самке


                                                            MassWolf[CurrentCount, 4] = 1; //волки в этом цикле совершали ход
                                                            MassWolf[CurrentCh, 4] = 1;
                                                            MassWolf[Num, 4] = 1;

                                                            break;
                                                        }
                                                        else
                                                            CurrentCh++;
                                                    }
                                                }
                                                Num++;
                                            }
                                        }
                                    }
                                }

                                else
                                {
                                    MassWolf[CurrentCount, 3] = 0;
                                    WolfCount--;
                                    dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString(); //стрирается старое местоположение кролика на поле
                                }
                            }
                        }
                    }
                    CurrentCount++;
                }
                else

                if (MassWolf[CurrentCount, 3] == 1) // если жив
                {
                    if (MassWolf[CurrentCount, 4] == 0) // если волк не выполнял в этом цикле ход
                    {
                        dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "".ToString(); //стрирается старое местоположение кролика на поле

                        WolfMove(CurrentCount, MassWolf[CurrentCount, 1], MassWolf[CurrentCount, 2]); //вызов функции перемещения. Передаётся текущий номер кролика в массиве данных, а так же его х- и у-координаты

                        dataGridView1.Rows[MassWolf[CurrentCount, 1]].Cells[MassWolf[CurrentCount, 2]].Value = "W".ToString(); //отрисовывается новое положение кролика на поле

                        MassWolfPoints[CurrentCount] -= 0.1;
                        if (MassWolf[CurrentCount, 6] > 0)//уменьшает количество циклов на перерыв
                        {
                            MassWolf[CurrentCount, 6] -= 1;
                        }
                    }
                    CurrentCount++;
                }
               
            }
        }
    }
}
