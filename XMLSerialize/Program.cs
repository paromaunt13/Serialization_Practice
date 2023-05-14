/*
2. Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу, в которой создайте класс, поддерживающий сериализацию. Выполните
сериализацию объекта этого класса в формате XML. Сначала используйте формат по умолчанию,
а затем измените его таким образом, чтобы значения полей сохранились в виде атрибутов
элементов XML.
3. Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу, в которой выполните десериализацию объекта из предыдущего
примера. Отобразите состояние объекта на экране
*/

using System.Xml.Serialization;
using System;
using System.Xml;
using System.Xml.Linq;

MyClass myClass = new(100, "Class");

XMLSerialize(myClass);
Console.WriteLine(new string('=', 40));
FieldToAttribute(myClass);
Console.WriteLine(new string('=', 40));
Deserialize();


void XMLSerialize(MyClass myClass)
{
    XmlSerializer xmlSerializer = new(typeof(MyClass));

    using FileStream fileStream = new("Class.xml", FileMode.OpenOrCreate);
    xmlSerializer.Serialize(fileStream, myClass);

    Console.WriteLine("Данные успешно сериализованы в XML файл");
}
void FieldToAttribute(MyClass myClass)
{
    XDocument newClass = new(
    new XElement("MyClass",
        new XAttribute("Name", myClass.Name),
        new XAttribute("Num", myClass.Num)));
    using FileStream fileStream = new("NewClass.xml", FileMode.OpenOrCreate);
    newClass.Save(fileStream);
    Console.WriteLine("Поля класса успешно преобразованы в атрибуты XML файла");
}
void Deserialize()
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyClass));

    using FileStream fileStream = new FileStream("NewClass.xml", FileMode.OpenOrCreate);   
    MyClass? myCLass = xmlSerializer.Deserialize(fileStream) as MyClass;

    Console.WriteLine($"Имя: {myClass?.Name} Номер: {myClass?.Num}");
}
public class MyClass
{
	public int Num { get; set; }
	public string Name { get; set; }
	public MyClass()
	{

	}
	public MyClass(int Num, string Name)
	{
		this.Num = Num;
		this.Name = Name;
	}
}