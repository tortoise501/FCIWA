public class GameLogger
{
  public Queue<string> Logs = new Queue<string>();
  public int maxLength;
  public string selectedElement = "";

  public GameLogger(int maxLength)
  {
    this.maxLength = maxLength;
  }
  public void SetSelectedElement(string element)
  {
    selectedElement = ">" + element;
  }

  public void AddGameLogs(string str)
  {
    string[] logs = str.Split('\n');
    foreach (string log in logs)
    {
      Logs.Enqueue(log);
    }
    while (Logs.Count() > maxLength - 2)
    {
      Logs.Dequeue();
    }
  }
}