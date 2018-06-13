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

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>85546d6abdbede3ad1b26666c7b13e89</Hash>
</Codenesium>*/