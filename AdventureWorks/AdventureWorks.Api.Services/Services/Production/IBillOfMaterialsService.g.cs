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

                Task<ApiBillOfMaterialsResponseModel> ByProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);

                Task<List<ApiBillOfMaterialsResponseModel>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>f5c88f3b7a8673d9ac509654f502be0a</Hash>
</Codenesium>*/