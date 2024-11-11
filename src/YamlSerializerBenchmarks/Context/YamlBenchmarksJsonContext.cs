using System.Text.Json.Serialization;
using YamlSerializerBenchmarks.Data;

namespace YamlSerializerBenchmarks.Context;

[JsonSerializable(typeof(SampleData))]
[JsonSerializable(typeof(SampleDataCollection))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public sealed partial class YamlBenchmarksJsonContext : JsonSerializerContext;
