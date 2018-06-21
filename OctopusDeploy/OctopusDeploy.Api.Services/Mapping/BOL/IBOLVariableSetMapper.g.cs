using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLVariableSetMapper
        {
                BOVariableSet MapModelToBO(
                        string id,
                        ApiVariableSetRequestModel model);

                ApiVariableSetResponseModel MapBOToModel(
                        BOVariableSet boVariableSet);

                List<ApiVariableSetResponseModel> MapBOToModel(
                        List<BOVariableSet> items);
        }
}

/*<Codenesium>
    <Hash>699af527309005f85870388012ba47ee</Hash>
</Codenesium>*/