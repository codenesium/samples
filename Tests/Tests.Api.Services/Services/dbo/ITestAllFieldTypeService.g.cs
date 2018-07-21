using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface ITestAllFieldTypeService
        {
                Task<CreateResponse<ApiTestAllFieldTypeResponseModel>> Create(
                        ApiTestAllFieldTypeRequestModel model);

                Task<UpdateResponse<ApiTestAllFieldTypeResponseModel>> Update(int id,
                                                                               ApiTestAllFieldTypeRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTestAllFieldTypeResponseModel> Get(int id);

                Task<List<ApiTestAllFieldTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9e16e1436ca51aeaeeec71dd273b9e54</Hash>
</Codenesium>*/