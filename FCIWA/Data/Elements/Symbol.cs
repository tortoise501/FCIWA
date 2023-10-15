public class Symbol : Element
{
  public Word? belongsToWord { get; private set; }
  public Symbol(char value, Coordinates coordinates, Word? masterElement = null) : base(value, coordinates)
  {
    this.belongsToWord = masterElement;
    elementType = ElementType.Symbol;
  }
  public override void SelectElement()
  {
    if (belongsToWord != null)
    {
      belongsToWord.SelectElement();
    }
    else
    {
      currentState = "hoveredElement";
    }
  }
  public override void UnSelectElement()
  {
    if (belongsToWord != null)
    {
      belongsToWord.UnSelectElement();
    }
    else
    {
      currentState = "unhoveredElement";
    }
  }
}