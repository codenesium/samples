using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLTagSetMapper
        {
                BOTagSet MapModelToBO(
                        string id,
                        ApiTagSetRequestModel model);

                ApiTagSetResponseModel MapBOToModel(
                        BOTagSet boTagSet);

                List<ApiTagSetResponseModel> MapBOToModel(
                        List<BOTagSet> items);
        }
}

/*<Codenesium>
    <Hash>d389a13a608607f6b7abfb8e21838f8c</Hash>
</Codenesium>*/