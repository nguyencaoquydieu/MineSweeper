using MineSweeper.Session;
using System;
using System.Windows;

namespace MineSweeper.Module
{
    internal partial class ExceptionManager
    {
        internal static ExceptionManager exceptionManager
        {
            get
            {
                if (_exceptionManager is null)
                {
                    _exceptionManager = new ExceptionManager();
                }

                return _exceptionManager;
            }
        }
        private static ExceptionManager _exceptionManager;
    }

    internal partial class ExceptionManager
    {
        private StringFormatContainer stringFormatContainer
        {
            get
            {
                if (_stringFormatContainer is null)
                {
                    _stringFormatContainer = StringFormatContainer.stringFormatContainer;
                }

                return _stringFormatContainer;
            }
            set { _stringFormatContainer = value; }
        }
        private StringFormatContainer _stringFormatContainer;
    }

    internal partial class ExceptionManager
    {
        internal Exception exceptionError
        {
            set
            {
                string sExceptionMessage = string.Format
                                                 (
                                                     stringFormatContainer.sExceptionMessage,
                                                     value.Message,
                                                     value.TargetSite
                                                          .DeclaringType
                                                          .FullName,
                                                     value.TargetSite,
                                                     value.StackTrace
                                                 );

                _ = MessageBox.Show(sExceptionMessage);
            }
        }
    }
}
