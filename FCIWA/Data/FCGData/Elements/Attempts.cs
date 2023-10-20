
using System.Security.Cryptography.X509Certificates;

public class Attempts
{
  int maxAttempts;
  public int attemptsLeft { get; private set; }
  public Attempts(int maxAttempts)
  {
    this.maxAttempts = maxAttempts;
    attemptsLeft = maxAttempts;
  }


  public bool LooseAttemptAndCheckForLoose()
  {
    attemptsLeft--;
    if (attemptsLeft <= 0)
    {
      return true;
    }
    return false;
  }
  public void ResetAttempts()
  {
    attemptsLeft = maxAttempts;
  }
}