using Stride.Core;
using VYaml.Annotations;

namespace YamlSerializerBenchmarks.Data;

[DataContract]
[YamlObject]
public sealed partial class SampleData
{
    [DataMember]
    public string? Foo { get; init; }

    [DataMember]
    public int Bar { get; init; }
}
