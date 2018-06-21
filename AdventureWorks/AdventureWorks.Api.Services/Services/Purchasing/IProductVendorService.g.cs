using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>34082cffc412fc7a75b4e68c3a9f5c2d</Hash>
</Codenesium>*/