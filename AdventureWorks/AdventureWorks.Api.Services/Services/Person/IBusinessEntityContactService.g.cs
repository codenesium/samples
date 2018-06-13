using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityContactService
        {
                Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
                        ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiBusinessEntityContactResponseModel>> GetContactTypeID(int contactTypeID);
                Task<List<ApiBusinessEntityContactResponseModel>> GetPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>2f7dc9c8e891070a8cf108feded3d32b</Hash>
</Codenesium>*/