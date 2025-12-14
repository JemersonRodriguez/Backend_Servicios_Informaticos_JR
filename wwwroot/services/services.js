const post = "POST";

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById("contactForm");

    if (!form) {
        console.warn("Formulario 'contactForm' no encontrado.");
        return;
    }

    form.addEventListener("submit", async (e) => {
        console.log("¡Entré en la función de envío!");

        e.preventDefault();

        const formData = new FormData(form);

        try {
            const response = await fetch("/LandingPage/EnviarCorreo", {
                method: post,
                body: formData
            });

            if (!response.ok) {
                let errorData = await response.json().catch(() => ({ Mensaje: "Error de servidor desconocido." }));
                throw new Error(errorData.Mensaje || "Error HTTP no exitoso.");
            }

            const responseData = await response.json();

            if (responseData.exito) {
                Toastify({
                    text: `✅ ${responseData.Mensaje || "Mensaje enviado correctamente."}`,
                    duration: 3500,
                    close: true,
                    gravity: "top",
                    position: "right",
                    stopOnFocus: true,
                    style: {
                        background: "linear-gradient(to right, #0d6dfc, #182857)",
                        color: "#ffffff",
                        borderRadius: "8px"
                    }
                }).showToast();

                form.reset();
            } else {
                // Si la respuesta HTTP fue OK, pero la lógica de negocio falló
                Toastify({
                    text: `⚠️ ${responseData.Mensaje || "Error al procesar el mensaje."}`,
                    duration: 5000,
                    close: true,
                    gravity: "top",
                    position: "right",
                    style: {
                        background: "linear-gradient(to right, #ffcc00, #182857)",
                        color: "#ffffff",
                        borderRadius: "8px"
                    }
                }).showToast();
            }

        } catch (err) {
            console.error("Error en la petición o procesamiento:", err);

            Toastify({
                text: `❌ Error: ${err.message || "No pudimos enviar el mensaje. Intente de nuevo."}`,
                duration: 5000,
                close: true,
                gravity: "top",
                position: "right",
                style: {
                    background: "linear-gradient(to right, #dc3545, #182857)",
                    color: "#ffffff",
                    borderRadius: "8px"
                }
            }).showToast();
        }
    });
});

