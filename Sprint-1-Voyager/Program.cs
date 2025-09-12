using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Variables Globales 
List<List<object>> books = new List<List<object>>();

List<string[]> usuarios = new List<string[]>();

bool outSystem = false;

// Bucle Principal del Programa 
while (!outSystem)
{
    bool outBook = false; 

    Console.WriteLine("\n===== Sistema de biblioteca =====");
    Console.WriteLine("1. Gestión de libros");
    Console.WriteLine("2. Gestión de usuarios");
    Console.WriteLine("3. Préstamos y devoluciones");
    Console.WriteLine("4. Reseñas y calificaciones");
    Console.WriteLine("5. Estadísticas");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");
    string option = Console.ReadLine();
    int optionInt = int.Parse(option); 

    switch (optionInt)
    {
        case 1:
            // Menú Gestión de Libros 
            while (!outBook)
            {
                Console.WriteLine("\n===== Gestion de libros =====");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Actualizar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Buscar libro");
                Console.WriteLine("6. Volver al menu inicial");
                Console.Write("Elige una opción: ");
                string optionBook = Console.ReadLine();
                int optionBookI = int.Parse(optionBook);

                if (optionBookI == 1)
                {
                    Console.WriteLine("Por favor ingrese el titulo del libro:");
                    string title = Console.ReadLine();

                    Console.WriteLine("Por favor ingrese el autor del libro:");
                    string author = Console.ReadLine();

                    Console.WriteLine("Por favor ingrese la categoria del libro:");
                    string category = Console.ReadLine();

                    Console.WriteLine("Por favor ingrese el año de publicación:");
                    string year = Console.ReadLine();
                    int yearP = int.Parse(year);

                    Console.WriteLine("¿Esta disponible el libro? (s/n):");
                    bool available = Console.ReadLine().ToLower() == "s";

                    books.Add(new List<object> { title, author, category, yearP, available });
                    Console.WriteLine($"Libro '{title}' agregado.");
                }
                else if (optionBookI == 2)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros registrados.");
                        continue;
                    }
                    int i = 1;
                    foreach (var book in books)
                    {
                        string availableBook = (bool)book[4] ? "Sí" : "No";
                        Console.WriteLine($"{i}. Titulo: {book[0]} - Autor: {book[1]} - Categoria: {book[2]} - Año: {book[3]} -  Disponible: {availableBook}");
                        i++;
                    }
                }
                else if (optionBookI == 3)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros para actualizar.");
                        continue;
                    }

                    Console.Write("Nombre del libro a actualizar: ");
                    string title = Console.ReadLine();

                    bool found = false;
                    foreach (var book in books)
                    {
                        if ((string)book[0] == title)
                        {
                            Console.Write("Nuevo titulo (dejar vacío si no cambia): ");
                            string newTitle = Console.ReadLine();
                            if (newTitle != "")
                            {
                                book[0] = newTitle;
                            }

                            Console.Write("Nuevo autor (dejar vacío si no cambia): ");
                            string newAuthor = Console.ReadLine();
                            if (newAuthor != "")
                            {
                                book[1] = newAuthor;
                            }

                            Console.Write("Nueva categoria (dejar vacío si no cambia): ");
                            string newCategory = Console.ReadLine();
                            if (newCategory != "")
                            {
                                book[2] = newCategory;
                            }

                            Console.Write("Nuevo año (dejar vacío si no cambia): ");
                            string newYear = Console.ReadLine();
                            if (newYear != "")
                            {
                                book[3] = int.Parse(newYear);
                            }

                            Console.Write("Nueva disponibilidad (dejar vacío si no cambia): ");
                            string newAvailable = Console.ReadLine();
                            if (newAvailable != "")
                            {
                                book[4] = newAvailable.ToLower() == "s";
                            }

                            Console.WriteLine($"Libro '{title}' actualizado.");
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"No se encontró el producto '{title}'.");
                    }
                }
                else if (optionBookI == 4)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros para eliminar.");
                        continue;
                    }

                    Console.Write("Nombre del libro a eliminar: ");
                    string title = Console.ReadLine();

                    int index = books.FindIndex(p => (string)p[0] == title);

                    if (index != -1)
                    {
                        books.RemoveAt(index);
                        Console.WriteLine($"Libro '{title}' eliminado.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el libro '{title}'.");
                    }
                }
                else if (optionBookI == 5)
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros registrados.");
                        continue;
                    }

                    Console.WriteLine("\n===== Buscar libro =====");
                    Console.WriteLine("1. Buscar por título");
                    Console.WriteLine("2. Buscar por autor");
                    Console.WriteLine("3. Buscar por categoría");
                    Console.Write("Elige una opción: ");
                    string searchOption = Console.ReadLine();
                    int searchInt = int.Parse(searchOption);

                    Console.Write("Ingrese el texto a buscar: ");
                    string searchText = Console.ReadLine().ToLower();

                    bool found = false;
                    int i = 1;

                    foreach (var book in books)
                    {
                        string title = ((string)book[0]).ToLower();
                        string author = ((string)book[1]).ToLower();
                        string category = ((string)book[2]).ToLower();

                        if ((searchInt == 1 && title.Contains(searchText)) ||
                            (searchInt == 2 && author.Contains(searchText)) ||
                            (searchInt == 3 && category.Contains(searchText)))
                        {
                            string availableBook = (bool)book[4] ? "Sí" : "No";
                            Console.WriteLine($"{i}. Título: {book[0]} - Autor: {book[1]} - Categoría: {book[2]} - Año: {book[3]} - Disponible: {availableBook}");
                            found = true;
                        }
                        i++;
                    }

                    if (!found)
                    {
                        Console.WriteLine("No se encontraron libros con ese criterio.");
                    }
                }
                else if (optionBookI == 6)
                {
                    Console.WriteLine("Saliendo del menu gestión de libros...");
                    outBook = true;
                }
            }
            break;

        case 2:
            // Llamamos el metodo de gestion de usuarios
            HandleUserManagement(); 
            break;

        case 6:
            Console.WriteLine("Saliendo del sistema...");
            outSystem = true;
            break;
    }
}

