using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson0061
{
    [Serializable]
    class MyException : Exception
    {
        public MyArrayErrors MyErrorCode { get; } 
        public enum MyArrayErrors
        {
           SizeException,
           DataException
        }
        
         public MyException(MyArrayErrors SomeCode)
        {
            MyErrorCode = SomeCode;
        }
    }
}
