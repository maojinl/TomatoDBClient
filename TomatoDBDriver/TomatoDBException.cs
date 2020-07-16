using System;
using System.Data.Common;

namespace TomatoDBDriver
{
    public class TomatoDBException : DbException
    {
        private int errorCode;

        internal TomatoDBException()
        {
        }

        internal TomatoDBException(string msg)
          : base(msg)
        {
        }

        internal TomatoDBException(string msg, Exception ex)
          : base(msg, ex)
        {
        }

        internal TomatoDBException(string msg, int errno, Exception inner)
          : this(msg, inner)
        {
            errorCode = errno;
            Data.Add("Server Error Code", errno);
        }

        internal TomatoDBException(string msg, int errno)
          : this(msg, errno, null)
        {
        }

        public int DBErrorCode
        {
            get { return errorCode; }
        }
    }
}
}
