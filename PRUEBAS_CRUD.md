# PRUEBAS CRUD - Visualizador de Estructuras de Datos

## Estado de la Aplicación
✅ **Aplicación ejecutándose en:** http://localhost:5000

## Pruebas a Realizar

### 1. DASHBOARD PRINCIPAL
**URL:** http://localhost:5000/Library
- [ ] Verificar que se muestren las estadísticas correctamente
- [ ] Verificar que se muestren los 10 libros más recientes
- [ ] Verificar que los contadores se actualicen en tiempo real

### 2. GESTIÓN DE LIBROS (Lista Enlazada)
**URL:** http://localhost:5000/Library/Catalogo

#### 2.1 Ver Catálogo
- [ ] Verificar que se muestren todos los libros
- [ ] Verificar que funcione la búsqueda por título
- [ ] Verificar que funcione el filtro por categoría
- [ ] Verificar que se muestren los botones de información sobre lista enlazada

#### 2.2 Agregar Libro
**URL:** http://localhost:5000/Library/AgregarLibro
- [ ] Llenar formulario con datos de prueba:
  - Título: "El Señor de los Anillos"
  - Autor: "J.R.R. Tolkien"
  - ISBN: "978-0547928210"
  - Año: 1954
  - Categoría: "Ficción"
  - Stock: 3
- [ ] Verificar que se guarde correctamente
- [ ] Verificar que aparezca en el catálogo

#### 2.3 Editar Libro
- [ ] Hacer clic en "Editar" en cualquier libro
- [ ] Modificar algún campo (ej: cambiar stock a 5)
- [ ] Verificar que se guarde la modificación
- [ ] Verificar que se refleje en el catálogo

#### 2.4 Eliminar Libro
- [ ] Hacer clic en "Eliminar" en un libro
- [ ] Confirmar eliminación
- [ ] Verificar que desaparezca del catálogo

### 3. GESTIÓN DE CATEGORÍAS (Árbol)
**URL:** http://localhost:5000/Library/Categorias

#### 3.1 Ver Categorías
- [ ] Verificar que se muestren las 3 categorías iniciales
- [ ] Verificar que se muestre el botón de información sobre árbol

#### 3.2 Agregar Categoría
**URL:** http://localhost:5000/Library/AgregarCategoria
- [ ] Llenar formulario:
  - Nombre: "Ciencia Ficción"
  - Descripción: "Libros de ciencia ficción y fantasía"
- [ ] Verificar que se guarde
- [ ] Verificar que aparezca en la lista

#### 3.3 Editar Categoría
- [ ] Editar una categoría existente
- [ ] Modificar descripción
- [ ] Verificar que se guarde

#### 3.4 Eliminar Categoría
- [ ] Eliminar una categoría
- [ ] Verificar que se elimine

### 4. GESTIÓN DE RESERVAS (Cola)
**URL:** http://localhost:5000/Library/Reservas

#### 4.1 Ver Reservas
- [ ] Verificar que se muestre la tabla de reservas
- [ ] Verificar que se muestre información sobre cola

#### 4.2 Agregar Reserva
**URL:** http://localhost:5000/Library/AgregarReserva
- [ ] Llenar formulario:
  - Libro: Seleccionar "Cien Años de Soledad"
  - Solicitante: "Juan Pérez"
- [ ] Verificar que se guarde
- [ ] Verificar que aparezca en la lista

#### 4.3 Editar Reserva
- [ ] Editar una reserva existente
- [ ] Modificar datos
- [ ] Verificar que se guarde

#### 4.4 Eliminar Reserva
- [ ] Eliminar una reserva
- [ ] Verificar que se elimine

### 5. GESTIÓN DE PRÉSTAMOS (Pila)
**URL:** http://localhost:5000/Library/HistorialTransacciones

#### 5.1 Ver Historial
- [ ] Verificar que se muestre la tabla de préstamos
- [ ] Verificar que se muestre información sobre pila

#### 5.2 Prestar Libro
**URL:** http://localhost:5000/Library/PrestarLibro
- [ ] Llenar formulario:
  - Libro: Seleccionar "Rayuela"
  - Usuario: "María García"
- [ ] Verificar que se guarde
- [ ] Verificar que aparezca en el historial

#### 5.3 Devolver Libro
- [ ] Hacer clic en "Devolver" en un préstamo activo
- [ ] Confirmar devolución
- [ ] Verificar que cambie el estado a "Devuelto"

#### 5.4 Editar Préstamo
- [ ] Editar un préstamo
- [ ] Modificar datos
- [ ] Verificar que se guarde

#### 5.5 Eliminar Préstamo
- [ ] Eliminar un préstamo
- [ ] Verificar que se elimine

## ESTRUCTURAS DE DATOS IMPLEMENTADAS

### ✅ Lista Enlazada (Libros)
- **Ubicación:** Catálogo de libros
- **Características:** Inserción/eliminación eficiente, recorrido secuencial
- **Visualización:** Tabla con botones de información

### ✅ Árbol (Categorías)
- **Ubicación:** Gestión de categorías
- **Características:** Organización jerárquica
- **Visualización:** Tabla con información sobre estructura de árbol

### ✅ Cola (Reservas)
- **Ubicación:** Gestión de reservas
- **Características:** FIFO (First In, First Out)
- **Visualización:** Tabla ordenada por fecha de solicitud

### ✅ Pila (Préstamos)
- **Ubicación:** Historial de transacciones
- **Características:** LIFO (Last In, First Out)
- **Visualización:** Tabla ordenada por fecha de préstamo (más recientes primero)

## NOTAS IMPORTANTES

1. **Sin Validaciones:** Todos los formularios están configurados sin validaciones para facilitar las pruebas
2. **Eliminación Directa:** Los botones de eliminar funcionan directamente sin antiforgery token
3. **Datos de Prueba:** La base de datos incluye 12 libros iniciales (4 por cada categoría)
4. **Relaciones:** Los modelos están correctamente relacionados con claves foráneas

## RESULTADO ESPERADO

Al completar todas las pruebas, el sistema debería:
- ✅ Permitir CRUD completo en todas las entidades
- ✅ Mostrar información didáctica sobre estructuras de datos
- ✅ Mantener consistencia en la base de datos
- ✅ Proporcionar una experiencia de usuario fluida 