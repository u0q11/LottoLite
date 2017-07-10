using log4net;
using log4net.Config;
using LottoLite.Interfaces.Logger;
using System;
using System.Diagnostics;
using System.Reflection;

namespace LottoLite.Services
{
    public class LoggerService : ILogger
    {
        private readonly ILog _logger;

        public LoggerService()
        {
            XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(AddDebugInfo(message));
            }
        }

        /// <summary>
        /// This method is necessary because the default implementation of
        /// log4net gets stack info from the calling method. The calling method
        /// will always be our wrapper methods above. This code goes down the 
        /// stack trace one step further and determines the correct calling info.
        /// 
        /// Provide specific information about the logged message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string AddDebugInfo(string message)
        {
            // Since we are tab seperating the items in the log line
            //	we should not allow any tabs in the raw message. This
            //	will make it difficult to parse later.
            //
            message = message.Replace('\t', ' ');

            // Get the stack frame the originated the log comment.
            //
            StackFrame frame1 = new StackFrame(2, true);
            string methodName = frame1.GetMethod().ToString();
            int lineNumber = frame1.GetFileLineNumber();
            string fileName = frame1.GetFileName();

            // Format the log line
            //
            string newMessage = String.Format("{0}\t{1}\t{2}\t{3}",
                                                message,
                                                lineNumber,
                                                methodName,
                                                fileName);

            return newMessage;
        }

    }
}
