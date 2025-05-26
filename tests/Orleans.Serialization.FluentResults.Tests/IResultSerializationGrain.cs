using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;
internal interface IResultSerializationGrain : IGrainWithIntegerKey
{
  Task<Result> OkResult();
  Task<Result> FailedResult();
}
