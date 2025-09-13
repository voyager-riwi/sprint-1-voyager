using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

List<List<object>> books = new List<List<object>>();
List<string[]> usuarios = new List<string[]>();
List<string[]> prestamos = new List<string[]>();
List<string[]> reseñas = new List<string[]>();
bool outSystem = false;

while (!outSystem)
{
    bool outBook = false; 

    Console.WriteLine("\n BIBLIOTECA ");
    Console.WriteLine("1. Libros");
    Console.WriteLine("2. Usuarios");
    Console.WriteLine("3. Préstamos");
    Console.WriteLine("4. Reseñas");
    Console.WriteLine("5. Estadísticas");
    Console.WriteLine("6. Salir");
    Console.Write("Opción: ");
    
    if (!int.TryParse(Console.ReadLine(), out int optionInt))
    {
        Console.WriteLine("Opción inválida");
        continue;
    } 

    switch (optionInt)
    {
        case 1:
            while (!outBook)
            {
                Console.WriteLine("\n LIBROS ");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Actualizar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Buscar");
                Console.WriteLine("6. Volver");
                Console.Write("Opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out int optionBookI))
                {
                    Console.WriteLine("Opción inválida");
                    continue;
                }

                if (optionBookI == 1)
                {
                    Console.Write("Título: ");
                    string title = Console.ReadLine();
                    Console.Write("Autor: ");
                    string author = Console.ReadLine();
                    Console.Write("Categoría: ");
                    string category = Console.ReadLine();
                    Console.Write("Año: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out int year) || year < 1000 || year > DateTime.Now.Year)
                    {
                        Console.WriteLine("Año inválido");
                        continue;
                    }

                    Console.Write("Disponible (s/n): ");
                    bool available = Console.ReadLine().ToLower() == "s";

                    books.Add(new List<object> { title, author, category, year, available });
                    Console.WriteLine("Libro agregado");
                }
                else if (optionBookI == 2)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros");
                        continue;
                    }
                    for (int i = 0; i < books.Count; i++)
                    {
                        var book = books[i];
                        string disp = (bool)book[4] ? "Sí" : "No";
                        Console.WriteLine($"{i + 1}. {book[0]} - {book[1]} - {book[2]} - {book[3]} - {disp}");
                    }
                }
                else if (optionBookI == 3)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros");
                        continue;
                    }

                    Console.Write("Título del libro: ");
                    string title = Console.ReadLine();
                    var book = books.FirstOrDefault(b => (string)b[0] == title);
                    
                    if (book == null)
                    {
                        Console.WriteLine("Libro no encontrado");
                        continue;
                    }

                    Console.Write("Nuevo título (vacío=no cambiar): ");
                    string newTitle = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newTitle)) book[0] = newTitle;

                    Console.Write("Nuevo autor (vacío=no cambiar): ");
                    string newAuthor = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newAuthor)) book[1] = newAuthor;

                    Console.Write("Nueva categoría (vacío=no cambiar): ");
                    string newCategory = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newCategory)) book[2] = newCategory;

                    Console.Write("Nuevo año (vacío=no cambiar): ");
                    string newYear = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newYear) && int.TryParse(newYear, out int year) && year >= 1000 && year <= DateTime.Now.Year)
                        book[3] = year;

                    Console.Write("Disponible (s/n, vacío=no cambiar): ");
                    string newAvailable = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newAvailable)) book[4] = newAvailable.ToLower() == "s";

                    Console.WriteLine("Libro actualizado");
                }
                else if (optionBookI == 4)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros");
                        continue;
                    }

                    Console.Write("Título del libro: ");
                    string title = Console.ReadLine();
                    int index = books.FindIndex(b => (string)b[0] == title);

                    if (index != -1)
                    {
                        books.RemoveAt(index);
                        Console.WriteLine("Libro eliminado");
                    }
                    else
                    {
                        Console.WriteLine("Libro no encontrado");
                    }
                }
                else if (optionBookI == 5)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros");
                        continue;
                    }

                    Console.WriteLine("\n BUSCAR ");
                    Console.WriteLine("1. Por título");
                    Console.WriteLine("2. Por autor");
                    Console.WriteLine("3. Por categoría");
                    Console.Write("Opción: ");
                    
                    if (!int.TryParse(Console.ReadLine(), out int searchType) || searchType < 1 || searchType > 3)
                    {
                        Console.WriteLine("Opción inválida");
                        continue;
                    }

                    Console.Write("Texto a buscar: ");
                    string searchText = Console.ReadLine().ToLower();
                    bool found = false;

                    for (int i = 0; i < books.Count; i++)
                    {
                        var book = books[i];
                        string title = ((string)book[0]).ToLower();
                        string author = ((string)book[1]).ToLower();
                        string category = ((string)book[2]).ToLower();

                        if ((searchType == 1 && title.Contains(searchText)) ||
                            (searchType == 2 && author.Contains(searchText)) ||
                            (searchType == 3 && category.Contains(searchText)))
                        {
                            string disp = (bool)book[4] ? "Sí" : "No";
                            Console.WriteLine($"{i + 1}. {book[0]} - {book[1]} - {book[2]} - {book[3]} - {disp}");
                            found = true;
                        }
                    }

                    if (!found) Console.WriteLine("No se encontraron libros");
                }
                else if (optionBookI == 6)
                {
                    outBook = true;
                }
            }
            break;

        case 2: HandleUserManagement(); break;
        case 3: HandleLoansAndReturns(); break;
        case 4: HandleReviewsAndRatings(); break;
        case 5: HandleStatistics(); break;
        case 6: outSystem = true; break;
    }
}

