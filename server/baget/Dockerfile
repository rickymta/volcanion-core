# Arguments
ARG BAGET_VERSION=latest

# Base image for the BaGet server
FROM loicsharma/baget:$BAGET_VERSION

# Copy the BaGet configuration file to the container
ENTRYPOINT ["dotnet", "BaGet.dll"]
