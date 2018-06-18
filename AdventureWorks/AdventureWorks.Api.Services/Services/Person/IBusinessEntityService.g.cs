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

                Task<List<ApiBusinessEntityResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8884e84e4ee78d82eeebb00b34c9cd41</Hash>
</Codenesium>*/