void HandleUserManagement()
{
    bool salir = false;
    while (!salir)
    {
        Console.WriteLine("\n USUARIOS ");
        Console.WriteLine("1. Registrar");
        Console.WriteLine("2. Listar");
        Console.WriteLine("3. Actualizar");
        Console.WriteLine("4. Eliminar");
        Console.WriteLine("5. Volver");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": RegistrarUsuario(); break;
            case "2": ConsultarUsuarios(); break;
            case "3": ActualizarUsuario(); break;
            case "4": EliminarUsuario(); break;
            case "5": salir = true; break;
            default: Console.WriteLine("Opción inválida"); break;
        }
    }
}

void RegistrarUsuario()
{
    Console.WriteLine("\n REGISTRAR USUARIO ");
    string nombre = ObtenerDatoValidado("Nombre completo: ", ValidarNombre);
    string id = ObtenerDatoValidado("ID: ", ValidarId);

    if (BuscarIndiceUsuarioPorId(id) != -1)
    {
        Console.WriteLine("ID ya existe");
        return;
    }

    string correo = ObtenerDatoValidado("Correo: ", ValidarCorreo);
    usuarios.Add(new string[] { nombre, id, correo });
    Console.WriteLine("Usuario registrado");
}

string ObtenerDatoValidado(string mensaje, Func<string, (bool, string)> validador)
{
    while (true)
    {
        Console.Write(mensaje);
        string input = Console.ReadLine();
        var (esValido, error) = validador(input);
        if (esValido) return input;
        Console.WriteLine($"Error: {error}");
    }
}

(bool, string) ValidarNombre(string nombre)
{
    if (string.IsNullOrWhiteSpace(nombre)) return (false, "Nombre vacío");
    if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")) return (false, "Solo letras y espacios");
    if (nombre.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length < 2) return (false, "Mínimo nombre y apellido");
    return (true, "");
}

(bool, string) ValidarId(string id)
{
    if (string.IsNullOrWhiteSpace(id)) return (false, "ID vacío");
    if (!Regex.IsMatch(id, @"^[0-9]+$")) return (false, "Solo números");
    return (true, "");
}

(bool, string) ValidarCorreo(string correo)
{
    if (string.IsNullOrWhiteSpace(correo)) return (false, "Correo vacío");
    try
    {
        var addr = new System.Net.Mail.MailAddress(correo);
        return (addr.Address == correo, "");
    }
    catch { return (false, "Formato inválido"); }
}

void ConsultarUsuarios()
{
    Console.WriteLine("\n USUARIOS ");
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios");
        return;
    }

    foreach (var usuario in usuarios)
    {
        Console.WriteLine($"{usuario[0]} - {usuario[1]} - {usuario[2]}");
    }
}

void ActualizarUsuario()
{
    Console.WriteLine("\n ACTUALIZAR USUARIO ");
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios");
        return;
    }

    Console.Write("ID del usuario: ");
    int indice = BuscarIndiceUsuarioPorId(Console.ReadLine());

    if (indice == -1)
    {
        Console.WriteLine("Usuario no encontrado");
        return;
    }

    var usuario = usuarios[indice];
    Console.WriteLine("Dejar vacío para no cambiar");

    Console.Write($"Nombre ({usuario[0]}): ");
    string nuevoNombre = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoNombre)) usuario[0] = nuevoNombre;

    Console.Write($"Correo ({usuario[2]}): ");
    string nuevoCorreo = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoCorreo)) usuario[2] = nuevoCorreo;

    Console.WriteLine("Usuario actualizado");
}

