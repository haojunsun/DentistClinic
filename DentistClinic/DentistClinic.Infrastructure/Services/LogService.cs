using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DentistClinic.Infrastructure.Services
{
    public interface ILogService : IDependency
    {
        void Debug(string msg);
    }

    public class LogService : ILogService
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Debug(string msg)
        {
            _log.Debug(msg);
        }

        public void Error(string msg)
        {
            _log.Error(msg);
        }

        public void Info(string msg)
        {
            _log.Info(msg);
        }
    }
}
