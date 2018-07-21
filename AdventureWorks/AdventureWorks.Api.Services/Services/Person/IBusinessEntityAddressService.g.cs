using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityAddressService
        {
                Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
                        ApiBusinessEntityAddressRequestModel model);

                Task<UpdateResponse<ApiBusinessEntityAddressResponseModel>> Update(int businessEntityID,
                                                                                    ApiBusinessEntityAddressRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressID(int addressID);

                Task<List<ApiBusinessEntityAddressResponseModel>> ByAddressTypeID(int addressTypeID);
        }
}

/*<Codenesium>
    <Hash>7b836a7b2913de3289d72b44b836eef6</Hash>
</Codenesium>*/