# Build the React application
FROM node:8 AS jsbuild

# The following arguments are passed on the command line of docker-compose with the -e switch

# Used in the React app so it know where the API is. Useful when using a proxy or hosting the API project a different ip than the React app. 
ARG REACT_APP_API_URL
ENV REACT_APP_API_URL="${REACT_APP_API_URL}"
 # Used when the app is not hosted under the root of the domain like http://sitename.com/subdirectory
ARG REACT_APP_HOST_SUBDIRECTORY 
ENV REACT_APP_HOST_SUBDIRECTORY="${REACT_APP_HOST_SUBDIRECTORY}"

# Copy the source code to the container
COPY . ./ 

# Change to the React source code directory
WORKDIR StudioResourceManagerMT.Api.TypeScript/src/react

# Install npm packages
RUN npm install

# Build the React application
RUN npm run build-docker

# Build the API
FROM microsoft/dotnet:2.2-sdk-alpine AS build

WORKDIR /

# expose port 80 in the container to the host
EXPOSE 80

# Copy the source code to the container
COPY . ./

WORKDIR /

# Publish the API as a self contained application targeting Linux
RUN dotnet publish StudioResourceManagerMT.Api.Web/StudioResourceManagerMT.Api.Web.csproj -c Release  -o /publish -r alpine-x64 --self-contained

# Create the runtime containe
FROM microsoft/dotnet:2.2-runtime-deps-alpine AS runtime

WORKDIR /publish
# Copy the output of the API build
COPY --from=build publish .

WORKDIR /publish/app
# Copy the output of the JS build to the app subdirectory 
COPY --from=jsbuild StudioResourceManagerMT.Api.TypeScript/src/react/build .

WORKDIR /publish
ENTRYPOINT ["./StudioResourceManagerMT.Api.Web"]