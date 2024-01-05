using MineSweeper.DTO;
using MineSweeper.Module;
using MineSweeper.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MineSweeper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public partial class MainWindow
    {
        private ExceptionManager exceptionManager
        {
            get
            {
                if (_exceptionManager is null)
                {
                    _exceptionManager = ExceptionManager.exceptionManager;
                }

                return _exceptionManager;
            }
        }
        private ExceptionManager _exceptionManager;

        private StringContainer stringContainer
        {
            get
            {
                if (_stringContainer is null)
                {
                    _stringContainer = StringContainer.stringContainer;
                }

                return _stringContainer;
            }
        }
        private StringContainer _stringContainer;
    }

    public partial class MainWindow
    {
        private List<CellDTO> lcellDTO
        {
            get
            {
                if (_lcellDTO is null)
                {
                    _lcellDTO = new List<CellDTO>()
                    {
                        new CellDTO(btnCell0x0, lbCell0x0),
                        new CellDTO(btnCell0x1, lbCell0x1),
                        new CellDTO(btnCell0x2, lbCell0x2),
                        new CellDTO(btnCell0x3, lbCell0x3),
                        new CellDTO(btnCell0x4, lbCell0x4),
                        new CellDTO(btnCell0x5, lbCell0x5),
                        new CellDTO(btnCell0x6, lbCell0x6),
                        new CellDTO(btnCell0x7, lbCell0x7),
                        new CellDTO(btnCell1x0, lbCell1x0),
                        new CellDTO(btnCell1x1, lbCell1x1),
                        new CellDTO(btnCell1x2, lbCell1x2),
                        new CellDTO(btnCell1x3, lbCell1x3),
                        new CellDTO(btnCell1x4, lbCell1x4),
                        new CellDTO(btnCell1x5, lbCell1x5),
                        new CellDTO(btnCell1x6, lbCell1x6),
                        new CellDTO(btnCell1x7, lbCell1x7),
                        new CellDTO(btnCell2x0, lbCell2x0),
                        new CellDTO(btnCell2x1, lbCell2x1),
                        new CellDTO(btnCell2x2, lbCell2x2),
                        new CellDTO(btnCell2x3, lbCell2x3),
                        new CellDTO(btnCell2x4, lbCell2x4),
                        new CellDTO(btnCell2x5, lbCell2x5),
                        new CellDTO(btnCell2x6, lbCell2x6),
                        new CellDTO(btnCell2x7, lbCell2x7),
                        new CellDTO(btnCell3x0, lbCell3x0),
                        new CellDTO(btnCell3x1, lbCell3x1),
                        new CellDTO(btnCell3x2, lbCell3x2),
                        new CellDTO(btnCell3x3, lbCell3x3),
                        new CellDTO(btnCell3x4, lbCell3x4),
                        new CellDTO(btnCell3x5, lbCell3x5),
                        new CellDTO(btnCell3x6, lbCell3x6),
                        new CellDTO(btnCell3x7, lbCell3x7),
                        new CellDTO(btnCell4x0, lbCell4x0),
                        new CellDTO(btnCell4x1, lbCell4x1),
                        new CellDTO(btnCell4x2, lbCell4x2),
                        new CellDTO(btnCell4x3, lbCell4x3),
                        new CellDTO(btnCell4x4, lbCell4x4),
                        new CellDTO(btnCell4x5, lbCell4x5),
                        new CellDTO(btnCell4x6, lbCell4x6),
                        new CellDTO(btnCell4x7, lbCell4x7),
                        new CellDTO(btnCell5x0, lbCell5x0),
                        new CellDTO(btnCell5x1, lbCell5x1),
                        new CellDTO(btnCell5x2, lbCell5x2),
                        new CellDTO(btnCell5x3, lbCell5x3),
                        new CellDTO(btnCell5x4, lbCell5x4),
                        new CellDTO(btnCell5x5, lbCell5x5),
                        new CellDTO(btnCell5x6, lbCell5x6),
                        new CellDTO(btnCell5x7, lbCell5x7),
                    };
                }

                return _lcellDTO;
            }
        }
        private List<CellDTO> _lcellDTO;

        private int[] __ariIndex
        {
            get
            {
                if (_ariIndex is null)
                {
                    _ariIndex = new int[9];
                }

                return _ariIndex;
            }
        }
        private int[] _ariIndex;

        private Random randomSeeder
        {
            get
            {
                if (_randomSeeder is null)
                {
                    _randomSeeder = new Random();
                }

                return _randomSeeder;
            }
        }
        private Random _randomSeeder;

        private Thread threadDoWork
        {
            get
            {
                if (_threadDoWork is null)
                {
                    _threadDoWork = new Thread(() => { });
                }

                return _threadDoWork;
            }
            set => _threadDoWork = value;
        }
        private Thread _threadDoWork;

        public string sContentBtnStartGame
        {
            get => _sContentBtnStartGame;
            set
            {
                if (_sContentBtnStartGame != value)
                {
                    _sContentBtnStartGame = value;

                    OnPropertyChanged(nameof(sContentBtnStartGame));
                }
            }
        }
        private string _sContentBtnStartGame = StringContainer.stringContainer
                                                              .sStartAuto;

        private void btnCell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnSender = sender as Button;

                for (int x = 0; x < lcellDTO.Count; x++)
                {
                    if (lcellDTO[x].btnCell == btnSender)
                    {
                        if (lcellDTO[x].lbCell
                                       .Content
                                       .ToString() == "X")
                        {
                            OpenAllCellLose();
                        }

                        else
                        {
                            lcellDTO[x].btnCell
                                       .Visibility = Visibility.Hidden;

                            int iCellLeft = lcellDTO.Count
                                                    (
                                                        y => y.btnCell
                                                              .Visibility == Visibility.Visible
                                                    );

                            if (iCellLeft == 11)
                            {
                                OpenAllCellWin();
                            }
                        }

                        break;
                    }
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void btnResetGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReloadGame();
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void btnCell_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                Button btnSender = sender as Button;

                if (btnSender.Visibility == Visibility.Hidden)
                {
                    for (int x = 0; x < lcellDTO.Count; x++)
                    {
                        if (lcellDTO[x].btnCell == btnSender)
                        {
                            if (lcellDTO[x].lbCell
                                           .Content
                                           .ToString() == string.Empty)
                            {
                                int[] ariIndex = new int[9];
                                ariIndex[0] = x - 9;
                                ariIndex[1] = x - 8;
                                ariIndex[2] = x - 7;
                                ariIndex[3] = x - 1;
                                ariIndex[4] = x;
                                ariIndex[5] = x + 1;
                                ariIndex[6] = x + 7;
                                ariIndex[7] = x + 8;
                                ariIndex[8] = x + 9;

                                for (int y = 0; y < ariIndex.Length; y++)
                                {
                                    #region Check y

                                    if (y == 4)
                                    {
                                        continue;
                                    }

                                    #endregion

                                    #region Check x

                                    if (x == 0)
                                    {
                                        if (y == 0
                                         || y == 1
                                         || y == 2
                                         || y == 3
                                         || y == 6)
                                        {
                                            continue;
                                        }
                                    }
                                    else if (x == 7)
                                    {
                                        if (y == 0
                                         || y == 1
                                         || y == 2
                                         || y == 5
                                         || y == 8)
                                        {
                                            continue;
                                        }
                                    }
                                    else if (x == 40)
                                    {
                                        if (y == 0
                                         || y == 3
                                         || y == 6
                                         || y == 7
                                         || y == 8)
                                        {
                                            continue;
                                        }
                                    }
                                    else if (x == 47)
                                    {
                                        if (y == 2
                                         || y == 5
                                         || y == 6
                                         || y == 7
                                         || y == 8)
                                        {
                                            continue;
                                        }
                                    }

                                    else if (x == 8 || x == 16 || x == 24 || x == 32)
                                    {
                                        if (y == 0
                                         || y == 3
                                         || y == 6)
                                        {
                                            continue;
                                        }
                                    }
                                    else if (x == 15 || x == 23 || x == 31 || x == 39)
                                    {
                                        if (y == 2
                                         || y == 5
                                         || y == 8)
                                        {
                                            continue;
                                        }
                                    }

                                    else if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6)
                                    {
                                        if (y == 0
                                         || y == 1
                                         || y == 2)
                                        {
                                            continue;
                                        }
                                    }
                                    else if (x == 41 || x == 42 || x == 43 || x == 44 || x == 45 || x == 46)
                                    {
                                        if (y == 6
                                         || y == 7
                                         || y == 8)
                                        {
                                            continue;
                                        }
                                    }

                                    #endregion

                                    if (ariIndex[y] >= 0
                                     && ariIndex[y] <= 47)
                                    {
                                        if (lcellDTO[ariIndex[y]].lbCell
                                                                 .Content
                                                                 .ToString() != "X")
                                        {
                                            lcellDTO[ariIndex[y]].btnCell
                                                                 .Visibility = Visibility.Hidden;
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Top =
                Left = 0;

                _ = sContentBtnStartGame;

                ReloadGame();
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void ReloadGame()
        {
            try
            {
                for (int x = 0; x < lcellDTO.Count; x++)
                {
                    lcellDTO[x].btnCell
                               .Visibility = Visibility.Visible;

                    lcellDTO[x].lbCell
                               .Content = string.Empty;
                    lcellDTO[x].lbCell
                               .Background = Brushes.Transparent;
                }

                int iIndex;

                for (int x = 0; x < 11; x++)
                {
                    iIndex = randomSeeder.Next
                                         (
                                             0,
                                             lcellDTO.Count - 1
                                         );

                    lcellDTO[iIndex].lbCell
                                    .Content = "X";
                    lcellDTO[iIndex].lbCell
                                    .Background = Brushes.Red;
                }

                int iAmount;

                for (int x = 0; x < lcellDTO.Count; x++)
                {
                    if (lcellDTO[x].lbCell
                                   .Content
                                   .ToString() != "X")
                    {
                        int[] ariIndex = new int[9];
                        ariIndex[0] = x - 9;
                        ariIndex[1] = x - 8;
                        ariIndex[2] = x - 7;
                        ariIndex[3] = x - 1;
                        ariIndex[4] = x;
                        ariIndex[5] = x + 1;
                        ariIndex[6] = x + 7;
                        ariIndex[7] = x + 8;
                        ariIndex[8] = x + 9;

                        iAmount = 0;

                        for (int y = 0; y < ariIndex.Length; y++)
                        {
                            #region Check y

                            if (y == 4)
                            {
                                continue;
                            }

                            #endregion

                            #region Check x

                            if (x == 0)
                            {
                                if (y == 0
                                 || y == 1
                                 || y == 2
                                 || y == 3
                                 || y == 6)
                                {
                                    continue;
                                }
                            }
                            else if (x == 7)
                            {
                                if (y == 0
                                 || y == 1
                                 || y == 2
                                 || y == 5
                                 || y == 8)
                                {
                                    continue;
                                }
                            }
                            else if (x == 40)
                            {
                                if (y == 0
                                 || y == 3
                                 || y == 6
                                 || y == 7
                                 || y == 8)
                                {
                                    continue;
                                }
                            }
                            else if (x == 47)
                            {
                                if (y == 2
                                 || y == 5
                                 || y == 6
                                 || y == 7
                                 || y == 8)
                                {
                                    continue;
                                }
                            }

                            else if (x == 8 || x == 16 || x == 24 || x == 32)
                            {
                                if (y == 0
                                 || y == 3
                                 || y == 6)
                                {
                                    continue;
                                }
                            }
                            else if (x == 15 || x == 23 || x == 31 || x == 39)
                            {
                                if (y == 2
                                 || y == 5
                                 || y == 8)
                                {
                                    continue;
                                }
                            }

                            else if (x == 1 || x == 2 || x == 3 || x == 4 || x == 5 || x == 6)
                            {
                                if (y == 0
                                 || y == 1
                                 || y == 2)
                                {
                                    continue;
                                }
                            }
                            else if (x == 41 || x == 42 || x == 43 || x == 44 || x == 45 || x == 46)
                            {
                                if (y == 6
                                 || y == 7
                                 || y == 8)
                                {
                                    continue;
                                }
                            }

                            #endregion

                            if (ariIndex[y] >= 0
                             && ariIndex[y] <= 47)
                            {
                                if (lcellDTO[ariIndex[y]].lbCell
                                                         .Content
                                                         .ToString() == "X")
                                {
                                    iAmount++;
                                }
                            }
                        }

                        lcellDTO[x].lbCell
                                   .Content = iAmount > 0 ? iAmount.ToString()
                                                          : string.Empty;
                    }
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void OpenAllCellLose()
        {
            try
            {
                for (int x = 0; x < lcellDTO.Count; x++)
                {
                    lcellDTO[x].btnCell
                               .Visibility = Visibility.Hidden;
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void OpenAllCellWin()
        {
            try
            {
                for (int x = 0; x < lcellDTO.Count; x++)
                {
                    lcellDTO[x].btnCell
                               .Visibility = Visibility.Hidden;

                    if (lcellDTO[x].lbCell
                                   .Content
                                   .ToString() == "X")
                    {
                        lcellDTO[x].lbCell
                                   .Background = Brushes.Green;
                    }
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnSender = sender as Button;

                sContentBtnStartGame = sContentBtnStartGame == stringContainer.sStartAuto ? stringContainer.sStopAuto
                                                                                          : stringContainer.sStartAuto;

                if (sContentBtnStartGame == stringContainer.sStopAuto)
                {
                    if (threadDoWork.IsAlive is false)
                    {
                        threadDoWork = new Thread(() => { AutoMiner(); });
                        threadDoWork.Start();
                    }
                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
        private void AutoMiner()
        {
            try
            {
                while (true)
                {
                    if (sContentBtnStartGame != stringContainer.sStopAuto)
                    {
                        break;
                    }

                    Thread.Sleep(500);


                }
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
            finally
            {
                sContentBtnStartGame = stringContainer.sStartAuto;
            }
        }
        private void btnStartGame_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnSender = sender as Button;

                btnSender.DataContext = this;
            }
            catch (Exception exceptionError)
            {
                exceptionManager.exceptionError = exceptionError;
            }
        }
    }

    public partial class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke
                            (
                                this,
                                new PropertyChangedEventArgs(sProperty)
                            );
        }
    }
}
