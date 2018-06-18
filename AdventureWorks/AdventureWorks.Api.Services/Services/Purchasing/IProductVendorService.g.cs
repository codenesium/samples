using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductVendorService
        {
                Task<CreateResponse<ApiProductVendorResponseModel>> Create(
                        ApiProductVendorRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductVendorRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductVendorResponseModel> Get(int productID);

                Task<List<ApiProductVendorResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductVendorResponseModel>> ByBusinessEntityID(int businessEntityID);
                Task<List<ApiProductVendorResponseModel>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>8052be84f37ac9e6fb0c4920019592ca</Hash>
</Codenesium>*/