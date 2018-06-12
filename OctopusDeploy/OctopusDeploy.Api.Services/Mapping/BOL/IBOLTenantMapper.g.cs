using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLTenantMapper
        {
                BOTenant MapModelToBO(
                        string id,
                        ApiTenantRequestModel model);

                ApiTenantResponseModel MapBOToModel(
                        BOTenant boTenant);

                List<ApiTenantResponseModel> MapBOToModel(
                        List<BOTenant> items);
        }
}

/*<Codenesium>
    <Hash>dc6a74973f0bc5e5d89ff2316eee2f03</Hash>
</Codenesium>*/