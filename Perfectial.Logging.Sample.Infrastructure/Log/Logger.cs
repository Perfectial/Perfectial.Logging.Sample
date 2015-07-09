using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfectial.Logging.Sample.Infrastructure.Log
{
    public static class Logger
    {
        #region Constants
        private const string DEF_TRACE_SOURCE_NAME = "Global";
        private const string DEF_TRACE_FORMAT = "{0}\r\nMessage: {1}\r\nStack Trace:\r\n{2}";
        private const int DEF_ERROR_EVENT_ID = 1;
        private const int DEF_WARNING_EVENT_ID = 2;
        private const int DEF_INFORMATION_EVENT_ID = 3;
        private const int DEF_DEBUG_EVENT_ID = 4;
        #endregion

        #region Public Members
        public static void Debug(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Verbose, DEF_DEBUG_EVENT_ID, GetFormattedMessage(message));
        }

        public static void Error(string message, string stackTrace = null)
        {
            _traceSource.TraceEvent(TraceEventType.Error, DEF_ERROR_EVENT_ID, GetFormattedMessage(message, stackTrace));
        }

        public static void Information(string message)
        {
            _traceSource.TraceInformation(message);
        }

        public static void Warning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, DEF_WARNING_EVENT_ID, GetFormattedMessage(message));
        }

        public static void Throw(Exception ex)
        {
            Error(ex.Message, ex.StackTrace);
        }
        #endregion

        #region Private Members
        private static TraceSource _traceSource = new TraceSource(DEF_TRACE_SOURCE_NAME);

        private static string GetFormattedMessage(string message, string stackTrace = null)
        {
            return string.Format(DEF_TRACE_FORMAT, DateTime.Now, 
                message, stackTrace ?? DeleteLines(Environment.StackTrace, 5));
        }

        public static string DeleteLines(string s, int linesToRemove)
        {
            return s.Split(Environment.NewLine.ToCharArray(), linesToRemove + 1, 
                StringSplitOptions.RemoveEmptyEntries).Skip(linesToRemove).FirstOrDefault();
        }
        #endregion
    }
}
