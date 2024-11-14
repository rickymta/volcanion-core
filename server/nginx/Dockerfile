# Arguments
ARG NGINX_VERSION=latest

# Base image
FROM nginx:$NGINX_VERSION

# Copy the nginx configuration file to the container
COPY config/nginx.conf /etc/nginx/nginx.conf

# Copy the certificates to the container
COPY certs /etc/nginx/certs
