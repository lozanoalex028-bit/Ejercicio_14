Console.WriteLine("SISTEMA DE MONITOREO DE SENSORES INDUSTRIALES");

while (true)
{
    Console.WriteLine();

    // Seleccionar el tipo de sensor
    Console.WriteLine("Seleccione el tipo de sensor que desea verificar:");
    Console.WriteLine("1. Sensor de temperatura");
    Console.WriteLine("2. Sensor de presion");
    Console.WriteLine("3. Sensor de distancia");
    Console.Write("Opcion: ");

    int opcion;

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Error: debe ingresar un numero.");
        continue; // regresa al menu
    }
    Console.WriteLine();

    switch (opcion)
    {
        case 1:
            // Crear objeto SensorTemperatura
            SensorTemperatura sensorTemp = new SensorTemperatura();

            Console.WriteLine("DATOS DEL SENSOR DE TEMPERATURA");

            Console.Write("Ingrese el identificador del sensor: ");
            sensorTemp.Identificador = Console.ReadLine() ?? "Sin identificador";

            Console.Write("El sensor esta activo? (1 = Si, 0 = No): ");
            sensorTemp.Activo = Convert.ToInt32(Console.ReadLine()) == 1;

            // Solo se lee la señal si el sensor esta activo
            if (sensorTemp.Activo)
            {
                Console.Write("Ingrese la temperatura en grados Celsius: ");
                sensorTemp.Valormedio = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("RESULTADOS DEL SENSOR DE TEMPERATURA");
            sensorTemp.MostrarDatos();
            if (sensorTemp.Activo)
                Console.WriteLine($"Temperatura: {sensorTemp.Valormedio} °C");
            Console.WriteLine($"Evaluacion: {sensorTemp.EvaluarTemperatura()}");
            break;

        case 2:
            // Crear objeto SensorPresion
            SensorPresion sensorPresion = new SensorPresion();

            Console.WriteLine("DATOS DEL SENSOR DE PRESION");

            Console.Write("Ingrese el identificador del sensor: ");
            sensorPresion.Identificador = Console.ReadLine() ?? "Sin identificador";

            Console.Write("El sensor esta activo? (1 = Si, 0 = No): ");
            sensorPresion.Activo = Convert.ToInt32(Console.ReadLine()) == 1;

            // Solo se lee la señal si el sensor esta activo
            if (sensorPresion.Activo)
            {
                Console.Write("Ingrese la presion en bar: ");
                sensorPresion.Valormedio = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("RESULTADOS DEL SENSOR DE PRESION");
            sensorPresion.MostrarDatos();
            if (sensorPresion.Activo)
                Console.WriteLine($"Presion: {sensorPresion.Valormedio} bar");
            Console.WriteLine($"Evaluacion: {sensorPresion.EvaluarPresion()}");
            break;

        case 3:
            // Crear objeto SensorDistancia
            SensorDistancia sensorDist = new SensorDistancia();

            Console.WriteLine("DATOS DEL SENSOR DE DISTANCIA");

            Console.Write("Ingrese el identificador del sensor: ");
            sensorDist.Identificador = Console.ReadLine() ?? "Sin identificador";

            Console.Write("El sensor esta activo? (1 = Si, 0 = No): ");
            sensorDist.Activo = Convert.ToInt32(Console.ReadLine()) == 1;

            // Solo se lee la señal si el sensor esta activo
            if (sensorDist.Activo)
            {
                Console.Write("Ingrese la distancia en centimetros: ");
                sensorDist.Valormedio = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("RESULTADOS DEL SENSOR DE DISTANCIA");
            sensorDist.MostrarDatos();
            if (sensorDist.Activo)
                Console.WriteLine($"Distancia: {sensorDist.Valormedio} cm");
            Console.WriteLine($"Evaluacion: {sensorDist.EvaluarDistancia()}");
            break;

        default:
            Console.WriteLine("Opcion no valida. Seleccione 1, 2 o 3.");
            break;
    }

    // Preguntar si desea evaluar otro sensor (se repite hasta responder si o no)
    string respuesta;

    while (true)
    {
        Console.WriteLine();
        Console.Write("Desea agregar otro sensor? (si/no): ");
        respuesta = (Console.ReadLine() ?? "").Trim().ToLower();

        if (respuesta == "si" || respuesta == "no")
            break; // sale del while de la pregunta

        Console.WriteLine("Respuesta no valida. Escriba si o no.");
    }

    if (respuesta == "no")
        break; // sale del while principal
}

Console.WriteLine();
Console.WriteLine("Fin del programa.");


// CLASE BASE
class Sensor
{
    // Propiedades comunes a todos los sensores
    public string Identificador { get; set; } = "";
    public double Valormedio { get; set; }
    public bool Activo { get; set; }

    // Metodo para determinar el estado de funcionamiento
    public string ObtenerEstado()
    {
        if (Activo)
            return "Sensor activo";
        else
            return "Sensor inactivo";
    }

    // Metodo para mostrar los datos comunes
    public void MostrarDatos()
    {
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Estado: {ObtenerEstado()}");

        if (Activo)
            Console.WriteLine($"Valor medido: {Valormedio}");
        else
            Console.WriteLine("Valor medido: sin lectura");
    }
}


// SUBCLASE 1: SENSOR DE TEMPERATURA
class SensorTemperatura : Sensor
{
    public string EvaluarTemperatura()
    {
        if (!Activo)
            return "Sensor inactivo, no se puede leer la senal de temperatura";

        if (Valormedio > 80)
            return "REQUIERE ATENCION: la temperatura supera el limite de 80 °C";

        return "La temperatura esta dentro del criterio establecido";
    }
}


// SUBCLASE 2: SENSOR DE PRESION
class SensorPresion : Sensor
{
    public string EvaluarPresion()
    {
        if (!Activo)
            return "Sensor inactivo, no se puede leer la senal de presion";

        if (Valormedio > 10)
            return "REQUIERE ATENCION: la presion supera el limite de 10 bar";

        return "La presion esta dentro del criterio establecido";
    }
}


// SUBCLASE 3: SENSOR DE DISTANCIA
class SensorDistancia : Sensor
{
    public string EvaluarDistancia()
    {
        if (!Activo)
            return "Sensor inactivo, no se puede leer la senal de distancia";

        if (Valormedio < 20)
            return "REQUIERE ATENCION: el objeto esta a menos de 20 cm";

        return "La distancia esta dentro del criterio establecido";
    }
}