void EliminarUsuario()
{
    Console.WriteLine("\n ELIMINAR USUARIO ");
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios");
        return;
    }

    Console.Write("ID del usuario: ");
    int indice = BuscarIndiceUsuarioPorId(Console.ReadLine());

    if (indice == -1)
    {
        Console.WriteLine("Usuario no encontrado");
        return;
    }

    var usuario = usuarios[indice];
    Console.WriteLine($"Eliminar: {usuario[0]} - {usuario[1]}");
    Console.Write("Confirmar (s/n): ");
    
    if (Console.ReadLine().ToLower() == "s")
    {
        usuarios.RemoveAt(indice);
        Console.WriteLine("Usuario eliminado");
    }
    else
    {
        Console.WriteLine("Cancelado");
    }
}

int BuscarIndiceUsuarioPorId(string id) => usuarios.FindIndex(u => u[1] == id);

void HandleLoansAndReturns()
{
    bool salir = false;
    while (!salir)
    {
        Console.WriteLine("\n PRÉSTAMOS ");
        Console.WriteLine("1. Prestar");
        Console.WriteLine("2. Devolver");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("4. Volver");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": PrestarLibro(); break;
            case "2": DevolverLibro(); break;
            case "3": MostrarLibrosPrestados(); break;
            case "4": salir = true; break;
            default: Console.WriteLine("Opción inválida"); break;
        }
    }
}

void PrestarLibro()
{
    Console.WriteLine("\n PRESTAR LIBRO ");
    
    if (books.Count == 0)
    {
        Console.WriteLine("No hay libros");
        return;
    }

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios");
        return;
    }

    Console.WriteLine("\nLibros disponibles:");
    bool hayDisponibles = false;
    for (int i = 0; i < books.Count; i++)
    {
        if ((bool)books[i][4])
        {
            Console.WriteLine($"{i + 1}. {books[i][0]} - {books[i][1]}");
            hayDisponibles = true;
        }
    }

    if (!hayDisponibles)
    {
        Console.WriteLine("No hay libros disponibles");
        return;
    }

    Console.Write("Número del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceLibro) || indiceLibro < 1 || indiceLibro > books.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceLibro--;
    if (!(bool)books[indiceLibro][4])
    {
        Console.WriteLine("Libro no disponible");
        return;
    }

    Console.WriteLine("\nUsuarios:");
    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {usuarios[i][0]} (ID: {usuarios[i][1]})");
    }

    Console.Write("Número del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceUsuario) || indiceUsuario < 1 || indiceUsuario > usuarios.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceUsuario--;
    string idUsuario = usuarios[indiceUsuario][1];
    string tituloLibro = (string)books[indiceLibro][0];
    
    if (UsuarioTieneLibroPrestado(idUsuario, tituloLibro))
    {
        Console.WriteLine("Usuario ya tiene este libro");
        return;
    }

    prestamos.Add(new string[] { idUsuario, tituloLibro, DateTime.Now.ToString("yyyy-MM-dd"), "" });
    books[indiceLibro][4] = false;
    Console.WriteLine($"Libro prestado a {usuarios[indiceUsuario][0]}");
}

void DevolverLibro()
{
    Console.WriteLine("\n DEVOLVER LIBRO ");
    
    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos");
        return;
    }

    Console.WriteLine("\nLibros prestados:");
    for (int i = 0; i < prestamos.Count; i++)
    {
        if (prestamos[i][3] == "")
        {
            string nombreUsuario = ObtenerNombreUsuarioPorId(prestamos[i][0]);
            Console.WriteLine($"{i + 1}. {prestamos[i][1]} - {nombreUsuario} ({prestamos[i][2]})");
        }
    }

    Console.Write("Número del préstamo: ");
    if (!int.TryParse(Console.ReadLine(), out int indice) || indice < 1 || indice > prestamos.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indice--;
    if (prestamos[indice][3] != "")
    {
        Console.WriteLine("Libro ya devuelto");
        return;
    }

    prestamos[indice][3] = DateTime.Now.ToString("yyyy-MM-dd");
    string tituloLibro = prestamos[indice][1];
    
    for (int i = 0; i < books.Count; i++)
    {
        if ((string)books[i][0] == tituloLibro)
        {
            books[i][4] = true;
            break;
        }
    }

    Console.WriteLine("Libro devuelto");
}

