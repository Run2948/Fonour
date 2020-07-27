using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Logging;

namespace Fonour.MVC.Common.Extensions
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory)
        {
            return AddLog4Net(factory,"log4net.config");
        }
    }

    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new ConcurrentDictionary<string, Log4NetLogger>();
        public Log4NetProvider(string log4NetConfigFile)
        {
            _log4NetConfigFile = log4NetConfigFile;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, ParseLog4NetConfigFile(_log4NetConfigFile));
        }

        private static XmlElement ParseLog4NetConfigFile(string filename)
        {
            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(filename));
            var configuration = log4NetConfig["configuration"];
            return configuration["log4net"];
        }
    }

    public class Log4NetLogger : ILogger
    {
        private readonly ILog _log;

        public Log4NetLogger(string name, XmlElement xmlElement)
        {
            var loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            _log = LogManager.GetLogger(loggerRepository.Name, name);
            XmlConfigurator.Configure(loggerRepository, xmlElement);
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.None => false,
                LogLevel.Critical => _log.IsFatalEnabled,
                LogLevel.Error => _log.IsErrorEnabled,
                LogLevel.Warning => _log.IsWarnEnabled,
                LogLevel.Information => _log.IsInfoEnabled,
                LogLevel.Debug => _log.IsDebugEnabled,
                LogLevel.Trace => _log.IsDebugEnabled,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel))
            };
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            var message = formatter(state, exception);
            if (!string.IsNullOrEmpty(message) || exception != null)
            {
                switch (logLevel)
                {
                    case LogLevel.Critical:
                        _log.Fatal(message);
                        break;
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                        _log.Debug(message);
                        break;
                    case LogLevel.Error:
                        _log.Error(message);
                        break;
                    case LogLevel.Information:
                        _log.Info(message);
                        break;
                    case LogLevel.Warning:
                        _log.Warn(message);
                        break;
                    case LogLevel.None:
                        break;
                    default:
                        _log.Warn($"Encountered unknown log level {logLevel}, writing out as Info.");
                        _log.Info(message, exception);
                        break;
                }
            }
        }
    }
}
