using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLTenantVariableMapper
        {
                BOTenantVariable MapModelToBO(
                        string id,
                        ApiTenantVariableRequestModel model);

                ApiTenantVariableResponseModel MapBOToModel(
                        BOTenantVariable boTenantVariable);

                List<ApiTenantVariableResponseModel> MapBOToModel(
                        List<BOTenantVariable> items);
        }
}

/*<Codenesium>
    <Hash>779795c893df2b7053dc856fc3e9fb80</Hash>
</Codenesium>*/