void MostrarLibrosPrestados()
{
    Console.WriteLine("\n LIBROS PRESTADOS ");
    
    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos");
        return;
    }

    bool hayPrestados = false;
    for (int i = 0; i < prestamos.Count; i++)
    {
        if (prestamos[i][3] == "")
        {
            string nombreUsuario = ObtenerNombreUsuarioPorId(prestamos[i][0]);
            Console.WriteLine($"{prestamos[i][1]} - {nombreUsuario} ({prestamos[i][2]})");
            hayPrestados = true;
        }
    }

    if (!hayPrestados) Console.WriteLine("No hay libros prestados");
}

bool UsuarioTieneLibroPrestado(string idUsuario, string tituloLibro) =>
    prestamos.Any(p => p[0] == idUsuario && p[1] == tituloLibro && p[3] == "");

string ObtenerNombreUsuarioPorId(string id) =>
    usuarios.FirstOrDefault(u => u[1] == id)?[0] ?? "Usuario no encontrado";

void HandleReviewsAndRatings()
{
    bool salir = false;
    while (!salir)
    {
        Console.WriteLine("\n RESEÑAS ");
        Console.WriteLine("1. Calificar");
        Console.WriteLine("2. Escribir reseña");
        Console.WriteLine("3. Ver calificaciones");
        Console.WriteLine("4. Ver reseñas");
        Console.WriteLine("5. Volver");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": CalificarLibro(); break;
            case "2": EscribirReseña(); break;
            case "3": VerCalificaciones(); break;
            case "4": VerReseñas(); break;
            case "5": salir = true; break;
            default: Console.WriteLine("Opción inválida"); break;
        }
    }
}

