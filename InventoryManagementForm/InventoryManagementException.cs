using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementForm
{
    public class InventoryManagementException : Exception 
    {
        public InventoryManagementException()
            : base() { }

        public InventoryManagementException(string message)
            : base(message) { }

        public InventoryManagementException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InventoryManagementException(string message, Exception innerException)
            : base(message, innerException) { }

        public InventoryManagementException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
