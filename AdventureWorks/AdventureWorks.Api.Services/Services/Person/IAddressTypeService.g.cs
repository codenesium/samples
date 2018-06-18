using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IAddressTypeService
        {
                Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
                        ApiAddressTypeRequestModel model);

                Task<ActionResponse> Update(int addressTypeID,
                                            ApiAddressTypeRequestModel model);

                Task<ActionResponse> Delete(int addressTypeID);

                Task<ApiAddressTypeResponseModel> Get(int addressTypeID);

                Task<List<ApiAddressTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiAddressTypeResponseModel> ByName(string name);

                Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>619d4493c9a5e27000cc9852420283e0</Hash>
</Codenesium>*/