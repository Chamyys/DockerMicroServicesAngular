FROM node:21 AS build-stage
WORKDIR /app

RUN npm install -g @angular/cli

COPY package*.json ./

RUN npm install

COPY . .

RUN ng build --configuration production

RUN ls -l /app/dist/ClientApp

FROM nginx:alpine AS production-stage
COPY --from=build-stage /app/dist/ClientApp/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
