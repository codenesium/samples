 #!/usr/bin/env bash
 
# double check that the details for how to connect to docker and the service
# fabric cluster are provided; you can set these in the travis ui at
# https://travis-ci.org/your_github_organization/your_repository_name/settings
# the variables SERVICE_FABRIC_NAME and SERVICE_FABRIC_LOCATION should be set
# to the values of $cluster_name and $location created during the initial
# cluster setup described in our earlier article
if [ -z "$DOCKER_USERNAME" ] || [ -z "$DOCKER_PASSWORD" ]; then
  echo "No docker credentials configured" >&2; exit 1
fi
 

# create a new build of the application and publish it to the docker registry so
# that the nodes in the service fabric cluster can find the updated application
# this assumes that the travis build step didn't already create these assets
docker login --username "$DOCKER_USERNAME" --password "$DOCKER_PASSWORD"
docker-compose -f ./ESPIOT/docker-compose-postgres.yml build
docker-compose -f ./ESPIOT/docker-compose-postgres.yml  push
 