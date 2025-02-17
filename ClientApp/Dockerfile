# Этап сборки
FROM node:21 AS build-stage
WORKDIR /app

# Устанавливаем Angular CLI глобально
RUN npm install -g @angular/cli

# Копируем package.json и package-lock.json
COPY package*.json ./

# Устанавливаем зависимости
RUN npm install

# Копируем весь проект (исключая dist, если он уже есть)
COPY . .

# Собираем проект
RUN ng build --configuration production

# Проверяем, что файлы собрались
RUN ls -l /app/dist/ClientApp

# Этап production
FROM nginx:alpine AS production-stage
COPY --from=build-stage /app/dist/ClientApp/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
