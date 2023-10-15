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

  public void HandleHintInput(Hint hint)
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
    ExecuteCashedData();
  }

  public ExecutionCode cashedExecutionCode = ExecutionCode.WrongInput;
  public Element? cashedElement = null;
  bool isGameLost = false;
  bool isGameWon = false;
  public void ExecuteCashedData()
  {
    switch (cashedExecutionCode)
    {
      case ExecutionCode.Mistake:
        {
          isGameLost = attempts.LooseAttemptAndCheckForLoose();
          break;
        }
      case ExecutionCode.CorrectWord:
        {
          isGameWon = true;
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
          break;
        }
      case ExecutionCode.HintLife:
        {
          attempts.ResetAttempts();
          break;
        }
    }
  }
}