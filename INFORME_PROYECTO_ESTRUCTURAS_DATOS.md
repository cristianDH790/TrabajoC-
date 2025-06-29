# INFORME DEL PROYECTO: SISTEMA DE GESTIÓN DE BIBLIOTECA
## Demostración de Estructuras de Datos

---

## 1. PORTADA

**Nombre del Proyecto:** Sistema de Gestión de Biblioteca - Visualizador de Estructuras de Datos

**Integrantes del Equipo:** [Tu nombre]

**Curso y Sección:** Estructuras de Datos - [Sección]

**Docente:** [Nombre del docente]

**Fecha de Entrega:** [Fecha actual]

---

## 2. ANÁLISIS DEL PROBLEMA

### Descripción del Problema Detectado

La gestión tradicional de bibliotecas presenta múltiples desafíos que requieren soluciones eficientes:

- **Gestión manual de inventario:** Dificultad para mantener un control actualizado de libros disponibles y prestados
- **Procesamiento de reservas:** Falta de un sistema ordenado para manejar solicitudes de libros
- **Organización de categorías:** Ausencia de una estructura jerárquica para clasificar el material bibliográfico
- **Seguimiento de transacciones:** Imposibilidad de mantener un historial ordenado de préstamos y devoluciones
- **Búsqueda ineficiente:** Tiempo excesivo para localizar libros específicos en el catálogo

### Diagrama de Ishikawa (Causa-Efecto)

```
                    GESTIÓN INEFICIENTE DE BIBLIOTECA
                              │
        ┌─────────────────────┼─────────────────────┐
        │                     │                     │
    MÉTODOS              MATERIALES            PERSONAL
        │                     │                     │
    ┌───┴───┐           ┌───┴───┐           ┌───┴───┐
    │       │           │       │           │       │
• Gestión   │         • Falta   │         • Personal│
  manual    │           de      │           limitado │
• Sin       │           sistema │         • Falta de │
  software  │           digital │           capacitación│
• Procesos  │         • Recursos│         • Sobrecarga│
  lentos    │           limitados│           de trabajo│
    │           │           │
    └───────────┘           └───────────┘           └───────────┘
        │                     │                     │
    AMBIENTE              MEDICIÓN              MÁQUINAS
        │                     │                     │
    ┌───┴───┐           ┌───┴───┐           ┌───┴───┐
    │       │           │       │           │       │
• Espacio   │         • Sin     │         • Sin     │
  limitado  │           métricas│           equipos  │
• Falta de  │           de      │           informáticos│
  organización│           rendimiento│         • Infraestructura│
• Condiciones│         • Sin     │           obsoleta│
  inadecuadas│           control │         • Falta de │
    │           de calidad│           automatización│
    └───────────┘           └───────────┘           └───────────┘
```

### Explicación de Causas

**Métodos:** La ausencia de procesos sistematizados y software especializado genera ineficiencias operativas.

**Materiales:** La falta de recursos digitales y sistemas informáticos limita la capacidad de gestión.

**Personal:** La escasez de personal capacitado y la sobrecarga de trabajo afectan la calidad del servicio.

**Ambiente:** Las limitaciones de espacio y organización física dificultan el control del inventario.

**Medición:** La ausencia de métricas y controles de calidad impide la mejora continua.

**Máquinas:** La falta de equipos informáticos y automatización limita la eficiencia operativa.

---

## 3. OBJETIVOS

### Objetivo General

Desarrollar un sistema de gestión de biblioteca que demuestre la implementación práctica de estructuras de datos fundamentales (listas enlazadas, pilas, colas y árboles) para resolver problemas reales de organización y gestión de información bibliográfica.

### Objetivos Específicos

1. **Implementar estructuras de datos personalizadas** para gestionar libros (lista enlazada), transacciones (pila), reservas (cola) y categorías (árbol).

