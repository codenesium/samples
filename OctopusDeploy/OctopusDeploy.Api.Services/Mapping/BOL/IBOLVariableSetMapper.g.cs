using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>259fd9a08523ae9806a009652fb10a53</Hash>
</Codenesium>*/