using System.Collections.Generic;
using System.Text.Json.Serialization;
using Stride.Core;
using VYaml.Annotations;

namespace YamlSerializerBenchmarks.Data;

[DataContract]
[YamlObject]
public sealed partial class SampleDataCollection
{
    [JsonInclude]
    public List<SampleData> Values =
    [
        new() { Foo = "John", Bar = 1 },
        new() { Foo = "Alice", Bar = 2 },
        new() { Foo = "Bob", Bar = 3 }
    ];
}
