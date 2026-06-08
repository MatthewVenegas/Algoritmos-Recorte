# Algoritmos de Recorte (Clipping Algorithms)

Este repositorio contiene la implementación y visualización de diversos algoritmos de discretización y recorte en 2D (tanto para líneas como para polígonos) desarrollados en C# con Windows Forms.

## 🚀 Características
- **Interfaz Gráfica Interactiva**: Visualización en tiempo real del paso a paso de cada algoritmo.
- **Paso a Paso Detallado**: Explicación en texto de las decisiones matemáticas que toma cada algoritmo en cada etapa del recorte.
- **Editor de Píxeles**: Permite analizar la discretización y recorte a bajo nivel.

## 📐 Algoritmos de Recorte Implementados

### ➖ Recorte de Líneas
1. **Cohen-Sutherland**: Basado en códigos de región (outcodes) de 4 bits. Divide el espacio en 9 regiones y utiliza operaciones lógicas AND para descartar o aceptar líneas rápidamente.
2. **Liang-Barsky**: Algoritmo paramétrico más eficiente que Cohen-Sutherland. Utiliza la ecuación paramétrica de la línea ($x = x_0 + u\Delta x$, $y = y_0 + u\Delta y$) y resuelve desigualdades para determinar los valores de entrada ($u_1$) y salida ($u_2$).
3. **Subdivisión del Punto Medio (Midpoint Division)**: Combina Cohen-Sutherland con búsqueda binaria (subdivisión sucesiva por el punto medio) para encontrar las intersecciones con los bordes de la ventana sin realizar divisiones explícitas.

### ⬡ Recorte de Polígonos
1. **Cyrus-Beck**: Algoritmo paramétrico generalizado para polígonos convexos. Utiliza vectores normales interiores a las aristas del polígono de recorte y calcula los parámetros $t$ de entrada y salida para recortar aristas.
2. **Sutherland-Hodgman**: Recorta el polígono procesándolo secuencialmente contra cada uno de los cuatro bordes de la ventana de recorte. Los vértices resultantes de un borde son la entrada para el siguiente.
3. **Weiler-Atherton**: Permite recortar polígonos cóncavos y con huecos. Utiliza listas enlazadas de vértices para el polígono sujeto y de recorte, recorriendo intersecciones hacia adelante y atrás para formar sub-polígonos separados.

---

## 🛠️ Tecnologías y Requisitos
- **Lenguaje**: C#
- **Framework**: .NET / Windows Forms
- **IDE Recomendado**: Visual Studio 2022

## 📦 Ejecución
Abre la solución `AlgoritmosDeDiscretizacion.sln` o `AlgoritmosDeDiscretizacion.slnx` en Visual Studio y presiona `F5` para compilar y ejecutar el proyecto.
