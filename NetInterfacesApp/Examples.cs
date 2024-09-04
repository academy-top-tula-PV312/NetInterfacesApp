using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInterfacesApp
{
    static class Examples
    {
        public static void Welcome()
        {
            Console.WriteLine(IMovable.speedMaximum);
            Console.WriteLine(IMovable.speedMinimum);

            //Dog dog = new();
            //dog.Move();
            //Car car = new();
            //car.Move();
            //((IMovable)car).Stop();

            DoMove(new Car());
            DoMove(new Dog());

            IMovable[] movables = new IMovable[] { new Car(), new Dog() };

            IMovable movable = new Car();
            DoMove(movable);
            movable = new Dog();
            DoMove(movable);


            void DoMove(IMovable movable)
            {
                movable.Move();
            }

        }

        public static void ExplicitImmplenetation()
        {
            IUniversitet student = new Student();
            student.Diplom();

            Student aspirant = new Aspirant();
            aspirant.Study();

        }

        public static void Variants()
        {
            // КОВАРИАНТНОСТЬ И КОНТРВАРИАНТНОСТЬ
            IMessanger<EmailMessage, Message> messanger = new MyMessanger();
            Message message = messanger.CreateMessage("Polimorphizm!");
            Console.WriteLine(message.Text);
            messanger.SendMessage(new EmailMessage("Contrvariant"));

            IMessanger<EmailMessage, EmailMessage> emailMessanger = new MyMessanger();
            EmailMessage emailMessage = emailMessanger.CreateMessage("Covariant!");
            emailMessanger.SendMessage(emailMessage);

            IMessanger<Message, Message> pureMessanger = new MyMessanger();
            Message pureMessage = pureMessanger.CreateMessage("Covarinat 2!");
            pureMessanger.SendMessage(pureMessage);

            // КОНТРВАРИАНТ
            //IMessanger<Message> myMessanger = new MyMessanger();
            //myMessanger.SendMessage(new Message("Hello people"));

            //IMessanger<EmailMessage> emailMessanger = new MyMessanger();
            //emailMessanger.SendMessage(new EmailMessage("Email massage send!"));

            //emailMessanger = myMessanger;

            // КОВАРИАНТНОСТЬ
            //IMessanger<Message> bat = new EmailMessanger();
            //Message message = bat.CreateMessage("Hello world");
            //Console.WriteLine(message.Text);


            //IMessanger<EmailMessage> emailClient = new EmailMessanger();
            //bat = emailClient;
            //message = bat.CreateMessage("Good by world");
            //Console.WriteLine(message.Text);
        }
    }

    interface IMovable
    {
        const int speedMinimum = 0;
        static int speedMaximum = 60;

        void Move();

        void Stop()
        {
            Console.WriteLine("Stop!");
        }

        string Name { set; get; }

        delegate void MoveHandler(string message);
        event MoveHandler MoveEvent;
    }

    class Car : IMovable
    {
        public string Name { get; set; }

        public event IMovable.MoveHandler MoveEvent;

        public void Move()
        {
            Console.WriteLine("Car drive");
        }
    }

    class Dog : IMovable, ICloneable
    {
        public string Name { get; set; }

        public event IMovable.MoveHandler MoveEvent;

        public object Clone()
        {
            return new Dog() { Name = this.Name };
        }

        public void Move()
        {
            Console.WriteLine("Dog run");
        }
    }

    interface ISchool
    {
        void Study();
    }

    interface IUniversitet
    {
        void Study();
        void Diplom() => Console.WriteLine("Take Diplom");
    }

    class Student : IUniversitet //, ISchool
    {
        //void ISchool.Study() => Console.WriteLine("Student Study in School");
        public virtual void Study() => Console.WriteLine("Student Study in Universitet");

        public void Diplom()
        {
            Console.WriteLine("Student Take Diplom");
        }
    }

    class Aspirant : Student
    {
        public override void Study() => Console.WriteLine("Aspirant Study in Universitet");
    }

    interface IFirst
    {
        void MethodFirst();
    }

    interface ISecond : IFirst
    {
        void MethodSecond();
    }

    class ClassImpl : ISecond
    {
        public void MethodFirst()
        {
            throw new NotImplementedException();
        }

        public void MethodSecond()
        {
            throw new NotImplementedException();
        }
    }

    interface IPerson<T>
    {
        T Id { get; set; }
    }

    class PersonT<T> : IPerson<T>
    {
        public T Id { set; get; }
    }

    class PersonInt : IPerson<int>
    {
        public int Id { set; get; }
    }




    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }


    // BOTH
    interface IMessanger<in T1, out T2>
    {
        T2 CreateMessage(string text);
        void SendMessage(T1 message);
    }

    class MyMessanger : IMessanger<Message, EmailMessage>
    {
        public EmailMessage CreateMessage(string text)
        {
            return new EmailMessage(text);
        }

        public void SendMessage(Message message)
        {
            Console.WriteLine($"Send message: {message.Text}");
        }
    }

    // COVAR
    //interface IMessanger<out T>
    //{
    //    T CreateMessage(string text);
    //}

    //class EmailMessanger : IMessanger<EmailMessage>
    //{
    //    public EmailMessage CreateMessage(string text)
    //    {
    //        return new EmailMessage(text);
    //    }
    //}

    // CONTVAR
    //interface IMessanger<in T>
    //{
    //    void SendMessage(T message);
    //}

    //class MyMessanger : IMessanger<Message>
    //{
    //    public void SendMessage(Message message)
    //    {
    //        Console.WriteLine($"Send message: {message.Text}");
    //    }
    //}
}
