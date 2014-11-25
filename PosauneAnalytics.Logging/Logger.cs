using log4net;
using log4net.Config;
using log4net.Core;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace PosauneAnalytics.Logging
{
    public static class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string _logLevel;

        static Logger()
        {
            DefaultSetup();

            Level logLevel = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level;

            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.All;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);

            log.Logger.Log(log.Logger.GetType(), Level.All, "Initializing log4net logger.  Level=" + _logLevel, null);

            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = logLevel;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);

        }

        public static void LogDebug(string message)
        {
            LogDebug(message, null);
        }

        public static void LogDebug(string message, Exception ex)
        {
            try
            {
                log.Debug(message, ex);
            }
            catch { }
        }

        public static void LogInfo(string message)
        {
            LogInfo(message, null);
        }

        public static void LogInfo(string message, Exception ex)
        {
            try
            {
                log.Info(message, ex);
            }
            catch { }
        }



        public static void LogError(string message)
        {
            LogError(message, null);
        }

        public static void LogError(string message, Exception ex)
        {
            try
            {
                log.Error(message, ex);
            }
            catch { }
        }


        private static void DefaultSetup()
        {
            XmlConfigurator.Configure(XmlSetup());
        }

        private static Stream XmlSetup()
        {
            _logLevel = "DEBUG";
            if (ConfigurationManager.AppSettings["LogLevel"] != null)
            {
                _logLevel = ConfigurationManager.AppSettings["LogLevel"];
            }

            string x = String.Format(@"<log4net>
                <appender name=""RollingFileAppender"" type=""log4net.Appender.RollingFileAppender"">
                <file value=""Logs\PosauneAnalytics.log""/>
                <appendToFile value=""true""/>
                <rollingStyle value=""Size""/>
                <maxSizeRollBackups value=""5""/>
                <maximumFileSize value=""10MB""/>
                <staticLogFileName value=""true""/>
                <layout type=""log4net.Layout.PatternLayout"">
                <conversionPattern value=""%date [%thread] %level %logger - %message%newline%exception""/>
                </layout>
                </appender>
                <appender name=""MemoryAppender"" type=""log4net.Appender.MemoryAppender"" >
                <layout type=""log4net.Layout.PatternLayout"">
                <conversionPattern value=""%date [%thread] %level %logger - %message%newline%exception""/>
                </layout>
                </appender>
                <root>
                <level value=""{0}""/>
                <appender-ref ref=""RollingFileAppender""/>
                <appender-ref ref=""MemoryAppender""/>
                </root>
                </log4net>", _logLevel);
            return new MemoryStream(ASCIIEncoding.Default.GetBytes(x));
        }
    }
}