void CalificarLibro()
{
    Console.WriteLine("\n CALIFICAR LIBRO ");
    
    if (books.Count == 0 || usuarios.Count == 0)
    {
        Console.WriteLine("No hay libros o usuarios");
        return;
    }

    MostrarLibros();
    Console.Write("Número del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceLibro) || indiceLibro < 1 || indiceLibro > books.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceLibro--;
    string tituloLibro = (string)books[indiceLibro][0];

    MostrarUsuarios();
    Console.Write("Número del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceUsuario) || indiceUsuario < 1 || indiceUsuario > usuarios.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceUsuario--;
    string idUsuario = usuarios[indiceUsuario][1];

    if (UsuarioYaCalificoLibro(idUsuario, tituloLibro))
    {
        Console.WriteLine("Usuario ya calificó este libro");
        return;
    }

    Console.Write("Calificación (0.0 a 5.0): ");
    if (!double.TryParse(Console.ReadLine(), out double calificacion) || calificacion < 0.0 || calificacion > 5.0)
    {
        Console.WriteLine("Calificación inválida");
        return;
    }

    reseñas.Add(new string[] { tituloLibro, idUsuario, calificacion.ToString("F1"), "" });
    Console.WriteLine("Calificación agregada");
}

void EscribirReseña()
{
    Console.WriteLine("\n ESCRIBIR RESEÑA ");
    
    if (books.Count == 0 || usuarios.Count == 0)
    {
        Console.WriteLine("No hay libros o usuarios");
        return;
    }

    MostrarLibros();
    Console.Write("Número del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceLibro) || indiceLibro < 1 || indiceLibro > books.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceLibro--;
    string tituloLibro = (string)books[indiceLibro][0];

    MostrarUsuarios();
    Console.Write("Número del usuario: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceUsuario) || indiceUsuario < 1 || indiceUsuario > usuarios.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceUsuario--;
    string idUsuario = usuarios[indiceUsuario][1];

    Console.Write("Reseña (máximo 500 caracteres): ");
    string reseña = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(reseña) || reseña.Length > 500)
    {
        Console.WriteLine("Reseña inválida");
        return;
    }

    int indiceExistente = BuscarReseñaExistente(idUsuario, tituloLibro);
    if (indiceExistente != -1)
    {
        reseñas[indiceExistente][3] = reseña;
        Console.WriteLine("Reseña actualizada");
    }
    else
    {
        reseñas.Add(new string[] { tituloLibro, idUsuario, "0.0", reseña });
        Console.WriteLine("Reseña agregada");
    }
}

void VerCalificaciones()
{
    Console.WriteLine("\n CALIFICACIONES ");
    
    if (books.Count == 0)
    {
        Console.WriteLine("No hay libros");
        return;
    }

    MostrarLibros();
    Console.Write("Número del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceLibro) || indiceLibro < 1 || indiceLibro > books.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceLibro--;
    string tituloLibro = (string)books[indiceLibro][0];

    var calificaciones = reseñas.Where(r => r[0] == tituloLibro && r[2] != "0.0" && double.TryParse(r[2], out _))
                                .Select(r => double.Parse(r[2])).ToList();

    if (calificaciones.Count == 0)
    {
        Console.WriteLine("No hay calificaciones");
        return;
    }

    Console.WriteLine($"\nCalificaciones para '{tituloLibro}':");
    Console.WriteLine($"Total: {calificaciones.Count}");
    Console.WriteLine($"Promedio: {calificaciones.Average():F1}/5.0");
    Console.WriteLine($"Máxima: {calificaciones.Max():F1}");
    Console.WriteLine($"Mínima: {calificaciones.Min():F1}");
}

void VerReseñas()
{
    Console.WriteLine("\n RESEÑAS ");
    
    if (books.Count == 0)
    {
        Console.WriteLine("No hay libros");
        return;
    }

    MostrarLibros();
    Console.Write("Número del libro: ");
    if (!int.TryParse(Console.ReadLine(), out int indiceLibro) || indiceLibro < 1 || indiceLibro > books.Count)
    {
        Console.WriteLine("Número inválido");
        return;
    }

    indiceLibro--;
    string tituloLibro = (string)books[indiceLibro][0];

    var reseñasLibro = reseñas.Where(r => r[0] == tituloLibro && !string.IsNullOrWhiteSpace(r[3])).ToList();

    if (reseñasLibro.Count == 0)
    {
        Console.WriteLine("No hay reseñas");
        return;
    }

    Console.WriteLine($"\nReseñas para '{tituloLibro}':");
    foreach (var reseña in reseñasLibro)
    {
        string nombreUsuario = ObtenerNombreUsuarioPorId(reseña[1]);
        Console.WriteLine($"Usuario: {nombreUsuario}");
        Console.WriteLine($"Reseña: {reseña[3]}");
        Console.WriteLine("---");
    }
}

bool UsuarioYaCalificoLibro(string idUsuario, string tituloLibro) =>
    reseñas.Any(r => r[1] == idUsuario && r[0] == tituloLibro && r[2] != "0.0");

int BuscarReseñaExistente(string idUsuario, string tituloLibro) =>
    reseñas.FindIndex(r => r[1] == idUsuario && r[0] == tituloLibro);

void MostrarLibros()
{
    for (int i = 0; i < books.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {books[i][0]} - {books[i][1]}");
    }
}

void MostrarUsuarios()
{
    for (int i = 0; i < usuarios.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {usuarios[i][0]} (ID: {usuarios[i][1]})");
    }
}

void HandleStatistics()
{
    bool salir = false;
    while (!salir)
    {
        Console.WriteLine("\n ESTADÍSTICAS ");
        Console.WriteLine("1. Generales");
        Console.WriteLine("2. Libro más prestado");
        Console.WriteLine("3. Libros mejor calificados");
        Console.WriteLine("4. Usuarios más activos");
        Console.WriteLine("5. Volver");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": MostrarEstadisticasGenerales(); break;
            case "2": MostrarLibroMasPrestado(); break;
            case "3": MostrarLibrosMasCalificados(); break;
            case "4": MostrarEstadisticasUsuarios(); break;
            case "5": salir = true; break;
            default: Console.WriteLine("Opción inválida"); break;
        }
    }
}

void MostrarEstadisticasGenerales()
{
    Console.WriteLine("\n ESTADÍSTICAS GENERALES ");
    
    int totalLibros = books.Count;
    int librosDisponibles = books.Count(b => (bool)b[4]);
    int librosPrestados = totalLibros - librosDisponibles;
    int totalUsuarios = usuarios.Count;
    int totalPrestamos = prestamos.Count;
    int prestamosActivos = prestamos.Count(p => p[3] == "");
    int totalReseñas = reseñas.Count;
    int reseñasConCalificacion = reseñas.Count(r => r[2] != "0.0");
    
    Console.WriteLine($"Libros: {totalLibros} (Disponibles: {librosDisponibles}, Prestados: {librosPrestados})");
    Console.WriteLine($"Usuarios: {totalUsuarios}");
    Console.WriteLine($"Préstamos: {totalPrestamos} (Activos: {prestamosActivos})");
    Console.WriteLine($"Reseñas: {totalReseñas} (Con calificación: {reseñasConCalificacion})");
    
    if (totalLibros > 0)
    {
        double porcentajeDisponibles = (double)librosDisponibles / totalLibros * 100;
        Console.WriteLine($"Disponibilidad: {porcentajeDisponibles:F1}%");
    }
}

void MostrarLibroMasPrestado()
{
    Console.WriteLine("\n LIBRO MÁS PRESTADO ");
    
    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos");
        return;
    }
    
    var prestamosPorLibro = prestamos.GroupBy(p => p[1])
                                   .ToDictionary(g => g.Key, g => g.Count());
    
    var libroMasPrestado = prestamosPorLibro.OrderByDescending(kvp => kvp.Value).First();
    
    var book = books.FirstOrDefault(b => (string)b[0] == libroMasPrestado.Key);
    string autor = book != null ? (string)book[1] : "No encontrado";
    
    Console.WriteLine($"Libro: {libroMasPrestado.Key}");
    Console.WriteLine($"Autor: {autor}");
    Console.WriteLine($"Préstamos: {libroMasPrestado.Value}");
    
    Console.WriteLine("\nTop 5 libros más prestados:");
    var topLibros = prestamosPorLibro.OrderByDescending(kvp => kvp.Value).Take(5);
    foreach (var (libro, count) in topLibros)
    {
        Console.WriteLine($"{libro} - {count} préstamos");
    }
}

void MostrarLibrosMasCalificados()
{
    Console.WriteLine("\n LIBROS MEJOR CALIFICADOS ");
    
    if (reseñas.Count == 0)
    {
        Console.WriteLine("No hay reseñas");
        return;
    }
    
    var calificacionesPorLibro = reseñas.Where(r => r[2] != "0.0" && double.TryParse(r[2], out _))
                                        .GroupBy(r => r[0])
                                        .ToDictionary(g => g.Key, g => g.Select(r => double.Parse(r[2])).ToList());
    
    if (calificacionesPorLibro.Count == 0)
    {
        Console.WriteLine("No hay calificaciones");
        return;
    }
    
    var librosConPromedio = calificacionesPorLibro.Select(kvp => 
        (titulo: kvp.Key, promedio: kvp.Value.Average(), cantidad: kvp.Value.Count))
        .OrderByDescending(x => x.promedio).Take(5).ToList();
    
    Console.WriteLine("Top 5 libros mejor calificados:");
    foreach (var libro in librosConPromedio)
    {
        Console.WriteLine($"{libro.titulo}");
        Console.WriteLine($"  Promedio: {libro.promedio:F1}/5.0 ({libro.cantidad} calificaciones)");
    }
}

void MostrarEstadisticasUsuarios()
{
    Console.WriteLine("\n ESTADÍSTICAS DE USUARIOS ");
    
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios");
        return;
    }
    
    var prestamosPorUsuario = prestamos.GroupBy(p => p[0])
                                      .ToDictionary(g => g.Key, g => g.Count());
    
    var reseñasPorUsuario = reseñas.GroupBy(r => r[1])
                                  .ToDictionary(g => g.Key, g => g.Count());
    
    Console.WriteLine($"Total usuarios: {usuarios.Count}");
    Console.WriteLine($"Con préstamos: {prestamosPorUsuario.Count}");
    Console.WriteLine($"Con reseñas: {reseñasPorUsuario.Count}");
    
    if (prestamosPorUsuario.Count > 0)
    {
        Console.WriteLine("\nTop 5 usuarios más activos:");
        var topUsuarios = prestamosPorUsuario.OrderByDescending(kvp => kvp.Value).Take(5);
        foreach (var (id, count) in topUsuarios)
        {
            string nombre = ObtenerNombreUsuarioPorId(id);
            Console.WriteLine($"{nombre} - {count} préstamos");
        }
    }
    
    if (reseñasPorUsuario.Count > 0)
    {
        Console.WriteLine("\nTop 5 usuarios más reseñadores:");
        var topReseñadores = reseñasPorUsuario.OrderByDescending(kvp => kvp.Value).Take(5);
        foreach (var (id, count) in topReseñadores)
        {
            string nombre = ObtenerNombreUsuarioPorId(id);
            Console.WriteLine($"{nombre} - {count} reseñas");
        }
    }
}