// Metodo de gestion de usuarios
void HandleUserManagement()
{
    bool salir = false;
    while (!salir)
    {
        Console.WriteLine("\n================================");
        Console.WriteLine("    SISTEMA CRUD DE USUARIOS  ");
        Console.WriteLine("================================");
        Console.WriteLine("1. Registrar nuevo usuario");
        Console.WriteLine("2. Consultar lista de usuarios");
        Console.WriteLine("3. Actualizar un usuario");
        Console.WriteLine("4. Eliminar un usuario");
        Console.WriteLine("5. Volver al menú principal");
        Console.Write("Elige una opción: ");

        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                RegistrarUsuario();
                break;
            case "2":
                ConsultarUsuarios();
                break;
            case "3":
                ActualizarUsuario();
                break;
            case "4":
                EliminarUsuario();
                break;
            case "5":
                salir = true;
                Console.WriteLine("Volviendo al menú principal...");
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elige un número del 1 al 5.");
                break;
        }
    }
}

void RegistrarUsuario()
{
    Console.WriteLine("\n-- REGISTRO DE NUEVO USUARIO --");

    string nombre = ObtenerDatoValidado("Ingresa el nombre completo: ", ValidarNombre);
    string id = ObtenerDatoValidado("Identificación: ", ValidarId);

    if (BuscarIndiceUsuarioPorId(id) != -1)
    {
        Console.WriteLine("Error: Ya existe un usuario con esa identificación.");
        return;
    }

    string correo = ObtenerDatoValidado("Correo electrónico: ", ValidarCorreo);

    string[] nuevoUsuario = { nombre, id, correo };
    usuarios.Add(nuevoUsuario);
    Console.WriteLine("¡Usuario registrado con éxito!");
}

string ObtenerDatoValidado(string mensaje, Func<string, (bool, string)> validador)
{
    string input;
    while (true)
    {
        Console.Write(mensaje);
        input = Console.ReadLine();
        var (esValido, error) = validador(input);
        if (esValido)
        {
            return input;
        }
        Console.WriteLine($"Error: {error}");
    }
}

