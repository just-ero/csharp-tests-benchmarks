using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using VYaml.Annotations;
using YamlSerializerBenchmarks.Context;
using YamlSerializerBenchmarks.Data;

namespace YamlSerializerBenchmarks;

[MemoryDiagnoser(false)]
public class SerializationBenchmarks
{
    private static readonly SampleDataCollection _packet = new();

    private static JsonSerializerOptions _stjOptions = new() { WriteIndented = true };

    [GlobalSetup]
    public void Setup()
    {
        NexYaml.NexYamlSerializerRegistry.Init();
    }

    [Benchmark(Baseline = true)]
    public string Serialize_NexYaml()
    {
        return NexYaml.YamlSerializer.SerializeToString(_packet);
    }

    [Benchmark]
    public string Serialize_VYaml()
    {
        return VYaml.Serialization.YamlSerializer.SerializeToString(_packet);
    }

    [Benchmark]
    public string Serialize_SystemTextJson()
    {
        return JsonSerializer.Serialize(_packet, _stjOptions);
    }

    [Benchmark]
    public string Serialize_SystemTextJson_SourceGenerated()
    {
        return JsonSerializer.Serialize(_packet, YamlBenchmarksJsonContext.Default.SampleDataCollection);
    }
}
