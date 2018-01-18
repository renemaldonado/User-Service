using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsrSrvcDAL.Exceptions {
    public abstract class InvalidLoginException : System.Exception {

        public InvalidLoginException()
            : base() {
        }


        public InvalidLoginException(String message)
            : base(message) {
        }


        public InvalidLoginException(String message, Exception innerException)
            : base(message, innerException) {
        }



    }
}
