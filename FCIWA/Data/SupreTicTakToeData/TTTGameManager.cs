static class TTTGameManager
{
  public static Cell CurrentPlayer = Cell.X;
  static int currentSmallGame = -1;
  public static int CurrentSmallGame { get { return filledSmallGames.Contains(currentSmallGame) ? -1 : currentSmallGame; } set { currentSmallGame = value; } }
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
  public static HashSet<int> filledSmallGames = new HashSet<int>() { 9 };
}