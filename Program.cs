using System;

namespace FootballEx
{
    interface IJumpable
    {
        void Jump();
    }
    class Player
    {
        private string name;
        private int shirtNum;
        protected int points;

        public Player(string name, int shirtNum)
        {
            this.name = name;
            this.shirtNum = shirtNum;
            this.points = 0;
        }

        public void AddPoints(int p) { this.points += p; }
        public void Move() { }
        public void Kick() { }

        public virtual void Score() { this.points += 10; }

    }

    class GoalKeeper: Player, IJumpable
    {
        public GoalKeeper(string name, int shirtNum):base(name, shirtNum) { }
        public void Jump() { }
        public void Catch() { }

    }

    class Attacker : Player, IJumpable
    {
        public Attacker(string name, int shirtNum) : base(name, shirtNum) { }
        public void Jump() { }
    }

    class MiddleFielder: Player
    {
        private bool isRightPosition;
        public MiddleFielder(string name, int shirtNum, bool isRightPosition) : base(name, shirtNum) 
        {
            this.isRightPosition = isRightPosition;
        }
    }

    class Defender : Player
    {
        private bool isForwardPosition;
        public Defender(string name, int shirtNum, bool isForwardPosition) : base(name, shirtNum)
        {
            this.isForwardPosition = isForwardPosition;
        }

        public override void Score() { this.points += 20; }
    }


    class Program
    {

        static void Score(Player[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is Defender)
                {
                    Defender d = (Defender)arr[i];
                    d.AddPoints(20);
                }
                else
                {
                    arr[i].AddPoints(10);
                }
            }
        }
        static void Score2(Player[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Score();
            }
        }

        static void JumpPlayer(Player[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is IJumpable)
                {
                    IJumpable jumper = (IJumpable)arr[i];
                    jumper.Jump();
                }
            }
        }

        static void JumpPlayer2(Player[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] is GoalKeeper)
                {
                    GoalKeeper gk = (GoalKeeper)arr[i];
                    gk.Jump();
                }
                if (arr[i] is Attacker)
                {
                    Attacker ez = (Attacker)arr[i];
                    ez.Jump();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
