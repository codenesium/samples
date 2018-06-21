using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IContactTypeService
        {
                Task<CreateResponse<ApiContactTypeResponseModel>> Create(
                        ApiContactTypeRequestModel model);

                Task<ActionResponse> Update(int contactTypeID,
                                            ApiContactTypeRequestModel model);

                Task<ActionResponse> Delete(int contactTypeID);

                Task<ApiContactTypeResponseModel> Get(int contactTypeID);

                Task<List<ApiContactTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiContactTypeResponseModel> ByName(string name);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3cec57fce5289321bae46dae0ec1f5ad</Hash>
</Codenesium>*/