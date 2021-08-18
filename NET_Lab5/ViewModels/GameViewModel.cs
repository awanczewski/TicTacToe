using NET_Lab5.Models;
using NET_Lab5.Enums;
using NET_Lab5.Commands;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace NET_Lab5.ViewModels
{
    class GameViewModel : ViewModelBase
    {
        private Game game;
        private RelayCommand makeMoveCommand;
        

        public GameViewModel()
        {
            game = new Game();
            MakeMoveCommand = new RelayCommand(Move, CanMove);
        }

        public ObservableCollection<SymbolCell> Cells
        {
            get => game.Cells;
            set
            {
                if (game.Cells != value)
                {
                    game.Cells = value;
                    OnPropertyChanged(nameof(Cells));
                }
            }
        }

        public ObservableCollection<BackgroundCell> BackgroundCells
        {
            get => game.BackgroundCells;
            set
            {
                if (game.BackgroundCells != value)
                {
                    game.BackgroundCells = value;
                    OnPropertyChanged(nameof(BackgroundCells));
                }
            }
        }

        public SymbolCell CurrentPlayerSign
        {
            get => game.CurrentPlayerSign;
            set
            {
                if (game.CurrentPlayerSign != value)
                {
                    game.CurrentPlayerSign = value;
                    OnPropertyChanged(nameof(CurrentPlayerSign));
                }
            }
        }

        public RelayCommand MakeMoveCommand { get => makeMoveCommand; set => makeMoveCommand = value; }

        public bool CanMove(object i)
        {
            return (Cells[int.Parse(i.ToString())] == SymbolCell.EMPTY) || IsOver(); 
        }

        public void Move(object i)
        {
            if (IsOver())
            {
                game = new Game();
                OnPropertyChanged(nameof(BackgroundCells));
                OnPropertyChanged(nameof(Cells));
            }
            else
            {
                Cells[int.Parse(i.ToString())] = CurrentPlayerSign;
                CurrentPlayerSign = (CurrentPlayerSign == SymbolCell.O ? SymbolCell.X : SymbolCell.O);
            }
        }

        public bool IsOver()
        {

            for (int i = 0; i < 3; i++)
            {
                if (Cells[i] != SymbolCell.EMPTY && Helpers.Helper.AreAllEqual(new object[] { Cells[i], Cells[i + 3], Cells[i + 6] }))
                {
                    BackgroundCells[i] = BackgroundCell.WINNER;
                    BackgroundCells[i + 3] = BackgroundCell.WINNER;
                    BackgroundCells[i + 6] = BackgroundCell.WINNER;
                    return true;
                }

                if (Cells[3*i] != SymbolCell.EMPTY && Helpers.Helper.AreAllEqual(new object[] { Cells[3 * i], Cells[3 * i + 1], Cells[3 * i + 2] }))
                {
                    BackgroundCells[3 * i] = BackgroundCell.WINNER;
                    BackgroundCells[3 * i + 1] = BackgroundCell.WINNER;
                    BackgroundCells[3 * i + 2] = BackgroundCell.WINNER;
                    return true;
                }
            }

            if(Cells[0] != SymbolCell.EMPTY && Helpers.Helper.AreAllEqual(new object[] { Cells[0], Cells[4], Cells[8] })) 
            {
                BackgroundCells[0] = BackgroundCell.WINNER;
                BackgroundCells[4] = BackgroundCell.WINNER;
                BackgroundCells[8] = BackgroundCell.WINNER;
                return true;
            }

            if (Cells[2] != SymbolCell.EMPTY && Helpers.Helper.AreAllEqual(new object[] { Cells[2], Cells[4], Cells[6] }))
            {
                BackgroundCells[2] = BackgroundCell.WINNER;
                BackgroundCells[4] = BackgroundCell.WINNER;
                BackgroundCells[6] = BackgroundCell.WINNER;
                return true;
            }
            return IsDraw();
        }

        public bool IsDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Cells[i] == SymbolCell.EMPTY)
                {
                    return false;
                }
            }

            for(int i = 0; i < 9; i++)
            {
                BackgroundCells[i] = BackgroundCell.DRAW;
            }

            return true;
        }
    }
}
