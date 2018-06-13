using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IClaspService
        {
                Task<CreateResponse<ApiClaspResponseModel>> Create(
                        ApiClaspRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiClaspRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiClaspResponseModel> Get(int id);

                Task<List<ApiClaspResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8318e977da31b308660d125cc24d8212</Hash>
</Codenesium>*/