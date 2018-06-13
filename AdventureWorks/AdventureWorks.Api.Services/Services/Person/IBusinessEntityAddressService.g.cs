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

                Task<List<ApiBusinessEntityAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressID(int addressID);
                Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressTypeID(int addressTypeID);
        }
}

/*<Codenesium>
    <Hash>c173a89bf7e261c32af0135a81926aac</Hash>
</Codenesium>*/