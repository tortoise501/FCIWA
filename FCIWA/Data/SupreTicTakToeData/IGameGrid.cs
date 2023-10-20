public interface IGameGrid
{
  public IGameCell[] Cells { get; protected set; }
  public IGameCell[][] Triples { get; protected set; }
  public void InitializeGrid(IGameCell[] cells)
  {
    if (cells.Length < 9) return;
    Cells = cells;
    Triples = new IGameCell[8][];
    for (int i = 0; i < Triples.Length; i++)
    {
      Triples[i] = new IGameCell[3];
    }
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        Triples[i][j] = Cells[(i * 3) + j];//adding horizontal lines
        Triples[i][j] = Cells[i + (j * 3)];//adding vertical lines
      }
      Triples[6][i] = Cells[i * 4];//top-left to bottom-right line
      Triples[7][i] = Cells[(i + 1) * 2];//top-right to bottom-left line
    }
  }
  public void OccupyOnIndex(int i, Cell state)
  {
    if (i >= Cells.Length || Cells[i] == null) return;
    Cells[i].OccupySelf(state);
  }
  public Cell ValidateGrid()
  {
    foreach (IGameCell[] line in Triples)
    {
      if (line.All(cell => cell.State == line[0].State))
      {
        return line[0].State;
      }
    }
    return Cell.None;
  }
}