namespace Orleans.Serialization.FluentResults.Tests;
internal class InheritanceSerializationGrain : IInheritanceSerializationGrain
{
  public Task<ErrorChild> GetErrorChild(string extra)
  {
    var errorChild = new ErrorChild()
    { Extra = extra };
    return Task.FromResult(errorChild);
  }

  public Task<ExceptionalErrorChild> GetExceptionalErrorChild(string extra)
  {
    var exceptionalErrorChild = new ExceptionalErrorChild()
    {
      Extra = extra
    };
    return Task.FromResult(exceptionalErrorChild);
  }

  public Task<SuccessChild> GetSuccessChild(string extra)
  {
    var successChild = new SuccessChild()
    {
      Extra = extra
    };
    return Task.FromResult(successChild);
  }
}
