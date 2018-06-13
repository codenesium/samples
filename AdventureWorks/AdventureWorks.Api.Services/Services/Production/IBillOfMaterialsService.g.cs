using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBillOfMaterialsService
        {
                Task<CreateResponse<ApiBillOfMaterialsResponseModel>> Create(
                        ApiBillOfMaterialsRequestModel model);

                Task<ActionResponse> Update(int billOfMaterialsID,
                                            ApiBillOfMaterialsRequestModel model);

                Task<ActionResponse> Delete(int billOfMaterialsID);

                Task<ApiBillOfMaterialsResponseModel> Get(int billOfMaterialsID);

                Task<List<ApiBillOfMaterialsResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiBillOfMaterialsResponseModel> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);
                Task<List<ApiBillOfMaterialsResponseModel>> GetUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>398b64770c922fb3735a3610136a28bf</Hash>
</Codenesium>*/