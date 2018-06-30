using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLSchemaVersionsMapper
        {
                BOSchemaVersions MapModelToBO(
                        int id,
                        ApiSchemaVersionsRequestModel model);

                ApiSchemaVersionsResponseModel MapBOToModel(
                        BOSchemaVersions boSchemaVersions);

                List<ApiSchemaVersionsResponseModel> MapBOToModel(
                        List<BOSchemaVersions> items);
        }
}

/*<Codenesium>
    <Hash>5b6f7318f5e38f6b6928f92e33cf97f5</Hash>
</Codenesium>*/