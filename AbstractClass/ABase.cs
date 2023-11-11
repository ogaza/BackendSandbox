using System;

namespace AbstractClass
{
    public abstract class ABase
    {
        public virtual void DoSth()
        {
            ActionOne();
            ActionTwo();
            ActionThree();
        }

        protected virtual void ActionOne()
        {
            Console.WriteLine("Action ONE in the BASE class");
        }

        protected virtual void ActionTwo()
        {
            Console.WriteLine("Action TWO in the BASE class");
        }

        protected virtual void ActionThree()
        {
            Console.WriteLine("Action THREE in the BASE class");
        }
    }
}
