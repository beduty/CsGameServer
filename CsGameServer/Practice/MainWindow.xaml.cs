using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Swap(ref int a , ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            int num1 = 10, num2 = 20; ;
            Swap(ref num1, ref num2);
            string strLog = $"Swap => num1 : {num1}, num2 : {num2}";
            lstLog.Items.Add(strLog);
        }


        void Divide(int a, int b, out int res1, out int res2)
        {
            res1 = a / b;
            res2 = a % b;
        }

        private void button_Click_OutDivide(object sender, RoutedEventArgs e)
        {
            int num1 = 10, num2 = 3 ;
            int ret1, ret2;
            Divide(num1, num2, out ret1, out ret2);

            string strLog = $"Divide => {num1} / {num2} = {ret1}  || {num1} % {num2} = {ret2} ";
            lstLog.Items.Add(strLog);
        }

        class Knight
        {
            public int hp;
            public int attack;
            public void Move(out string strLog)
            {
                strLog = "Knight Move";
            }
            public void Attack(out string strLog)
            {
                strLog = "Knight Attack";
            }
        }

        private void btnClass_Click(object sender, RoutedEventArgs e)
        {
            Knight knight = new Knight();
            knight.hp = 200;
            knight.attack = 10;
            
            string strRet;
            knight.Attack(out strRet);
            lstLog.Items.Add(strRet);

            knight.Move(out strRet);
            lstLog.Items.Add(strRet);
        }

        // 복사
        struct Mage
        {
            public int hp;
            public int attack;
        }
        void KillMage(Mage mage)
        {
            mage.hp = 0;
        }

        // 참조
        class Warrior
        {
            public int hp;
            public int attack;
        }
        void KillWarrior(Warrior warrior)
        {
            warrior.hp = 0;
        }

        private void btnClassStruct_Click(object sender, RoutedEventArgs e)
        {
            // 구조체 
            Mage mage;// new 안해도 된다. 
            mage.hp = 100;
            mage.attack = 10;
            KillMage(mage);
            string strRet1 = $"Mage HP : {mage.hp}";
            lstLog.Items.Add(strRet1);

            // 클래스 
            Warrior warrior = new Warrior();
            warrior.hp = 100;
            warrior.attack = 10;
            KillWarrior(warrior);
            string strRet2 = $"Warrior HP : {warrior.hp}";
            lstLog.Items.Add(strRet2);


            Warrior warrior1 = new Warrior();
            Warrior warrior2 = warrior1;
            KillWarrior(warrior1);
            string strRet = $"warrior2 HP : {warrior2.hp}";
            lstLog.Items.Add(strRet);
        }

        class Thief
        {
            public int hp;
            public int attack;
            public Thief Clone()
            {
                Thief thief = new Thief();
                thief.hp = this.hp;
                thief.attack = this.attack;
                return thief;
            }
        }


        private void btnClassClone_Click(object sender, RoutedEventArgs e)
        {
            string strRet;
            Thief thief1 = new Thief();
            thief1.hp = 100;
            thief1.attack = 10;
            strRet = $"thief1 HP : {thief1.hp}";   lstLog.Items.Add(strRet);

            Thief thief2 = new Thief();
            thief2.hp = thief1.hp;
            thief2.attack = thief1.attack;
            strRet = $"thief2 HP : {thief2.hp}"; lstLog.Items.Add(strRet);

            Thief thief3 = thief1.Clone();
            strRet = $"thief3 HP : {thief3.hp}"; lstLog.Items.Add(strRet);
        }


        class Archer
        {
            static public int count = 0;

            int id;
            public int hp;
            public int attack;
            private Archer()
            {
                count++;
                id = count;
            }

            public Archer(int hp, int attack) : this()
            {
                this.hp = hp;
                this.attack = attack;
            }

            static public Archer CreateArcher()
            {
                Archer archer = new Archer();
                archer.hp = 100;
                archer.attack = 10;
                return archer;
            }
        }

        private void btnClassStatic_Click(object sender, RoutedEventArgs e)
        {
            string strRet;
            Archer archer1 = new Archer(100, 10);
            strRet = $"Archer count : {Archer.count}"; lstLog.Items.Add(strRet);

            Archer archer2 = new Archer(100, 10);
            strRet = $"Archer count : {Archer.count}"; lstLog.Items.Add(strRet);

            Archer archer3 = Archer.CreateArcher();
            strRet = $"Archer count : {Archer.count}"; lstLog.Items.Add(strRet);
        }

        class Player
        {
            public int hp = 100;
            public int attack = 10;
            public void Info(out string strRet)
            {
                strRet = $"Player Hp : {hp}, attack : {attack}";
            }
            static public void EnterGame(Player player, out string strRet1, out string strRet2)
            {
                Marine marine = (player as Marine);
                if (marine != null)
                {
                    strRet1 = $"Marin is Entered.";
                }
                else
                {
                    strRet1 = "";
                }

                bool isMarine = (player is Marine);
                if (isMarine)
                {
                    strRet2 = "This Player is Entered.";
                }
                else
                {
                    strRet2 = "";
                }
            }
        }

        class Marine : Player
        {
            public int mp = 200;
            public void Info(out string strRet1, out string strRet2)
            {
                base.Info(out strRet1); // 부모의 Info 호출도 가능
                strRet2 = $"Marine Hp : {hp}, Mp : {mp}, attack : {attack}";
            }
        }

        private void btnClassInherit_Click(object sender, RoutedEventArgs e)
        {
            Marine marine = new Marine();
            string strLog1, strLog2;
            marine.Info(out strLog1, out strLog2);
            lstLog.Items.Add(strLog1);
            lstLog.Items.Add(strLog2);
        }

        private void btnClassTypeConversion_Click(object sender, RoutedEventArgs e)
        {
            Marine marine = new Marine();
            string strLog1, strLog2;
            Player.EnterGame(marine, out strLog1, out strLog2);
            lstLog.Items.Add(strLog1);
            lstLog.Items.Add(strLog2);
        }

        class Monster
        {
            public int id;
            public Monster(int id) { this.id = id; }
        }

        private void btnDictionary_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            dic.Add(1, new Monster(1));
            dic[5] = new Monster(5);
            for (int i = 6; i < 10000; i++)
            {
                dic.Add(i, new Monster(i));
            }

            Monster mon = dic[5000]; // 키값이 5000이 없으면 크래시 
            string strLog = $"monster ID : {mon.id}";
            lstLog.Items.Add(strLog);

            dic.Remove(5000);
            lstLog.Items.Add("Remove ID 5000");

            if (false == dic.TryGetValue(5000, out mon))
            {
                strLog = $"monster ID 5000 find fail";
                lstLog.Items.Add(strLog);
            }
            else{
                strLog = $"monster ID : {mon.id}";
                lstLog.Items.Add(strLog);
            }
            dic.Clear();
        }

        class MyList<T> where T : struct
        {
            public T[] arr = new T[10];
            public T GetItem(int i)
            {
                return arr[i];
            }
            public void Init(T t)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = t;
                }
            }
        }

        class User
        {
            public int id;
        }

        void Test<T>(T input, out string Ret) where T : struct
        {
            Ret = $"value : {input}";
        }

        private void btnGeneric_Click(object sender, RoutedEventArgs e)
        {
            MyList<int> myIntList = new MyList<int>();
            MyList<float> myFloatList = new MyList<float>();

            string strRet;
            myIntList.Init(10);
            Test<int>(myIntList.arr[0], out strRet);
            lstLog.Items.Add(strRet);

            myFloatList.Init(11.122f);
            Test<float>(myFloatList.arr[0], out strRet);
            lstLog.Items.Add(strRet);


            //// 컴파일 에러 ==> 값 type만 허용하므로.
            //MyList<string> myStringList = new MyList<string>();
            //myStringList.Init("hello~");
            //myStringList.arr[0] = "hello2"; // 0 인자만 바뀐다.

            //// 컴파일 에러 ==> 값 type만 허용하므로.
            //MyList<User> myUserList = new MyList<User>();
            //// // 컴파일 에러 ==> 값 type만 허용하므로.
            //myUserList.Init(new User());
            //myUserList.arr[0].id = 10; // 참조형으로 넘겼으므로 모든 인자의 값이 바뀐다.
        }

        abstract class Enemy
        {
            public abstract void Shout(out string strRet);
        }
        //abstract class Flyable
        //{
        //    public abstract void Fly();
        //}
        class Orc : Enemy/*, Flyable // C++ 과 달리 다중 상속은 언어차원에서 안된다.*/
        {
            public override void Shout(out string strRet)
            {
                //base.Shout(out strRet);
                strRet = "록타르 오카르!";
            }
        }

        interface IFlyable
        {
            string Fly();
        }

        class FlyableOrc : Orc, IFlyable
        {
            public override void Shout(out string strRet)
            {
                base.Shout(out strRet);
            }

            public string Fly()
            {
                return "Fly Orc~~ 꾸에에에엑";
            }
        }

        string DoFly(IFlyable flyable)
        {
            return flyable.Fly();
        }

        private void btnInterface_Click(object sender, RoutedEventArgs e)
        {
            FlyableOrc flyOrc = new FlyableOrc();
            lstLog.Items.Add( DoFly(flyOrc));
        }


        class Medic
        {
            protected int hp;
            public int Hp
            {
                get { return hp; }
                set
                {
                    if(value >= 0)
                        hp = value; 
                }
            }
        }

        private void btnProperty_Click(object sender, RoutedEventArgs e)
        {

            string strLog;

            Medic medic = new Medic();
            medic.Hp = 100;            
            strLog = $"Medic Hp : {medic.Hp}";  lstLog.Items.Add(strLog);

            medic.Hp = -20;
            strLog = $"Medic Hp : {medic.Hp}"; lstLog.Items.Add(strLog);
        }

        // Delegate는 형식!
        // 반환형 int, 인자 void 의 형태를 가지는 함수를
        // OnClicked라는 형식으로 치환하여 부른다.
        delegate int OnClicked(); 

        void ButtonPressd(OnClicked clickedFunc)
        {
            // Delegate호출!
            clickedFunc();
        }

        int TestDelegate()
        {
            string strRet = $"Hello Delegate!";
            lstLog.Items.Add(strRet);
            return 1000;
        }
        int TestDelegate2()
        {
            string strRet = $"Hello Delegate2!";
            lstLog.Items.Add(strRet);
            return 1000;
        }

        private void btnDelegate_Click(object sender, RoutedEventArgs e)
        {
            ButtonPressd(TestDelegate);

            OnClicked clicked = new OnClicked(TestDelegate);
            clicked += TestDelegate2;
            ButtonPressd(clicked);
        }
    }
}
