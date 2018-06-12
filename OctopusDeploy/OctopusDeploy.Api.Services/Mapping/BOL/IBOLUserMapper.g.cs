using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLUserMapper
        {
                BOUser MapModelToBO(
                        string id,
                        ApiUserRequestModel model);

                ApiUserResponseModel MapBOToModel(
                        BOUser boUser);

                List<ApiUserResponseModel> MapBOToModel(
                        List<BOUser> items);
        }
}

/*<Codenesium>
    <Hash>8ba010bc52abdb1c48dbcc4c4814a9e0</Hash>
</Codenesium>*/