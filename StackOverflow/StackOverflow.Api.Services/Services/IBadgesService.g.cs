using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IBadgesService
        {
                Task<CreateResponse<ApiBadgesResponseModel>> Create(
                        ApiBadgesRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiBadgesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiBadgesResponseModel> Get(int id);

                Task<List<ApiBadgesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9f130bf064540ccc5bfd3441a5779c47</Hash>
</Codenesium>*/