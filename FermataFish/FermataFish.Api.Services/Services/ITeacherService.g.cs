using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ITeacherService
        {
                Task<CreateResponse<ApiTeacherResponseModel>> Create(
                        ApiTeacherRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTeacherRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTeacherResponseModel> Get(int id);

                Task<List<ApiTeacherResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>537ce8d492fdce344591af7a72286720</Hash>
</Codenesium>*/