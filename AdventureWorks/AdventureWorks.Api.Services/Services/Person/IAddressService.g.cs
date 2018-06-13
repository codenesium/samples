using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IAddressService
        {
                Task<CreateResponse<ApiAddressResponseModel>> Create(
                        ApiAddressRequestModel model);

                Task<ActionResponse> Update(int addressID,
                                            ApiAddressRequestModel model);

                Task<ActionResponse> Delete(int addressID);

                Task<ApiAddressResponseModel> Get(int addressID);

                Task<List<ApiAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiAddressResponseModel> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);
                Task<List<ApiAddressResponseModel>> GetStateProvinceID(int stateProvinceID);

                Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>38ff17ead453a7fc9b7562ac390e810b</Hash>
</Codenesium>*/