using System;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using YamlSerializerBenchmarks.Context;
using YamlSerializerBenchmarks.Data;

namespace YamlSerializerBenchmarks;

[HideColumns("Error")]
[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DeserializationBenchmarks
{
    private const string _yamlNexYaml = """
        Values:
        - Foo: John
        Bar: 1
        - Foo: Alice
        Bar: 2
        - Foo: Bob
        Bar: 3
        """;

    private static readonly ReadOnlyMemory<byte> _yamlVyaml = new("""
        values:
        - foo: John
        bar: 1
        - foo: Alice
        bar: 2
        - foo: Bob
        bar: 3
        """u8.ToArray());

    private const string _json = """
        {
            "Values": [
                {
                    "Foo": "John",
                    "Bar": 1
                },
                {
                    "Foo": "Alice",
                    "Bar": 2
                },
                {
                    "Foo": "Bob",
                    "Bar": 3
                }
            ]
        }
        """;

    [GlobalSetup]
    public void Setup()
    {
        NexYaml.NexYamlSerializerRegistry.Init();
    }

    [Benchmark]
    public SampleDataCollection Deserialize_NexYaml()
    {
        return NexYaml.YamlSerializer.Deserialize<SampleDataCollection>(_yamlNexYaml)!;
    }

    [Benchmark]
    public SampleDataCollection Deserialize_VYaml()
    {
        return VYaml.Serialization.YamlSerializer.Deserialize<SampleDataCollection>(_yamlVyaml)!;
    }

    [Benchmark]
    public SampleDataCollection Deserialize_SystemTextJson()
    {
        return JsonSerializer.Deserialize<SampleDataCollection>(_json)!;
    }

    [Benchmark]
    public SampleDataCollection Deserialize_SystemTextJson_SourceGenerated()
    {
        return JsonSerializer.Deserialize(_json, YamlBenchmarksJsonContext.Default.SampleDataCollection)!;
    }
}
