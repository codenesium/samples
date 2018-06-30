using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLUserRoleMapper
        {
                BOUserRole MapModelToBO(
                        string id,
                        ApiUserRoleRequestModel model);

                ApiUserRoleResponseModel MapBOToModel(
                        BOUserRole boUserRole);

                List<ApiUserRoleResponseModel> MapBOToModel(
                        List<BOUserRole> items);
        }
}

/*<Codenesium>
    <Hash>30fd5fbd0b0d371a2ebd0ed9d0d4a074</Hash>
</Codenesium>*/