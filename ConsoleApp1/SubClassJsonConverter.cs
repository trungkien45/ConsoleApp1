// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public class SubClassJsonConverter : JsonConverter<Interface1>
    {
        public SubClassJsonConverter()
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Interface1);
        }

        public override Interface1? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected StartObject token");
            var properties = typeToConvert.GetProperties();

            var message = new Class1();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return message;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("Expected PropertyName token");

                var propName = reader.GetString();
                reader.Read();

                properties.Where(p => p.Name == propName).FirstOrDefault()?.SetValue(message, reader.GetString());

            }

            throw new JsonException("Expected EndObject token");
        }

        public override void Write(Utf8JsonWriter writer, Interface1 value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}