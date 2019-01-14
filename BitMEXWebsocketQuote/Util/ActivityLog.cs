using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BitMEXWebsocketQuote.Util
{
	class ActivityLog
	{

		//Basic parameters
		private static string _logPrefix = "Logging";
		private static string _logExtension = "log";
		private static string _logDateFormat = "yyyyMMdd-HH";
		private static string _logSubfolder = "Logs";
		private static int _retryAttempts = 10;
		private static int _retryDelay = 10;
		private static int _daysToKeep = 1;

		//Returns the Path where the log files are saved
		private static string GetLogPath()
		{
			string path = "";
			try
			{
				path = Directory.GetCurrentDirectory();
				if (!Directory.Exists(path + "\\" + _logSubfolder))
				{
					Directory.CreateDirectory(path + "\\" + _logSubfolder);
				}
				path = Directory.GetCurrentDirectory() + "\\" + _logSubfolder;
				return path;
			}
			catch (Exception ex)
			{
				return path;
			}
		}

		//Returns the name of the log file including the extension
		private static string GetFileName()
		{
			string name = "";
			try
			{
				name = _logPrefix + "-" + DateTime.Now.ToString(_logDateFormat) + "." + _logExtension;
				return name;
			}
			catch (Exception ex)
			{
				return name;
			}
		}

		//Return the full path and name of the log file
		private static string GetLogFileName()
		{
			try
			{
				string logPath = GetLogPath();
				string logFileName = GetFileName();
				string file = logPath + "\\" + logFileName;
				return file;
			}
			catch (Exception ex)
			{
				return "";
			}
		}

		//Writes the information to the log file
		private static void Log(string source, string type, string s)
		{
			Task.Factory.StartNew(() =>
			{
				string file = GetLogFileName();
				StringBuilder logEntryTmp = new StringBuilder();
				logEntryTmp.Append(DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss:fff "));
				logEntryTmp.Append(" \t");
				logEntryTmp.Append(type);
				logEntryTmp.Append(" \t");
				logEntryTmp.Append(source);
				logEntryTmp.Append(" \t");
				logEntryTmp.Append(s);
				logEntryTmp.Append(" \r\n");
				string logEntry = logEntryTmp.ToString();
				int retry = 0;
				bool fileWritten = false;
				while (retry < _retryAttempts && !fileWritten)
				{
					try
					{
						System.IO.File.AppendAllText(file, logEntry);
						fileWritten = true;
					}
					catch (Exception ex)
					{
						Task.Delay(_retryDelay);
						fileWritten = false;
						retry++;
					}

				}
			});
		}

		//Deletes the log files older than the specified number of days
		public static void DeleteOldLogs(int days)
		{
			Task.Factory.StartNew(() => {
				try
				{
					DirectoryInfo historyFolder = new DirectoryInfo(GetLogPath());
					FileInfo[] filesTmp = historyFolder.GetFiles(_logPrefix + "*." + _logExtension);
					DateTime lastDay = DateTime.Now.AddDays(-days);
					foreach (FileInfo file in filesTmp)
					{
						if (file.CreationTime < lastDay)
						{
							File.Delete(file.FullName);
							ActivityLog.Info("ACTIVITY LOG", "Removed old file " + file.Name);
						}
					}
					ActivityLog.Info("ACTIVITY LOG", "Removed old files complete");
				}
				catch (Exception ex)
				{
					ActivityLog.Error("ACTIVITY LOG", ex.Message);
				}
			});
		}

		//Logs a message with a log of type SENT
		public static void Sent(string source, string message)
		{
			string type = "SENT";
			Log(source, type, message);
		}

		//Logs a message with a log of type RECEIVED
		public static void Received(string source, string message)
		{
			string type = "RECEIVED";
			Log(source, type, message);
		}

		//Logs a message with a log of type INFO
		public static void Info(string source, string message)
		{
			string type = "INFO";
			Log(source, type, message);
		}

		//Logs a message with a log of type VERBOSE
		public static void Verbose(string source, string message)
		{
			string type = "VERBOSE";
			Log(source, type, message);
		}

		//Logs a message with a log of type ERROR
		public static void Error(string source, string message)
		{
			string type = "ERROR";
			Log(source, type, message);
		}

		//Logs a message with a log of type WARNING
		public static void Warning(string source, string message)
		{
			string type = "WARNING";
			Log(source, type, message);
		}

		//Logs a message with a log of type DEBUG
		public static void Debug(string source, string message)
		{
			string type = "DEBUG";
			Log(source, type, message);
		}
	}
}
