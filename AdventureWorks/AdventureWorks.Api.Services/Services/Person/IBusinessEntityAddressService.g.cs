using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityAddressService
        {
                Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
                        ApiBusinessEntityAddressRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiBusinessEntityAddressRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressID(int addressID);
                Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressTypeID(int addressTypeID);
        }
}

/*<Codenesium>
    <Hash>7d278ae140679ecb7da7a991424143d4</Hash>
</Codenesium>*/