using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IFamilyService
        {
                Task<CreateResponse<ApiFamilyResponseModel>> Create(
                        ApiFamilyRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiFamilyRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFamilyResponseModel> Get(int id);

                Task<List<ApiFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>dd4a8b0eb9b7d01c9185727a6edb54f9</Hash>
</Codenesium>*/