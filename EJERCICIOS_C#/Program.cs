using EJERCICIOS_C_.CLASE_HIJO;

Nintendo nintendo = new Nintendo();
nintendo.anioLanzamiento = 2017;
nintendo.esPortable = true;
nintendo.Marca = "Switch";
Console.WriteLine(nintendo.MostrarDetalleNintendo());

PlayStation ps = new PlayStation();
ps.Marca = "Play Station 1";
ps.anioLanzamiento = 1994;
ps.ModeloControlador = "DualSense";
Console.WriteLine($"{ps.MostrarDetallePlay()}");

XBOX XB = new XBOX();
XB.Marca  = "XBox360";
XB.anioLanzamiento = 2002;
XB.kinect = "Ajustable";
Console.WriteLine($"{ps.MostrarDetalles}");

SegaDreamCast sega = new SegaDreamCast();
sega.Marca = "Sega";
sega.anioLanzamiento = 1985;
sega.Color = "Blanco";
Console.WriteLine($"{sega.MostrarDetalleSega()}");