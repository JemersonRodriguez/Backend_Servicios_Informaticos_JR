document.addEventListener('DOMContentLoaded', () => {
    // 1. Obtener el elemento principal (donde se inyectará el texto)
    const tituloAnimado = document.getElementById('titulo-animado');
    const textoPrincipal = document.getElementById('texto-principal');
    
    // 2. Obtener el texto que queremos escribir y resetear el contenido del h1
    const textoCompleto = textoPrincipal.textContent.trim();
    tituloAnimado.textContent = ''; // Limpiamos el texto inicial
    
    let indice = 0;
    
    function teclear() {
        if (indice < textoCompleto.length) {
            // Añade el siguiente carácter al título
            tituloAnimado.textContent += textoCompleto.charAt(indice);
            indice++;
            
            // Llama a la función de nuevo con un pequeño retraso (velocidad de tecleo)
            setTimeout(teclear, 90); // 90 milisegundos por carácter (velocidad media)
        } else {
            // Cuando el tecleo termina, detenemos la animación de parpadeo del cursor
            tituloAnimado.style.borderRight = 'none';
        }
    }

    // Iniciar la animación
    teclear();
});
