using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;
internal class ResultOfTSerializationGrain : IResultOfTSerializationGrain
{
  private readonly Success success1, success2;
  private readonly SuccessChild success3;
  private readonly Error error1, error2;
  private readonly ErrorChild error3;
  private readonly ExceptionalErrorChild error4;
  private readonly ExceptionalError error5;

  public ResultOfTSerializationGrain()
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

  public Task<Result<ValueClass>> FailedResultWithValueClass()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Fail<ValueClass>(errors.ToArray()).WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> FailedResultWithValueRecord()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Fail<ValueRecord>(errors.ToArray()).WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> FailedResultWithValueStruct()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Fail<ValueStruct>(errors.ToArray()).WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueClass>> OkResultWithValueClassAndReasons()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." })
      .WithSuccess(success1)
      .WithSuccess(success2)
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> OkResultWithValueRecordAndReasons()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueRecord(42, "Meaning of life."))
      .WithSuccess(success1)
      .WithSuccess(success2)
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> OkResultWithValueStructAndReasons()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithSuccess(success1)
      .WithSuccess(success2)
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueClass>> OkResultWithValueClass()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." });

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> OkResultWithValueRecord()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueRecord(42, "Meaning of life."));

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> OkResultWithValueStruct()
  {
    // Arrange
    var resultOfTOriginal = Result.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." });

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueClass>> FailedResultWithValueInValueClass()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Ok(
      new ValueClass() { Number = 42, String = "Meaning of life." })
      .WithReasons(errors.ToArray())
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueRecord>> FailedResultWithValueInValueRecord()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Ok(
      new ValueRecord(42, "Meaning of life."))
      .WithReasons(errors.ToArray())
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }

  public Task<Result<ValueStruct>> FailedResultWithValueInValueStruct()
  {
    // Arrange
    var errors = new List<IError> { error1, error2, error3, error4, error5 };
    var resultOfTOriginal = Result.Ok(
      new ValueStruct() { Number = 42, String = "Meaning of life." })
      .WithReasons(errors.ToArray())
      .WithSuccess(success3);

    //Act
    return Task.FromResult(resultOfTOriginal);
  }
}
