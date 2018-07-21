using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface ILinkTypesService
        {
                Task<CreateResponse<ApiLinkTypesResponseModel>> Create(
                        ApiLinkTypesRequestModel model);

                Task<UpdateResponse<ApiLinkTypesResponseModel>> Update(int id,
                                                                        ApiLinkTypesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkTypesResponseModel> Get(int id);

                Task<List<ApiLinkTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ab4981570bca59d42218324776a66c4d</Hash>
</Codenesium>*/