# Development

```
docker compose watch
```

# Build

```
docker compose build
```

# Configuration

Es necesario almacenar la contraseña de la DB en un fichero, actualmente un password.txt en desarrollo no trackeado en el git. Este fichero se va a usar como secret en docker compose, pero tambien tendremos que configurar la ruta física en appsettings.Development.json si queremos lanzar la aplicación en debug.

Para producción es obligatorio y se espera tener un .env ya preparado de primera hora en el servidor y no trackeado en el git, que tenga las siguientes variables:

- DOTNET_ENVIRONMENT: El environment donde se va a ejecutar la API, si no le pasamos nada se ejecuta en Staging. En producción espera Production.
- DB_VOLUME_PATH: La ruta donde tendremos el volume para persistir los datos de la base de datos.
- DB_PASSWORD_FILE: La ruta donde tendremos el fichero con nuestra contraseña de la base de datos para el secret. Si no le pasamos nada espera encontrar un ./passwords.txt.

# To Do

## Front

- [x] Servicio Http y control errores
- [x] i18n
- [x] Servicio mensajes
- [ ] Loader
- [x] Landing
  - [ ] Cargar datos usuario
  - [ ] Carga de proyectos
  - [ ] Carga de últimos 5 posts
- [ ] Paginación de posts
- [ ] Filtros paginación de posts
- [ ] Detalle post

## Back v2

- [ ] Login endpoint
- [ ] Authorization
- [ ] PUT perfil
- [ ] POST post
- [ ] PUT post
- [ ] DELETE post
- [ ] POST tag
- [ ] PUT tag
- [ ] DELETE tag