2. **Desarrollar una interfaz web intuitiva** que permita visualizar y operar sobre las estructuras de datos implementadas, facilitando la comprensión de su funcionamiento.

3. **Demostrar la eficiencia operativa** de cada estructura de datos en su contexto específico, evidenciando las ventajas de su implementación sobre métodos tradicionales.

4. **Crear un sistema funcional** que permita realizar operaciones CRUD completas sobre libros, categorías, transacciones y reservas, validando la utilidad práctica de las estructuras implementadas.

---

## 4. ALCANCE DE LA SOLUCIÓN

### Funcionalidades Incluidas

✅ **Gestión de Libros**
- Agregar, editar, eliminar y listar libros
- Control de stock y disponibilidad
- Búsqueda por título, autor o categoría
- Visualización de libros recientes

✅ **Gestión de Categorías**
- Crear jerarquía de categorías y subcategorías
- Organización en estructura de árbol
- Visualización de niveles y relaciones padre-hijo

✅ **Gestión de Transacciones**
- Registro de préstamos y devoluciones
- Historial ordenado por fecha (LIFO)
- Control de estado de libros

✅ **Gestión de Reservas**
- Crear y gestionar reservas de libros
- Procesamiento en orden FIFO
- Control de reservas pendientes

✅ **Dashboard Interactivo**
- Estadísticas en tiempo real
- Modales explicativos de estructuras
- Visualización de datos con gráficos

### Funcionalidades No Incluidas

❌ **Gestión de Usuarios**
- Sistema de autenticación y autorización
- Perfiles de usuario y roles
- Historial personal de préstamos

❌ **Reportes Avanzados**
- Generación de reportes PDF
- Estadísticas detalladas por período
- Análisis de tendencias

❌ **Notificaciones**
- Sistema de alertas por email
- Recordatorios de devolución
- Notificaciones push

❌ **Integración Externa**
- Conexión con APIs de libros
- Sincronización con sistemas externos
- Importación masiva de datos

### Tipos de Usuario Considerados

- **Administrador de Biblioteca:** Gestión completa del sistema
- **Bibliotecario:** Operaciones diarias de préstamo y devolución
- **Estudiante/Investigador:** Consulta de catálogo y reservas
- **Docente:** Gestión de categorías y organización temática

---

## 5. RESTRICCIONES REALISTAS

### Restricciones Técnicas

- **Plataforma:** Desarrollo web con ASP.NET Core MVC
- **Base de Datos:** SQLite para simplicidad de despliegue
- **Recursos:** Limitado a estructuras de datos básicas (no algoritmos avanzados)
- **Interfaz:** Bootstrap para responsividad básica

### Restricciones de Tiempo

- **Duración del proyecto:** Limitado al período académico
- **Desarrollo:** Implementación de funcionalidades core únicamente
- **Testing:** Pruebas básicas de funcionalidad

### Simplificaciones Asumidas

- **Sin autenticación:** Sistema de acceso libre para demostración
- **Datos de prueba:** Información ficticia para demostración
- **Validaciones básicas:** Sin validaciones complejas de negocio
- **Sin optimizaciones:** Implementación directa sin optimizaciones de rendimiento

---

## 6. ESTRUCTURAS DE DATOS UTILIZADAS

### 6.1 Listas Enlazadas

**Implementación:** `Models/LinkedList.cs`

```csharp
public class LinkedList<T>
{
    private LinkedListNode<T>? _head;
    private int _count;
    
    public void AddLast(T data) { /* Agregar al final */ }
    public T? Find(Func<T, bool> predicate) { /* Búsqueda */ }
    public bool Remove(Func<T, bool> predicate) { /* Eliminación */ }
}
```

**Aplicación en el Sistema:**
- **Gestión de Libros:** Almacenamiento secuencial de libros en el catálogo
- **Operaciones:** Agregar nuevos libros, buscar por criterios, eliminar libros
- **Ventajas:** Inserción eficiente O(1) al final, eliminación dinámica sin reorganización

