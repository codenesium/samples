using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>16eae1f6ebe542edff28f4ee7768889b</Hash>
</Codenesium>*/