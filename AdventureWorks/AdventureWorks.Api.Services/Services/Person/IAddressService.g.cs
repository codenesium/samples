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

                Task<List<ApiAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiAddressResponseModel> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);
                Task<List<ApiAddressResponseModel>> GetStateProvinceID(int stateProvinceID);
        }
}

/*<Codenesium>
    <Hash>2533b371821fede4e98b711739420578</Hash>
</Codenesium>*/