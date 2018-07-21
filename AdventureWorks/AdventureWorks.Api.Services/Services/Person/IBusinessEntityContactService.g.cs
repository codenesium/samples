using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityContactService
        {
                Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
                        ApiBusinessEntityContactRequestModel model);

                Task<UpdateResponse<ApiBusinessEntityContactResponseModel>> Update(int businessEntityID,
                                                                                    ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID);

                Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>d7b6aaf55b178d543b194994bb255a8f</Hash>
</Codenesium>*/