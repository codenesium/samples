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

                Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiCultureResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>35f1a185c6ad4919d86c1decf958d7a6</Hash>
</Codenesium>*/