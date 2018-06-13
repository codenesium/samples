using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ICultureService
        {
                Task<CreateResponse<ApiCultureResponseModel>> Create(
                        ApiCultureRequestModel model);

                Task<ActionResponse> Update(string cultureID,
                                            ApiCultureRequestModel model);

                Task<ActionResponse> Delete(string cultureID);

                Task<ApiCultureResponseModel> Get(string cultureID);

                Task<List<ApiCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCultureResponseModel> GetName(string name);

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f06c7dc98366f9a35c6f8be527450257</Hash>
</Codenesium>*/