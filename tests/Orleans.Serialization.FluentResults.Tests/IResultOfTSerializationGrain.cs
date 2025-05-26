using FluentResults;

namespace Orleans.Serialization.FluentResults.Tests;

internal interface IResultOfTSerializationGrain : IGrainWithIntegerKey
{
  Task<Result<ValueClass>> FailedResultWithValueClass();
  Task<Result<ValueRecord>> FailedResultWithValueRecord();
  Task<Result<ValueStruct>> FailedResultWithValueStruct();
  Task<Result<ValueClass>> OkResultWithValueClassAndReasons();
  Task<Result<ValueRecord>> OkResultWithValueRecordAndReasons();
  Task<Result<ValueStruct>> OkResultWithValueStructAndReasons();
  Task<Result<ValueClass>> FailedResultWithValueInValueClass();
  Task<Result<ValueRecord>> FailedResultWithValueInValueRecord();
  Task<Result<ValueStruct>> FailedResultWithValueInValueStruct();
  Task<Result<ValueClass>> OkResultWithValueClass();
  Task<Result<ValueRecord>> OkResultWithValueRecord();
  Task<Result<ValueStruct>> OkResultWithValueStruct();
}
