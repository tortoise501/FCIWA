public class SmallGame : IGameCell, IGameGrid
{
  public SmallGame(IGameCell[] cells)
  {
    (this as IGameGrid).InitializeGrid(cells);
  }
  Cell IGameCell.State { get; set; }
  IGameCell[] IGameGrid.Cells { get; set; }
  IGameCell[][] IGameGrid.Triples { get; set; }
}