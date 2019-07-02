using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesonetWinParty.Helpers
{
    class DebugLogger : ILog
    {
        private readonly Type _type;

        public DebugLogger(Type type)
        {
            _type = type;
        }

        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}",
            DateTime.Now.ToString("o"),
            string.Format(format, args));
        }

        public void Error(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Info(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
