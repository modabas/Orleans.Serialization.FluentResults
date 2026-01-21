namespace Orleans.Serialization.FluentResults.Tests;

internal interface IInheritanceSerializationGrain : IGrainWithIntegerKey
{
  Task<ErrorChild> GetErrorChild(string extra);
  Task<ExceptionalErrorChild> GetExceptionalErrorChild(string extra);
  Task<SuccessChild> GetSuccessChild(string extra);
}
