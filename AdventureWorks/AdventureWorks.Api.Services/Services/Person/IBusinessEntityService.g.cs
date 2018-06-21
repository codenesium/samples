using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fde5b1092e1798a5dc6d2d6d12fa7bc3</Hash>
</Codenesium>*/