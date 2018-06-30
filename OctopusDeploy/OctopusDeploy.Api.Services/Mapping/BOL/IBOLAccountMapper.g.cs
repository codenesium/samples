using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLAccountMapper
        {
                BOAccount MapModelToBO(
                        string id,
                        ApiAccountRequestModel model);

                ApiAccountResponseModel MapBOToModel(
                        BOAccount boAccount);

                List<ApiAccountResponseModel> MapBOToModel(
                        List<BOAccount> items);
        }
}

/*<Codenesium>
    <Hash>485745e12d8dfe30d46934e226e26b11</Hash>
</Codenesium>*/