FROM nginx:latest

# Copy SSL certificates
COPY ssl/nginx.crt /etc/ssl/certs/nginx.crt
COPY ssl/nginx.key /etc/ssl/private/nginx.key

# Copy Nginx configuration file
COPY nginx/nginx.conf /etc/nginx/nginx.conf
