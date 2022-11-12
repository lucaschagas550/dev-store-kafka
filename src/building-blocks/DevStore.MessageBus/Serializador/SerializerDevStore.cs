using Confluent.Kafka;
using System.IO;
using System.IO.Compression;

//Serializar mensagem kafka
namespace DevStore.MessageBus.Serializador
{
    internal class SerializerDevStore<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            //apenas esta linha bastaria para enviar a mensagem em json no formato de bytes para o kafka
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(data);

            //Compressao de dados
            using var memoryStream = new MemoryStream();
            using var zipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Close();
            var buffer = memoryStream.ToArray();

            return buffer;
        }
    }
}
