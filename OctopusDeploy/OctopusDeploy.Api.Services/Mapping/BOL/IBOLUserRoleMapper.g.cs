using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>2aad1aea38761e608074b5c4ba5785de</Hash>
</Codenesium>*/