using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationForm
{
    public class AllocationException : Exception 
    {
        public AllocationException()
            : base() { }

        public AllocationException(string message)
            : base(message) { }

        public AllocationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AllocationException(string message, Exception innerException)
            : base(message, innerException) { }

        public AllocationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
