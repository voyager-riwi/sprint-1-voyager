List<List<object>> books = new List<List<object>>();
bool outSystem = false;
bool outBook = false;

while (!outSystem)
{
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
        {
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
                    bool available = Console.ReadLine().Equals("s");

                    books.Add(new List<object> { title,  author, category, yearP, available });
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
        }
        case 6:
        {
            Console.WriteLine("Saliendo del sistema...");
            outSystem = true;
            break;
        }
    }
}
