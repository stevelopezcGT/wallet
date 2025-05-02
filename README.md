## 🧠 Preguntas Clave

### 1. 🚀 Escalabilidad

- Uso de **colas de mensajes** como RabbitMQ para manejar operaciones intensivas sin bloquear el sistema.
- **Particionamiento de datos por usuario** para distribuir la carga entre distintas bases de datos o nodos.
- **Cacheo con Redis** para lecturas frecuentes como el saldo de una billetera o historial reciente.

---

### 2. ✅ Idempotencia

- Se implementan **identificadores únicos por solicitud**, lo que permite detectar y evitar operaciones duplicadas.
- Validación de duplicados antes de realizar operaciones críticas como transferencias.
- Diseño de operaciones **POST seguras y controladas**, evitando efectos colaterales por reintentos.

---

### 3. 🛡️ Seguridad

- **SQL Injection**: Se evita utilizando Entity Framework con parámetros tipados en lugar de concatenación de strings.
- **DoS (Denegación de Servicio)**: Se puede implementar rate limiting por IP o usuario.
- **CSRF**: Aunque es más relevante en aplicaciones con frontend web, si se expone vía navegador se puede proteger con tokens anti-CSRF.

---

### 4. 🧩 Estrategia para Migrar un Monolito a Microservicios

- Extraer funcionalidades por **Bounded Contexts/Dominios** (por ejemplo, Billeteras, Transacciones).
- Usar **eventos y mensajería asincrónica** para desacoplar servicios.
- Dividir el proceso en **fases pequeñas y manejables**, evitando el enfoque "Big Bang".
- Adoptar patrones como **Database per Service** y **API Gateway**.

---

### 5. 🌐 Alternativas Escalables

- Uso de **arquitectura Serverless** con funciones en Azure Functions o AWS Lambda.
- Implementación de **CQRS y Event Sourcing** para separar lectura/escritura y mantener trazabilidad.
- Uso de **bases de datos NoSQL** (como DynamoDB o MongoDB) para mejorar el rendimiento en consultas específicas.
