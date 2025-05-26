using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;
internal class ResultSerializationGrain : IResultSerializationGrain
{
  private readonly Success success1, success2;
  private readonly SuccessChild success3;
  private readonly Error error1, error2;
  private readonly ErrorChild error3;
  private readonly ExceptionalErrorChild error4;
  private readonly ExceptionalError error5;

  public ResultSerializationGrain()
  {
    success1 = new Success("Success 1");
    success2 = new Success("Success 2");
    success3 = new SuccessChild() { Extra = "Success 3 Extra" };
    error1 = new Error("Error 1");
    error2 = new Error("Error 2").CausedBy(error1);
    error3 = new ErrorChild() { Extra = "Error 3 Extra" };
    error4 = new ExceptionalErrorChild() { Extra = "Error 4 Extra" };
    error5 = new ExceptionalError(new ApplicationException("Error 5", new ArgumentException("Error 5 Inner")));
  }

  public Task<Result> FailedResult()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOriginal = Result.Fail(errors.ToArray());

    // Act
    return Task.FromResult(resultOriginal);
  }

  public Task<Result> OkResult()
  {
    // Arrange
    var resultOriginal = Result.Ok().WithSuccess(success1).WithSuccess(success2).WithSuccess(success3);

    // Act
    return Task.FromResult(resultOriginal);
  }
}