**Justificación:** La lista enlazada permite un crecimiento dinámico del catálogo sin necesidad de preasignar espacio, ideal para bibliotecas con inventarios variables.

### 6.2 Pilas (Stack)

**Implementación:** `Models/Stack.cs`

```csharp
public class Stack<T>
{
    private LinkedListNode<T>? _top;
    
    public void Push(T data) { /* Agregar al tope */ }
    public T Pop() { /* Remover del tope */ }
    public T Peek() { /* Ver tope sin remover */ }
}
```

**Aplicación en el Sistema:**
- **Historial de Transacciones:** Último préstamo/devolución es el primero en mostrarse
- **Operaciones:** Push (nuevo préstamo), Pop (devolución), Peek (ver transacción actual)
- **Ventajas:** Control LIFO natural para historial, fácil deshacer operaciones

**Justificación:** La pila refleja el comportamiento natural del historial donde las transacciones más recientes son las más relevantes para el usuario.

### 6.3 Colas (Queue)

**Implementación:** `Models/Queue.cs`

```csharp
public class Queue<T>
{
    private LinkedListNode<T>? _front;
    private LinkedListNode<T>? _rear;
    
    public void Enqueue(T data) { /* Agregar al final */ }
    public T Dequeue() { /* Remover del frente */ }
    public T Peek() { /* Ver frente sin remover */ }
}
```

**Aplicación en el Sistema:**
- **Gestión de Reservas:** Primera reserva es la primera en ser atendida
- **Operaciones:** Enqueue (nueva reserva), Dequeue (procesar reserva), Peek (ver siguiente)
- **Ventajas:** Orden justo FIFO, gestión de prioridades natural

**Justificación:** La cola garantiza un procesamiento justo y ordenado de las reservas, respetando el principio de "primero en llegar, primero en ser atendido".

### 6.4 Árboles (Tree)

**Implementación:** `Models/Tree.cs`

```csharp
public class Tree<T>
{
    public TreeNode<T>? Root { get; private set; }
    
    public void AddChild(T data) { /* Agregar hijo */ }
    public TreeNode<T>? FindNode(Func<T, bool> predicate) { /* Búsqueda */ }
    public List<T> DepthFirstTraversal() { /* Recorrido DFS */ }
    public List<T> BreadthFirstTraversal() { /* Recorrido BFS */ }
}
```

**Aplicación en el Sistema:**
- **Organización de Categorías:** Jerarquía de categorías principales y subcategorías
- **Operaciones:** Agregar categorías, buscar en árbol, recorridos DFS/BFS
- **Ventajas:** Organización jerárquica natural, búsqueda eficiente, escalabilidad

**Justificación:** El árbol permite una organización lógica y escalable de categorías, facilitando la navegación y búsqueda de libros por temas.

---

## 7. HERRAMIENTAS UTILIZADAS

### Lenguaje de Programación
- **C# 12.0:** Lenguaje principal del proyecto
- **HTML/CSS/JavaScript:** Frontend y interactividad
- **SQL:** Consultas de base de datos

### Entorno de Desarrollo (IDE)
- **Visual Studio 2022:** IDE principal para desarrollo
- **Visual Studio Code:** Editor alternativo para archivos específicos
- **Git Bash:** Control de versiones y terminal

### Librerías y Frameworks
- **ASP.NET Core 9.0:** Framework web
- **Entity Framework Core 9.0.6:** ORM para base de datos
- **Bootstrap 5:** Framework CSS para interfaz
- **Font Awesome:** Iconografía
- **SQLite:** Base de datos embebida

### Gestión de Versiones
- **Git:** Control de versiones
- **GitHub:** Repositorio remoto

### Herramientas Adicionales
- **Entity Framework Tools:** Migraciones de base de datos
- **NuGet Package Manager:** Gestión de dependencias
- **Browser Developer Tools:** Debugging frontend

---

## 8. PRODUCTO SOFTWARE

