using System.Windows.Controls;

namespace MineSweeper.DTO
{
    internal partial class CellDTO
    {
        internal CellDTO(Button btnCell, Label lbCell)
        {
            this.btnCell = btnCell;
            this.lbCell = lbCell;
        }
    }

    internal partial class CellDTO
    {
        internal readonly Button btnCell;
        internal readonly Label lbCell;
    }

    internal partial class CellDTO
    {
        public override string ToString()
        {
            return "["
                    + $"btnCell={btnCell.Visibility}, "
                    + $"lbCell={lbCell.Content}, "
                 + "]";
        }
    }
}
