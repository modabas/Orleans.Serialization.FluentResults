using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;

[GenerateSerializer]
internal class SuccessChild : Success
{
  [Id(0)]
  public string Extra { get; set; } = string.Empty;

  public SuccessChild()
    : base("Success Message")
  {
  }
}
