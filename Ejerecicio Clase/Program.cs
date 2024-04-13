using Ejerecicio_Clase.Clases;

Carro Car1 = new Carro("TOYOTA", 2024);
Carro Car2 = new Carro("NISSAN", 2021);

if (Car2.Acelerar() == 0)
{
    Console.WriteLine("El Carro esa Apagado");
}


Car1.Color = "ROJO";
Car1.Owner = "JUAN";

Console.WriteLine("Marca: " + Car1.Marca);
Console.WriteLine("Marca: " + Car1.Modelo);

Console.WriteLine("Marca: " + Car2.Marca);
Console.WriteLine("Marca: " + Car2.Modelo);

Console.WriteLine(Car2.Acelerar() + "/KPH");
Console.WriteLine(Car2.Acelerar() + "/KPH");
Console.WriteLine(Car2.Acelerar() + "/KPH");
Console.WriteLine(Car2.Acelerar() + "/KPH");
Console.WriteLine(Car2.Acelerar() + "/KPH");
Console.WriteLine(Car2.Acelerar() + "/KPH");