### Descripción General del Programa

El **Sistema de Gestión de Biblioteca** es una aplicación web desarrollada en ASP.NET Core MVC que demuestra la implementación práctica de cuatro estructuras de datos fundamentales:

- **Lista Enlazada:** Para gestión del catálogo de libros
- **Pila:** Para historial de transacciones (LIFO)
- **Cola:** Para gestión de reservas (FIFO)
- **Árbol:** Para organización jerárquica de categorías

### Capturas de Pantalla del Sistema Funcionando

#### Dashboard Principal
```
┌─────────────────────────────────────────────────────────────┐
│                SISTEMA DE GESTIÓN DE BIBLIOTECA             │
│           Demostración de Estructuras de Datos              │
├─────────────────────────────────────────────────────────────┤
│  ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ ┌─────────┐ │
│  │  150    │ │   89    │ │   61    │ │  234    │ │   12    │ │
│  │ Libros  │ │Dispon.  │ │Prest.   │ │Transac. │ │Reservas │ │
│  │[Lista]  │ │[Lista]  │ │[Lista]  │ │ [Pila]  │ │ [Cola]  │ │
│  └─────────┘ └─────────┘ └─────────┘ └─────────┘ └─────────┘ │
│                                                             │
│  ┌─────────┐                                                │
│  │   8     │                                                │
│  │Categorías│                                               │
│  │ [Árbol] │                                                │
│  └─────────┘                                                │
└─────────────────────────────────────────────────────────────┘
```

#### Vista de Categorías (Estructura de Árbol)
```
┌─────────────────────────────────────────────────────────────┐
│                    CATEGORÍAS                               │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ 📁 Literatura                                           │ │
│  │   └── 📁 Novela                                         │ │
│  │       └── 📁 Novela Romántica                           │ │
│  │       └── 📁 Novela de Aventuras                        │ │
│  │   └── 📁 Poesía                                         │ │
│  │                                                         │ │
│  │ 📁 Ciencias                                             │ │
│  │   └── 📁 Matemáticas                                    │ │
│  │   └── 📁 Física                                         │ │
│  │       └── 📁 Mecánica Cuántica                          │ │
│  └─────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

### Explicación del Flujo de Ejecución

1. **Inicio de Aplicación:**
   - Carga de configuración y conexión a base de datos
   - Inicialización de estructuras de datos
   - Carga de datos existentes en memoria

2. **Navegación del Usuario:**
   - Dashboard principal con estadísticas
   - Navegación a módulos específicos
   - Interacción con modales explicativos

3. **Operaciones CRUD:**
   - Crear, leer, actualizar y eliminar registros
   - Actualización automática de estructuras
   - Persistencia en base de datos

4. **Visualización de Estructuras:**
   - Renderizado de datos según estructura
   - Actualización en tiempo real
   - Interfaz responsiva

### Cómo se Evidencia el Uso de las Estructuras

#### En el Dashboard:
- **Cards clickeables** que abren modales explicativos
- **Contadores en tiempo real** que reflejan el estado de las estructuras
- **Iconos indicativos** del tipo de estructura utilizada

#### En las Vistas Específicas:
- **Categorías:** Visualización jerárquica con sangría
- **Transacciones:** Orden cronológico inverso (LIFO)
- **Reservas:** Orden de llegada (FIFO)
- **Libros:** Lista secuencial con navegación

#### En el Código:
- **Clases personalizadas** para cada estructura
- **Métodos específicos** de cada estructura implementados
- **Uso directo** en lugar de colecciones genéricas del framework

---

## 9. CONCLUSIONES

### Aprendizaje Alcanzado por el Equipo

1. **Comprensión Profunda de Estructuras:** La implementación práctica permitió comprender no solo la teoría, sino también las ventajas y limitaciones de cada estructura en contextos reales.

2. **Desarrollo de Software Completo:** Se adquirió experiencia en el desarrollo de aplicaciones web completas, desde la base de datos hasta la interfaz de usuario.

3. **Integración de Tecnologías:** Se aprendió a integrar múltiples tecnologías (C#, ASP.NET, Entity Framework, Bootstrap) en un proyecto cohesivo.

4. **Resolución de Problemas:** Se desarrolló la capacidad de identificar qué estructura de datos es más apropiada para cada tipo de problema.

### Reflexión sobre la Utilidad de las Estructuras

**Listas Enlazadas:** Demostraron ser ideales para catálogos dinámicos donde el tamaño no es predecible y se requieren inserciones/eliminaciones frecuentes.

**Pilas:** Probaron su utilidad en el manejo de historiales y operaciones que requieren deshacer, siendo intuitivas para el usuario final.

**Colas:** Mostraron su eficacia en la gestión de procesos que requieren orden justo, como las reservas de libros.

**Árboles:** Evidenciaron su poder para organizar información jerárquica de manera natural y escalable.

### Posibles Mejoras o Extensiones

1. **Algoritmos de Búsqueda Avanzados:**
   - Implementar búsqueda binaria para catálogos ordenados
   - Agregar búsqueda fuzzy para títulos similares

2. **Optimizaciones de Rendimiento:**
   - Implementar caché para consultas frecuentes
   - Optimizar consultas de base de datos

3. **Funcionalidades Adicionales:**
   - Sistema de recomendaciones basado en préstamos previos
   - Integración con APIs de libros externas
   - Sistema de notificaciones automáticas

4. **Interfaz de Usuario:**
   - Visualizaciones gráficas de las estructuras de datos
   - Modo de demostración paso a paso
   - Tutorial interactivo

---

## 10. ANEXOS

### Anexo A: Fragmentos de Código Destacados

#### Implementación de Nodo de Lista Enlazada
```csharp
public class LinkedListNode<T>
{
    public T Data { get; set; }
    public LinkedListNode<T>? Next { get; set; }
    
