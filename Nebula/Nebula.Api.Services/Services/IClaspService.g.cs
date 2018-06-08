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

                Task<List<ApiClaspResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4f2c74ef9dff70b03b8667f781b531c4</Hash>
</Codenesium>*/