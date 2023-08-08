// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using System.Reflection;
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

            var type = BuildNewType();
            var o = Activator.CreateInstance(type);
            Interface1 message = (Interface1)o;
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

        private static Type? BuildNewType()
        {
            var aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab =
                AssemblyBuilder.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.Run);

            // The module name is usually the same as the assembly name.
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name ?? "DynamicAssemblyExample");

            TypeBuilder tb = mb.DefineType(
                "MyDynamicType",
                 TypeAttributes.Class | TypeAttributes.Public);
            tb.AddInterfaceImplementation(typeof(Interface1));
            MethodAttributes getSetAttr1 =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig | MethodAttributes.Virtual;

            // Add a private field of type (String).
            FieldBuilder interface1Property1Bldr = tb.DefineField("interface1Property1",
                                                        typeof(string),
                                                        FieldAttributes.Private);
            PropertyBuilder interface1Property1PropBldr = tb.DefineProperty("Interface1Property1",
                                                         PropertyAttributes.HasDefault,
                                                         typeof(string),
                                                         null);


            // Define the "get" accessor method for CustomerName.
            MethodBuilder interface1Property1GetPropMthdBldr =
                tb.DefineMethod("get_Interface1Property1",
                                           getSetAttr1,
                                           typeof(string),
                                           Type.EmptyTypes);

            ILGenerator interface1Property1GetIL = interface1Property1GetPropMthdBldr.GetILGenerator();

            interface1Property1GetIL.Emit(OpCodes.Ldarg_0);
            interface1Property1GetIL.Emit(OpCodes.Ldfld, interface1Property1Bldr);
            interface1Property1GetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for CustomerName.
            MethodBuilder interface1Property1SetPropMthdBldr =
                tb.DefineMethod("set_Interface1Property1",
                                           getSetAttr1,
                                           null,
                                           new Type[] { typeof(string) });

            ILGenerator interface1Property1SetIL = interface1Property1SetPropMthdBldr.GetILGenerator();

            interface1Property1SetIL.Emit(OpCodes.Ldarg_0);
            interface1Property1SetIL.Emit(OpCodes.Ldarg_1);
            interface1Property1SetIL.Emit(OpCodes.Stfld, interface1Property1Bldr);
            interface1Property1SetIL.Emit(OpCodes.Ret);

            interface1Property1PropBldr.SetGetMethod(interface1Property1GetPropMthdBldr);
            interface1Property1PropBldr.SetSetMethod(interface1Property1SetPropMthdBldr);

            MethodAttributes getSetAttr2 =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig | MethodAttributes.Virtual;
            // Add a private field of type (String).
            FieldBuilder interface1Property2Bldr = tb.DefineField("interface1Property2",
                                                        typeof(string),
                                                        FieldAttributes.Private);
            PropertyBuilder interface1Property2PropBldr = tb.DefineProperty("Interface1Property2",
                                                         PropertyAttributes.HasDefault,
                                                         typeof(string),
                                                         null);


            // Define the "get" accessor method for CustomerName.
            MethodBuilder interface1Property2GetPropMthdBldr =
                tb.DefineMethod("get_Interface1Property2",
                                           getSetAttr2,
                                           typeof(string),
                                           Type.EmptyTypes);

            ILGenerator interface1Property2GetIL = interface1Property2GetPropMthdBldr.GetILGenerator();

            interface1Property2GetIL.Emit(OpCodes.Ldarg_0);
            interface1Property2GetIL.Emit(OpCodes.Ldfld, interface1Property2Bldr);
            interface1Property2GetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for CustomerName.
            MethodBuilder interface1Property2SetPropMthdBldr =
                tb.DefineMethod("set_Interface1Property2",
                                           getSetAttr2,
                                           null,
                                           new Type[] { typeof(string) });

            ILGenerator interface1Property2SetIL = interface1Property2SetPropMthdBldr.GetILGenerator();

            interface1Property2SetIL.Emit(OpCodes.Ldarg_0);
            interface1Property2SetIL.Emit(OpCodes.Ldarg_1);
            interface1Property2SetIL.Emit(OpCodes.Stfld, interface1Property2Bldr);
            interface1Property2SetIL.Emit(OpCodes.Ret);

            interface1Property2PropBldr.SetGetMethod(interface1Property2GetPropMthdBldr);
            interface1Property2PropBldr.SetSetMethod(interface1Property2SetPropMthdBldr);
            MethodAttributes getSetAttr3 =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                MethodAttributes.HideBySig | MethodAttributes.Virtual;

            // Add a private field of type (String).
            FieldBuilder interface1Property3Bldr = tb.DefineField("interface1Property3",
                                                        typeof(string),
                                                        FieldAttributes.Private);
            PropertyBuilder interface1Property3PropBldr = tb.DefineProperty("Interface1Property3",
                                                         PropertyAttributes.HasDefault,
                                                         typeof(string),
                                                         null);


            // Define the "get" accessor method for CustomerName.
            MethodBuilder interface1Property3GetPropMthdBldr =
                tb.DefineMethod("get_Interface1Property3",
                                           getSetAttr3,
                                           typeof(string),
                                           Type.EmptyTypes);

            ILGenerator interface1Property3GetIL = interface1Property3GetPropMthdBldr.GetILGenerator();

            interface1Property3GetIL.Emit(OpCodes.Ldarg_0);
            interface1Property3GetIL.Emit(OpCodes.Ldfld, interface1Property3Bldr);
            interface1Property3GetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for CustomerName.
            MethodBuilder interface1Property3SetPropMthdBldr =
                tb.DefineMethod("set_Interface1Property3",
                                           getSetAttr3,
                                           null,
                                           new Type[] { typeof(string) });

            ILGenerator interface1Property3SetIL = interface1Property3SetPropMthdBldr.GetILGenerator();

            interface1Property3SetIL.Emit(OpCodes.Ldarg_0);
            interface1Property3SetIL.Emit(OpCodes.Ldarg_1);
            interface1Property3SetIL.Emit(OpCodes.Stfld, interface1Property3Bldr);
            interface1Property3SetIL.Emit(OpCodes.Ret);

            interface1Property3PropBldr.SetGetMethod(interface1Property3GetPropMthdBldr);
            interface1Property3PropBldr.SetSetMethod(interface1Property3SetPropMthdBldr);
            Type? retval = tb.CreateType();

            return retval;

        }

        public override void Write(Utf8JsonWriter writer, Interface1 value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}