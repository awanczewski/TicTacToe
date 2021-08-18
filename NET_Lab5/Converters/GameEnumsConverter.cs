using NET_Lab5.Enums;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace NET_Lab5.Converters
{
    class GameEnumsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is SymbolCell)
            {
                SymbolCell symbolCell = (SymbolCell)value;
                switch (targetType.FullName)
                {
                    case "System.Object":
                        switch (symbolCell)
                        {
                            case SymbolCell.EMPTY:
                                return "";
                            case SymbolCell.O:
                                return "O";
                            case SymbolCell.X:
                                return "X";
                        }
                        break;

                    case "System.Windows.Media.Brush":
                        switch (symbolCell)
                        {
                            case SymbolCell.EMPTY:
                                return Brushes.Black;
                            case SymbolCell.O:
                                return Brushes.Red;
                            case SymbolCell.X:
                                return Brushes.Blue;
                        }
                        break;
                }
            }
            else if(value is BackgroundCell)
            {
                BackgroundCell backgroundCell = (BackgroundCell)value;
                switch(backgroundCell)
                {
                    case BackgroundCell.DRAW:
                        return Brushes.Orange;
                    case BackgroundCell.EMPTY:
                        return Brushes.White;
                    case BackgroundCell.WINNER:
                        return Brushes.Green;
                }
            }


            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
