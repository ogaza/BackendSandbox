using System;

namespace AbstractClass
{
    public class SubClassOne : ABase
    {
        protected override void ActionTwo()
        {
            Console.WriteLine("Action TWO in the SubClassOne class");
        }
    }
}