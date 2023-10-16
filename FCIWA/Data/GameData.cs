public class GameData
{
  public Column[] columns;
  public Attempts attempts;
  public string correctWord = "";
  //public Logger
  public void HandleWordInput(Word word)
  {
    if (word.word == correctWord)
    {
      cashedExecutionCode = ExecutionCode.CorrectWord;
    }
    else if (word.word.Length == correctWord.Length)
    {
      cashedExecutionCode = ExecutionCode.Mistake;
    }
    else
    {
      cashedExecutionCode = ExecutionCode.WrongInput;
    }
    cashedElement = word;
    ExecuteCashedData();
  }

  public void HandleHintInput(Hint hint, Column col)
  {
    if (hint.hintType == HintType.Dud)
    {
      cashedExecutionCode = ExecutionCode.HintDuds;
    }
    else
    {
      cashedExecutionCode = ExecutionCode.HintLife;
    }
    cashedElement = hint;
    cashedColumn = col;
    ExecuteCashedData();
  }

  public ExecutionCode cashedExecutionCode = ExecutionCode.WrongInput;
  public Element? cashedElement = null;
  public Column? cashedColumn = null;
  public GameState gameState = GameState.InProgress;
  public void ExecuteCashedData()
  {
    switch (cashedExecutionCode)
    {
      case ExecutionCode.Mistake:
        {
          if (attempts.LooseAttemptAndCheckForLoose())
          {
            gameState = GameState.Lost;
          }
          break;
        }
      case ExecutionCode.CorrectWord:
        {
          gameState = GameState.Won;
          break;
        }
      case ExecutionCode.HintDuds:
        {
          Column[] columnsToRemoveDuds = columns.Where(col => col.columnByElements.Cast<Element>().Count(el => el is Word && (el as Word).word != correctWord) > 0).ToArray();
          Random rnd = new Random();
          if (columnsToRemoveDuds.Length == 0)
          {
            break;
          }
          int randomIndex = rnd.Next(0, columnsToRemoveDuds.Length);
          columnsToRemoveDuds[randomIndex].RemoveDud(correctWord);
          cashedColumn.RemoveHint(cashedElement.coordinates);
          break;
        }
      case ExecutionCode.HintLife:
        {
          attempts.ResetAttempts();
          cashedColumn.RemoveHint(cashedElement.coordinates);
          break;
        }
    }
  }
}