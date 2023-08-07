# SubClass-JsonConverter
SubClass JsonConverter


var x1 = JsonSerializer.Serialize(interface1, typeof(Interface1), options);
Console.WriteLine(x1);
// result when not using converter
/*
{
  "Interface1Property1": "",
  "Interface1Property2": "",
  "Interface1Property3": ""
}
 */
var x15 = JsonSerializer.Serialize(interface1, typeof(Interface1), options1);
Console.WriteLine(x15);
// result when using converter
/*
{
  "Interface1Property1": "",
  "Interface1Property2": "",
  "Interface1Property3": "",
  "Class1Property1": "",
  "Class1Property2": "",
  "Class1Property3": ""
}
 */
