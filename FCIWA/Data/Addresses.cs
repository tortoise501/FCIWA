//TODO: "address" generation is completely random now, it shouldn't be random, implement more fallout like address generation 
public class Addresses
{
  public List<string> addressesColumnData = new List<string>();
  public Addresses(int height, int width)
  {
    addressesColumnData = GenerateAddressesColumn(height, width);
  }

  List<string> GenerateAddressesColumn(int height, int width)
  {
    List<string> res = new List<string>();
    for (int i = 0; i < height; i++)
    {
      res.Add("");
      res[res.Count() - 1] = res.Last() + "0";
      res[res.Count() - 1] = res.Last() + "X";
      Random rnd = new Random();
      for (int j = 2; j < width; j++)
      {
        res[res.Count() - 1] = res.Last() + rnd.Next(0, 16).ToString("X")[0];
      }
    }

    return res;
  }
}