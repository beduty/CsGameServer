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
using System.Diagnostics;
using System.Threading;

namespace Practice
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Swap(ref int a, ref int b)
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
            int num1 = 10, num2 = 3;
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
            strRet = $"thief1 HP : {thief1.hp}"; lstLog.Items.Add(strRet);

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
            else
            {
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
            lstLog.Items.Add(DoFly(flyOrc));
        }


        class Medic
        {
            protected int hp;
            public int Hp
            {
                get { return hp; }
                set
                {
                    if (value >= 0)
                        hp = value;
                }
            }
        }

        private void btnProperty_Click(object sender, RoutedEventArgs e)
        {

            string strLog;

            Medic medic = new Medic();
            medic.Hp = 100;
            strLog = $"Medic Hp : {medic.Hp}"; lstLog.Items.Add(strLog);

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

        InputManager manager = new InputManager();
        void OnInputTest()
        {
            lstLog.Items.Add("Input Received");
        }


        private void btnEvent_Click(object sender, RoutedEventArgs e)
        {
            manager.InputKey += OnInputTest;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                if (sw.ElapsedMilliseconds > 3 * 1000)
                {
                    break;
                }
                manager.Update();
            }
            sw.Stop();
        }

        enum ItemType
        {
            Weapon,
            Armor,
            Amulet,
            Ring
        }
        enum Rarity
        {
            Normal,
            Uncommon,
            Rare,
        }

        class Item
        {
            public ItemType ItemType;
            public Rarity Rarity;
        }

        List<Item> _items = new List<Item>();

        Item FindWeapon()
        {
            foreach (Item item in _items)
            {
                if (item.ItemType == ItemType.Weapon)
                {
                    return item;
                }
            }
            return null;
        }

        Item FindArmor()
        {
            foreach (Item item in _items)
            {
                if (item.ItemType == ItemType.Armor)
                {
                    return item;
                }
            }
            return null;
        }

        // Delegate를 활용해보자. (함수를 넘긴다.)
        delegate bool ItemSelector(Item item); // 판별하야 true, false를 리턴해준다.
        Item FindItem(ItemSelector selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                {
                    return item;
                }
            }
            return null;
        }
        bool IsWeapon(Item item)
        {
            return (item.ItemType == ItemType.Weapon);
        }

        private void btnRambda_Click(object sender, RoutedEventArgs e)
        {
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Amulet, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            Item find1 = FindItem(IsWeapon);

            // 람다로 쓸 수 있다. 
            Item find2 = FindItem(delegate (Item item) { return item.ItemType == ItemType.Armor; });
            Item find3 = FindItem((Item item) => { return item.ItemType == ItemType.Ring; });
        }


        void ThreaProc()
        {
            System.Diagnostics.Debug.WriteLine("Hello Thread");
        }

        private void btnThread_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Run Thread~");
            Thread t = new Thread(ThreaProc);
            t.Name = "TestThread"; // 스레드에 이름을 붙일 수도 있다.
            // t.IsBackground = true; // 메인이 종료되면 backgroud thread도 종료된다.
            t.Start();
            t.Join();
        }

        void ThreadPoolProc(object obj)
        {
            for (int i = 0; i < 5; i++)
            {
                System.Diagnostics.Debug.WriteLine($"Hello Thread {i}");
            }
        }

        private void btnThreadPool_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5); // ThreadPool에 동시에 일할수 있는 작업은 5개까지! 그 다음은 작업이 완료될 때까지 대기!

            for (int i = 0; i < 4; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) => { while (true) { } });
            }
            ThreadPool.QueueUserWorkItem(ThreadPoolProc); // 한자리 남았으므로 실행된다.

            while (true)
            {

            }
        }
        private void btnTask_Click(object sender, RoutedEventArgs e)
        {

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5); // ThreadPool에 동시에 일할수 있는 작업은 5개까지! 그 다음은 작업이 완료될 때까지 대기!

            for (int i = 0; i < 5; i++)
            {
                //Task t = new Task(() => { while (true) { } });
                Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning); // Max Threads 개수와는 상관 없이 돌아간다.
            }
            ThreadPool.QueueUserWorkItem(ThreadPoolProc); // Task에서 모든 자리 차지 하고 있으므로, 실행 X 
            // But, Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning); 이었으면 실행 O

            while (true)
            {

            }
        }

        int num = 0;
        object _obj = new object();

        void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                //num++;
                //Interlocked.Increment(ref num);

                lock (_obj)
                {
                    num++;
                }
            }
        }

        void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                //num--;
                //Interlocked.Decrement(ref num);

                lock (_obj)
                {
                    num--;
                }
            }
        }
        private void btnInterLock_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            int a = num;
        }


        class MySpinLock
        {
            volatile int _locked = 0;

            public void Acquire()
            {
                while (true)
                {
                    // 원자성이 보장되지 않는다. ==> Thread-Safe하지 않다.
                    //if (_locked == 0)
                    //{
                    //    _locked = 1;
                    //}

                    // 내부는 다음과 같이 구현된다.
                    // int old = *_locked;
                    // if(*_locked == expected)
                    //    *locked = desired;
                    // return old;
                    int expected = 0;
                    int desired = 1;
                    int original = Interlocked.CompareExchange(ref _locked, desired, expected);
                    if (original == 0)
                    {
                        // 이미 1로 바뀌어 있지는 않았는지 확인이 가능하다!
                        break;
                    }

                    //Thread.Sleep(1);// 무조건 휴식 
                    //Thread.Sleep(0);// 조건부 휴식 => 우선순위 같거나 높은 애한테는 양보, 낮은애들은 양보 불가.
                    Thread.Yield(); // 지금 실행 가능한 스레드 있으면 실행 양 ==> 없으면 양보 X
                }
            }

            public void Release()
            {
                _locked = 0;
            }
        }

        int number = 0;
        MySpinLock _lock = new MySpinLock();

        void ThrSpinLock_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire();
                number++;
                _lock.Release();
            }
        }
        void ThrSpinLock_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.Acquire();
                number--;
                _lock.Release();
            }
        }

        private void btnSpinLock_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(ThrSpinLock_1);
            Task t2 = new Task(ThrSpinLock_2);
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            int a = number;
        }


        class AutoLock
        {
            AutoResetEvent _avaliable = new AutoResetEvent(true); // true 누구나 들어올 수 있음. (첫번쨰 입장만)
            public void Acquire()
            {
                _avaliable.WaitOne();// 입장 시도. => 누군가 획득하면 문이 닫힘.다른 사람은 못들어옴.
            }
            public void Release()
            {
                _avaliable.Set(); // 다시 문을 열어둠.
            }
        }


        int numberAuto = 0;
        AutoLock _lockAuto = new AutoLock();

        void ThrAutoLock_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lockAuto.Acquire();
                numberAuto++;
                _lockAuto.Release();
            }
        }
        void ThrAutoLock_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lockAuto.Acquire();
                numberAuto--;
                _lockAuto.Release();
            }
        }

        private void btnEvent1_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(ThrAutoLock_1);
            Task t2 = new Task(ThrAutoLock_2);
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            int a = numberAuto;
        }


        int numberManual = 0;
        //ManualLock _lockManual = new ManualLock();
        Mutex _lockManual = new Mutex();
        void ThrManualLock_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lockManual.WaitOne();
                numberManual++;
                _lockManual.ReleaseMutex();
            }
        }
        void ThrManualLock_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lockManual.WaitOne();
                numberManual--;
                _lockManual.ReleaseMutex();
            }
        }

        private void btnMutex_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(ThrManualLock_1);
            Task t2 = new Task(ThrManualLock_2);
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            int a = numberManual;
        }


        int nTstNum = 0;
        SpinLock _lock2 = new SpinLock();

        void SpinThread_1()
        {
            bool lockTaken = false;
            for (int i = 0; i < 100000; i++)
            {
                lockTaken = false;
                try
                {
                    _lock2.Enter(ref lockTaken);
                    nTstNum++;
                }
                finally
                {
                    if (lockTaken)
                    {
                        _lock2.Exit();
                    }
                }
            }
        }

        void SpinThread_2()
        {
            bool lockTaken = false;
            for (int i = 0; i < 100000; i++)
            {
                try
                {
                    lockTaken = false;
                    _lock2.Enter(ref lockTaken);
                    nTstNum--;
                }
                finally
                {
                    if (lockTaken)
                    {
                        _lock2.Exit();
                    }                    
                }
            }
        }

        private void btnCsSpnLock_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = new Task(SpinThread_1);
            Task t2 = new Task(SpinThread_2);
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
        }


        class Reward
        {

        }

        ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();
        Reward GetRewardByID(int id)
        {
            _lock3.EnterReadLock();
            // get..
            _lock3.ExitReadLock();
            return null;
        }
        void AddReward(Reward reward)
        {
            _lock3.EnterReadLock();
            // set..
            _lock3.ExitReadLock();            
        }


        private void btnReadWriteLock_Click(object sender, RoutedEventArgs e)
        {

        }

        ThreadLocal<string> ThreadName = new ThreadLocal<string>();
        // 스레드에서 TreadName에 접근하면, 자신만의 공간으로 저장해서 사용한다.
        // 특정 스레드가 ThreadName을 변경해도 다른 스레드에 영향을 받지 않는다.
        
        void WhoAmI()
        {
            // 스레드의 영역에서만 변경된 값이 적용된다.
            ThreadName.Value = $"My Name is {Thread.CurrentThread.ManagedThreadId}";
            //Thread.Sleep(1000);
            System.Diagnostics.Debug.WriteLine(ThreadName.Value);
        }
       
        private void btnTLS_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(3, 3);
            Parallel.Invoke(WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI);
            ThreadName.Dispose();
        }
    }    
}
