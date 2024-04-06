using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        //string connectionString = "Server=proyecto-programacion-server.database.windows.net;Database=Proyecto-Programacion-Database;User Id=CloudSAe4ad0de0; Password=kK4MK;";
        string connectionString = "Server=tcp:proyecto-programacion-server.database.windows.net,1433;Initial Catalog=Proyecto-Programacion-Database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=Active Directory Default";
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // Prompt the user to enter data
        Console.Write("Ingrese el numero de origen de la llamada: ");
        string? numeroOrigen = Console.ReadLine();

        Console.Write("Ingrese el numero de destino de la llamada: ");
        string? numeroDestino = Console.ReadLine();

        Console.Write("Ingrese la duracion en segundos de la llamada: ");
        int duracionEnSegundos;
        while (!int.TryParse(Console.ReadLine(), out duracionEnSegundos))
        {
            Console.WriteLine("Valor no válido. Por favor, ingrese un número entero.");
        }

        Console.Write("Ingrese el costo en pesos de la llamada: ");
        decimal costo;
        while (!decimal.TryParse(Console.ReadLine(), out costo))
        {
            Console.WriteLine("Valor no válido. Por favor, ingrese un número decimal.");
        }

        using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
        {
            // Insert the user-provided data into the database
            var newRecord = new CentralitaTelefonica
            {
                NumeroOrigen = numeroOrigen,
                NumeroDestino = numeroDestino,
                DuracionEnSegundos = duracionEnSegundos,
                Costo = costo
            };

            dbContext.CentralitaTelefonicas.Add(newRecord);
            dbContext.SaveChanges();

            Console.WriteLine("Registro insertado correctamente.");
        }

        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
