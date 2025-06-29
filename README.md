# 📚 Sistema de Gestión de Biblioteca - Visualizador de Estructuras de Datos

Este proyecto es una aplicación web ASP.NET Core MVC que demuestra el uso práctico de estructuras de datos fundamentales (listas enlazadas, pilas, colas y árboles) en la gestión de una biblioteca.

---

## 🚀 Instalación y Ejecución

### 1. **Requisitos Previos**
- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional, la base de datos se crea automáticamente)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/) o [Visual Studio Code](https://code.visualstudio.com/)
- Git (opcional, para clonar el repositorio)

### 2. **Clonar el Repositorio**
```bash
git clone https://github.com/tu-usuario/tu-repo.git
cd tu-repo
```

### 3. **Restaurar Dependencias**
```bash
dotnet restore
```

### 4. **Aplicar Migraciones y Crear la Base de Datos**
```bash
dotnet ef database update
```
> Si no tienes instalado Entity Framework CLI, instálalo con:
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 5. **Ejecutar la Aplicación**
```bash
dotnet run --urls "http://localhost:5000"
```

Abre tu navegador y visita: [http://localhost:5000](http://localhost:5000)

---

## 🛠️ Tecnologías Utilizadas
- **ASP.NET Core 9.0**
- **Entity Framework Core (SQLite)**
- **Bootstrap 5**
- **Font Awesome**
- **C# 12**

---

## 📦 Estructuras de Datos Implementadas
- **Lista Enlazada:** Catálogo de libros
- **Pila:** Historial de transacciones (préstamos y devoluciones)
- **Cola:** Gestión de reservas
- **Árbol:** Jerarquía de categorías

---

## 📸 Capturas de Pantalla

| Dashboard Principal | Vista de Categorías |
|--------------------|--------------------|
| ![Dashboard](docs/dashboard.png) | ![Árbol de Categorías](docs/arbol.png) |

---

## 📝 Notas
- El sistema se ejecuta en modo desarrollo por defecto.
- Puedes modificar la cadena de conexión a la base de datos en `appsettings.json`.
- Si tienes problemas con puertos ocupados, cambia el puerto en el comando `dotnet run`.

---

## 👨‍💻 Autor y Créditos
- **Autor:** [Tu Nombre](https://github.com/tu-usuario)
- **Docente:** [Nombre del docente]
- **Curso:** Estructuras de Datos

---

## 📄 Licencia
Este proyecto se distribuye bajo la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más información.
