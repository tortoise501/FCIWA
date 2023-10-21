using System.Diagnostics;

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
    for (int x = 0; x < 3; x++)
    {
      for (int y = 0; y < 3; y++)
      {
        Triples[x][y] = Cells[(x * 3) + y];//adding horizontal lines
        Triples[x + 3][y] = Cells[x + (y * 3)];//adding vertical lines
      }
      Triples[6][x] = Cells[x * 4];//top-left to bottom-right line
      Triples[7][x] = Cells[(x + 1) * 2];//top-right to bottom-left line
    }
    string ex = "\n";
    foreach (IGameCell[] line in Triples)
    {
      foreach (IGameCell c in line)
      {
        ex += c.State == Cell.X ? "X" : c.State == Cell.O ? "O" : c.State == Cell.None ? "N" : "E";
      }
      ex += "\n";
    }
    // throw new Exception(ex);
    Debug.WriteLine(ex);
  }
  public void OccupyOnIndex(int i, Cell state)
  {
    if (i >= Cells.Length || Cells[i] == null) return;
    Cells[i].OccupySelf(state);
  }
  public Cell ValidateGrid()
  {
    try
    {
      foreach (IGameCell[] line in Triples)
      {
        if (line.All(cell => cell.State == line[0].State) && line[0].State != Cell.None)
        {
          return line[0].State;
        }
      }
      string ex = "\n";
      foreach (IGameCell[] line in Triples)
      {
        foreach (IGameCell c in line)
        {
          ex += c.State == Cell.X ? "X" : c.State == Cell.O ? "O" : c.State == Cell.None ? "N" : "E";
        }
        ex += "\n";
      }
    }
    catch (Exception e)//Idk but it fixed the problem
    {
      string ex = "\n";
      foreach (IGameCell[] line in Triples)
      {
        foreach (IGameCell c in line)
        {
          ex += c.State == Cell.X ? "X" : c.State == Cell.O ? "O" : c.State == Cell.None ? "N" : "E";
        }
        ex += "\n";
      }
      throw new Exception(e.Message + ex);
    }
    return Cell.None;
  }
}