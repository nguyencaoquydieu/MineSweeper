namespace MineSweeper.Session
{
    internal partial class StringFormatContainer
    {
        internal static StringFormatContainer stringFormatContainer
        {
            get
            {
                if (_stringFormatContainer is null)
                {
                    _stringFormatContainer = new StringFormatContainer();
                }

                return _stringFormatContainer;
            }
        }
        private static StringFormatContainer _stringFormatContainer;
    }

    internal partial class StringFormatContainer
    {
        /// <summary>
        /// <b>
        /// <br>sExceptionMessage =</br>
        /// <br>"{0}\n\n\n" +</br>
        /// <br>"File: {1}\n" +</br>
        /// <br>"FullMethod: {2}"</br>
        /// <br>"{3}";</br>
        /// </b>
        /// </summary>
        internal string sExceptionMessage
        {
            get
            {
                if (string.IsNullOrEmpty(_sExceptionMessage))
                {
                    _sExceptionMessage = "{0}\n\n\n" +
                                         "File: {1}\n" +
                                         "FullMethod: {2}\n" +
                                         "{3}";
                }

                return _sExceptionMessage;
            }
        }
        private string _sExceptionMessage;
    }
}
