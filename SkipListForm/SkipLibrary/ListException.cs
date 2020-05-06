using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N6_ClassLib.SkipLibrary
{
    //возможные исключения при работе со списком

    class SkipListException : Exception
    {
        public SkipListException()
        { }

        public SkipListException(string message) : base(message)
        { }
    }
    
    //выход за границы массива
    class SkipListOverflowException : SkipListException
    {
        public SkipListOverflowException() : base("Warning: overstepped cell limit")
        { }

        public SkipListOverflowException(string message) : base(message)
        { }
    }

    //попытка изменить immutable list
    class SkipListImmutableException : SkipListException
    {
        public SkipListImmutableException() : base("Warning: you can not change immutable list")
        { }

        public SkipListImmutableException(string message) : base(message)
        { }
    }

}
