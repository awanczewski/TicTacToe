using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET_Lab5.Enums;

namespace NET_Lab5.Models
{
    class Game
    {
        private ObservableCollection<SymbolCell> cells;
        private ObservableCollection<BackgroundCell> backgroundCells;
        private SymbolCell currentPlayerSign;

        public Game()
        {
            cells = new ObservableCollection<SymbolCell>()
            {
                SymbolCell.EMPTY,
                SymbolCell.EMPTY,
                SymbolCell.EMPTY,
                
                SymbolCell.EMPTY,
                SymbolCell.EMPTY,
                SymbolCell.EMPTY,

                SymbolCell.EMPTY,
                SymbolCell.EMPTY,
                SymbolCell.EMPTY
            };

            backgroundCells = new ObservableCollection<BackgroundCell>()
            {
                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,

                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,

                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,
                BackgroundCell.EMPTY,
            };

            currentPlayerSign = SymbolCell.O;
    }

        public ObservableCollection<SymbolCell> Cells { get => cells; set => cells = value; }

        public ObservableCollection<BackgroundCell> BackgroundCells { get => backgroundCells; set => backgroundCells = value; }

        public SymbolCell CurrentPlayerSign { get => currentPlayerSign; set => currentPlayerSign = value; }
    }
}
