using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiBillOfMaterialsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiBillOfMaterialsResponseModel> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate);

                Task<List<ApiBillOfMaterialsResponseModel>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>47470f43a38bcb5c1ec9152c16b37797</Hash>
</Codenesium>*/