    public LinkedListNode(T data)
    {
        Data = data;
        Next = null;
    }
}
```

#### Método de Búsqueda en Árbol
```csharp
private TreeNode<T>? FindNodeRecursive(TreeNode<T> node, Func<T, bool> predicate)
{
    if (predicate(node.Data))
        return node;

    foreach (var child in node.Children)
    {
        var result = FindNodeRecursive(child, predicate);
        if (result != null)
            return result;
    }
    return null;
}
```

### Anexo B: Casos de Prueba

#### Prueba de Lista Enlazada
```csharp
// Agregar libros
librosList.AddLast(libro1);
librosList.AddLast(libro2);
Assert.AreEqual(2, librosList.Count);

// Buscar libro
var encontrado = librosList.Find(l => l.Titulo == "Don Quijote");
Assert.IsNotNull(encontrado);
```

#### Prueba de Pila
```csharp
// Agregar transacciones
transaccionesStack.Push(transaccion1);
transaccionesStack.Push(transaccion2);
Assert.AreEqual(transaccion2, transaccionesStack.Peek());
```

### Anexo C: Manual de Usuario Básico

#### Acceso al Sistema
1. Abrir navegador web
2. Navegar a `http://localhost:5011`
3. Hacer clic en "Library" en el menú principal

#### Gestión de Libros
1. Ir a "Catálogo" para ver todos los libros
2. Hacer clic en "Agregar Libro" para crear nuevo
3. Completar formulario y guardar
4. Usar botones "Editar" o "Eliminar" según necesidad

#### Gestión de Categorías
1. Ir a "Categorías" para ver estructura jerárquica
2. Hacer clic en "Agregar Categoría"
3. Seleccionar categoría padre si es subcategoría
4. Guardar cambios

#### Visualización de Estructuras
1. En el dashboard, hacer clic en cualquier card
2. Leer explicación de la estructura en el modal
3. Navegar a la vista correspondiente para ver implementación

---

**Fin del Informe** 