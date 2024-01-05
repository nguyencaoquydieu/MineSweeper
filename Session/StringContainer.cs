namespace MineSweeper.Session
{
    internal partial class StringContainer
    {
        internal static StringContainer stringContainer
        {
            get
            {
                if (_stringContainer is null)
                {
                    _stringContainer = new StringContainer();
                }

                return _stringContainer;
            }
        }
        private static StringContainer _stringContainer;
    }

    internal partial class StringContainer
    {
        /// <summary>
        /// <b>
        /// <br>"Start Auto";</br>
        /// </b>
        /// </summary>
        internal string sStartAuto
        {
            get
            {
                if (string.IsNullOrEmpty(_sStartAuto))
                {
                    _sStartAuto = "Start Auto";
                }

                return _sStartAuto;
            }
        }
        private string _sStartAuto;

        /// <summary>
        /// <b>
        /// <br>"Stop Auto";</br>
        /// </b>
        /// </summary>
        internal string sStopAuto
        {
            get
            {
                if (string.IsNullOrEmpty(_sStopAuto))
                {
                    _sStopAuto = "Stop Auto";
                }

                return _sStopAuto;
            }
        }
        private string _sStopAuto;
    }
}
