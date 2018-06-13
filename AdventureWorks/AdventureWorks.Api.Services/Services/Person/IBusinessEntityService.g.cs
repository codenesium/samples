using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityService
        {
                Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
                        ApiBusinessEntityRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiBusinessEntityRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>561319336813b74fd14ddc1edf81c96f</Hash>
</Codenesium>*/