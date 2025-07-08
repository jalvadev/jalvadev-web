# Development

```
docker compose watch
```

# Build

```
docker compose build
```

# Configuration

Es necesario agregar un passwords.txt en la carpeta principal del proyecto. Los appsettings.json y el docker-compose.yml esperan leer ese archivo en esta carpeta.  **[Pendiente de cambiar este sistema]**

# To Do

## Front

- [x] Servicio Http y control errores
- [x] i18n
- [ ] Servicio mensajes
- [ ] Loader
- [ ] Landing
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
