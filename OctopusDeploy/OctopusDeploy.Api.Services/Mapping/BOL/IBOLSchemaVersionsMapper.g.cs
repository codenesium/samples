using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>6c7cee7d308f0a37fdbbbc9e098bf3a4</Hash>
</Codenesium>*/