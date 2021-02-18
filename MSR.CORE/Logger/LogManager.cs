using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.CORE.Logger
{
    public sealed class LogManager
    {
        private static object currentLock = new object();
        private static LogManager _current = null;
        private readonly NLog.Logger _logger;

        private NLog.Logger _infoLogger;
        private NLog.Logger _debugLogger;
        private NLog.Logger _errorLogger;
        private NLog.Logger _traceLogger;

        private LogManager()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public static LogManager Logger
        {
            get
            {
                if (_current == null)
                {
                    lock (currentLock)
                    {
                        _current = new LogManager();
                        _current.ConfigureLogger();
                    }
                }

                return _current;
            }
        }

        public void ConfigureLogger()
        {
            if (_logger.IsDebugEnabled)
            {
                _debugLogger = _logger;
            }

            if (_logger.IsInfoEnabled)
            {
                _infoLogger = _logger;
            }

            if (_logger.IsErrorEnabled)
            {
                _errorLogger = _logger;
            }

            if (_logger.IsTraceEnabled)
            {
                _traceLogger = _logger;
            }
        }

        public void WriteInfo(string controllerClass, string actionMethod, string message)
        {
            _infoLogger.Info($"{controllerClass}::{actionMethod} => {message}");
        }

        public void WriteDebug(string controllerClass, string actionMethod, string message)
        {
            _debugLogger.Debug($"{controllerClass}::{actionMethod} => {message}");
        }

        public void WriteError(string controllerClass, string actionMethod, string message)
        {
            _errorLogger.Error($"{controllerClass}::{actionMethod} => {message}");
        }

        public void WriteException(string controllerClass, string actionMethod, string message, Exception ex)
        {
            _errorLogger.Error(ex, $"{controllerClass}::{actionMethod} => {message}");
        }

        public void WriteTrace(string controllerClass, string actionMethod, string message)
        {
            _traceLogger.Trace($"{controllerClass}::{actionMethod} => {message}");
        }
    }
}
