using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>858ca6a5aece8a313baeca565df2c44d</Hash>
</Codenesium>*/