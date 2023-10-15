public class MasterElement : Element
{
  public List<Element> slaveElements { get; protected set; }
  public int length { get; protected set; }
  public MasterElement(char value, Coordinates coordinates, List<Element>? slaveElements = null) : base(value, coordinates)
  {
    if (slaveElements == null)
    {
      slaveElements = new List<Element>();
    }
    this.slaveElements = slaveElements;
    length = slaveElements.Count();
  }
  public void AddSlaveElement(Element element)
  {
    if (element is Word && this is Word)
    {
      throw new Exception("okPonException");
    }
    slaveElements.Add(element);
    element.elementType = elementType == ElementType.Word ? ElementType.Word : element.elementType;
    length++;
  }
  public override string ToString()
  {
    string slavesString = "";
    slaveElements.ForEach(x => slavesString += x.value.ToString());
    return value.ToString() + slavesString;
  }
  public override void SelectElement()
  {
    currentState = "hoveredElement";
    slaveElements.ForEach(slave => slave.currentState = "hoveredElement");
  }
  public override void UnSelectElement()
  {
    currentState = "unhoveredElement";
    slaveElements.ForEach(slave => slave.currentState = "unhoveredElement");
  }
}