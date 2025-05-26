using FluentResults;

namespace Orleans.Serialization.FluentResults;

[RegisterConverter]
public sealed class ResultSurrogateConverter :
    IConverter<Result, ResultSurrogate>
{
  public Result ConvertFromSurrogate(in ResultSurrogate surrogate)
  {
    return new Result().WithReasons(surrogate.Reasons);
  }

  public ResultSurrogate ConvertToSurrogate(in Result value)
  {
    return new ResultSurrogate() { Reasons = value.Reasons };
  }
}


[RegisterConverter]
public sealed class ResultSurrogateConverter<TValue> :
    IConverter<Result<TValue>, ResultSurrogate<TValue>>
{
  public Result<TValue> ConvertFromSurrogate(in ResultSurrogate<TValue> surrogate)
  {
    if (surrogate.Value is not null)
    {
      return new Result<TValue>().WithValue(surrogate.Value).WithReasons(surrogate.Reasons);
    }
    return new Result<TValue>().WithReasons(surrogate.Reasons);
  }

  public ResultSurrogate<TValue> ConvertToSurrogate(in Result<TValue> value)
  {
    return new ResultSurrogate<TValue>() { Reasons = value.Reasons, Value = value.ValueOrDefault };
  }
}
