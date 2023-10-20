public interface IGameCell
{
  public Cell State { get; protected set; }
  public void OccupySelf(Cell state)
  {
    State = state;
  }

}