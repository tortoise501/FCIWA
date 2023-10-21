static class TTTGameManager
{
  public static Cell CurrentPlayer = Cell.X;
  public static int CurrentSmallGame = -1;
  public static Cell GetPlayerAndMove()
  {
    Cell res = CurrentPlayer;
    if (CurrentPlayer == Cell.X)
    {
      CurrentPlayer = Cell.O;
    }
    else
    {
      CurrentPlayer = Cell.X;
    }
    return res;
  }
}