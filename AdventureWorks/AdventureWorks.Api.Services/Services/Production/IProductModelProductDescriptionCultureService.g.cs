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

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6f5816bb529aea20b4d78a376aea464b</Hash>
</Codenesium>*/