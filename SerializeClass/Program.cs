/*
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу, в которой, создайте пользовательский тип (например, класс) и выполните
сериализацию объекта этого типа, всеми известными вас способами.
*/

using System.Xml.Serialization;
using System;
using System.Text.Json;
using System.IO;

Person person = new(13, "Roman");

XMLSerialize(person);
JSONSerialize(person);
BinarySerialize(person);

void XMLSerialize(Person person)
{
    XmlSerializer xmlSerializer = new(typeof(Person));

    using FileStream fileStream = new("Person.xml", FileMode.OpenOrCreate);
    xmlSerializer.Serialize(fileStream, person);

    Console.WriteLine("Данные успешно сериализованы в XML файл");
}
void JSONSerialize(Person person)
{
    using FileStream fileStream = new("Person.json", FileMode.OpenOrCreate);
    JsonSerializer.Serialize<Person>(fileStream, person);

    Console.WriteLine("Данные успешно сериализованы в JSON файл");
}
void BinarySerialize(Person person)
{
    using BinaryWriter writer = new(File.Open("Person.dat", FileMode.OpenOrCreate));
    writer.Write(person.Name);
    writer.Write(person.Number);

    Console.WriteLine("Данные успешно сериализованы в Binary файл");
}

public class Person
{
    public int Number { get; set; }
    public string Name { get; set; }
    public Person()
    {

    }
    public Person(int Number, string Name)
    {
        this.Number = Number;
        this.Name = Name;
    }

}