(bool, string) ValidarNombre(string nombre)
{
    if (string.IsNullOrWhiteSpace(nombre))
        return (false, "El nombre no puede estar vacío.");

    if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
        return (false, "El nombre solo puede contener letras y espacios.");

    if (nombre.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length < 2)
        return (false, "Debes ingresar al menos un nombre y un apellido.");

    return (true, "");
}

(bool, string) ValidarId(string id)
{
    if (string.IsNullOrWhiteSpace(id))
        return (false, "La identificación no puede estar vacía.");

    if (!Regex.IsMatch(id, @"^[0-9]+$"))
        return (false, "La identificación solo puede contener números.");

    return (true, "");
}

(bool, string) ValidarCorreo(string correo)
{
    if (string.IsNullOrWhiteSpace(correo))
        return (false, "El correo no puede estar vacío.");

    try
    {
        var addr = new System.Net.Mail.MailAddress(correo);
        return (addr.Address == correo, "");
    }
    catch
    {
        return (false, "El formato del correo electrónico no es válido.");
    }
}

void ConsultarUsuarios()
{
    Console.WriteLine("\n-- LISTA DE USUARIOS REGISTRADOS --");

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados por el momento.");
        return;
    }

    Console.WriteLine($"{"Nombre Completo",-30} | {"Identificación",-20} | {"Correo Electrónico",-30}");

    foreach (var usuario in usuarios)
    {
        string nombre = usuario[0];
        string id = usuario[1];
        string correo = usuario[2];
        Console.WriteLine($"{nombre,-30} | {id,-20} | {correo,-30}");
    }
}

void ActualizarUsuario()
{
    Console.WriteLine("\nACTUALIZAR USUARIO");
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios para actualizar.");
        return;
    }

    Console.Write("Ingresa la identificación del usuario a actualizar: ");
    string idBusqueda = Console.ReadLine();

    int indice = BuscarIndiceUsuarioPorId(idBusqueda);

    if (indice == -1)
    {
        Console.WriteLine("No se encontró ningún usuario con esa identificación.");
    }
    else
    {
        string[] usuarioAActualizar = usuarios[indice];
        Console.WriteLine("Usuario encontrado. Ingresa los nuevos datos (deja en blanco para no cambiar).");

        Console.Write($"Nombre actual ({usuarioAActualizar[0]}): ");
        string nuevoNombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevoNombre))
        {
            usuarioAActualizar[0] = nuevoNombre;
        }

        Console.Write($"Correo actual ({usuarioAActualizar[2]}): ");
        string nuevoCorreo = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevoCorreo))
        {
            usuarioAActualizar[2] = nuevoCorreo;
        }

        usuarios[indice] = usuarioAActualizar;
        Console.WriteLine("¡Usuario actualizado correctamente!");
    }
}

void EliminarUsuario()
{
    Console.WriteLine("\nELIMINAR USUARIO");
    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios para eliminar.");
        return;
    }

    Console.Write("Ingresa la identificación del usuario a eliminar: ");
    string idBusqueda = Console.ReadLine();

    int indice = BuscarIndiceUsuarioPorId(idBusqueda);

    if (indice == -1)
    {
        Console.WriteLine("No se encontró ningún usuario con esa identificación.");
    }
    else
    {
        string[] usuarioAEliminar = usuarios[indice];
        Console.WriteLine($"Usuario a eliminar: Nombre: {usuarioAEliminar[0]}, ID: {usuarioAEliminar[1]}");
        Console.Write("¿Estás seguro de que deseas eliminarlo? (s/n): ");
        string confirmacion = Console.ReadLine().ToLower();

        if (confirmacion == "s")
        {
            usuarios.RemoveAt(indice);
            Console.WriteLine("Usuario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }
}

int BuscarIndiceUsuarioPorId(string id)
{
    for (int i = 0; i < usuarios.Count; i++)
    {
        if (usuarios[i][1] == id)
        {
            return i;
        }
    }
    return -1;
}