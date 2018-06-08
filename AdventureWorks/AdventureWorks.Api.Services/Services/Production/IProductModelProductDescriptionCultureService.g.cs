using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductModelProductDescriptionCultureService
        {
                Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
                        ApiProductModelProductDescriptionCultureRequestModel model);

                Task<ActionResponse> Update(int productModelID,
                                            ApiProductModelProductDescriptionCultureRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID);

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f3bf6fa3395e8cd41668c03cf5c87cf7</Hash>
</Codenesium>*/