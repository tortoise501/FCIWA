public class SuperGameGrid : IGameGrid
{
  public SuperGameGrid(IGameCell[] cells)
  {
    (this as IGameGrid).InitializeGrid(cells);
  }
  IGameCell[] IGameGrid.Cells { get; set; }
  IGameCell[][] IGameGrid.Triples { get; set; }
}