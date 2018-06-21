using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IOrganizationService
        {
                Task<CreateResponse<ApiOrganizationResponseModel>> Create(
                        ApiOrganizationRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiOrganizationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiOrganizationResponseModel> Get(int id);

                Task<List<ApiOrganizationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTeamResponseModel>> Teams(int organizationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7f3e9106fb9ce9bd3328ff7b485b1267</Hash>
</Codenesium>*/