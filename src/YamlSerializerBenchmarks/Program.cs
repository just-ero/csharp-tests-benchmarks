#if DEBUG
using System;
using YamlSerializerBenchmarks;

SerializationBenchmarks sbm = new();
sbm.Setup();

Console.WriteLine(sbm.Serialize_SystemTextJson());
Console.WriteLine(sbm.Serialize_SystemTextJson_SourceGenerated());
Console.WriteLine(sbm.Serialize_NexYaml());
Console.WriteLine(sbm.Serialize_VYaml());
#else
using BenchmarkDotNet.Running;
using YamlSerializerBenchmarks;

BenchmarkRunner.Run<SerializationBenchmarks>();
#endif
