using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9c42de99fcb68f120ce21aabd0048722</Hash>
</Codenesium>*/