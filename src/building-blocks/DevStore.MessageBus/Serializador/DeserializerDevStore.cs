using Confluent.Kafka;
using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;

//Deserilizar a mensagem kafka
namespace DevStore.MessageBus.Serializador
{
    internal class DeserializerDevStore<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            //Descompactacao da mensagem
            using var memoryStream = new MemoryStream(data.ToArray());
            using var zip = new GZipStream(memoryStream, CompressionMode.Decompress, true);

            return JsonSerializer.Deserialize<T>(zip);
        }
    }
}
