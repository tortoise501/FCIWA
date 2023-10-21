public class GameCell : IGameCell
{
  Cell IGameCell.State { get; set; } = Cell.None;
}