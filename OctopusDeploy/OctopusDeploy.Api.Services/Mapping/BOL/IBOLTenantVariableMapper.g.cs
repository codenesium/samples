using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9102703db80f00ee0e8668bf98f6d251</Hash>
</Codenesium>*/