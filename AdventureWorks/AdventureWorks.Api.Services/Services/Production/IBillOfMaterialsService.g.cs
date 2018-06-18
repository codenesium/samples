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

                Task<List<ApiBillOfMaterialsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiBillOfMaterialsResponseModel> ByProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate);
                Task<List<ApiBillOfMaterialsResponseModel>> ByUnitMeasureCode(string unitMeasureCode);
        }
}

/*<Codenesium>
    <Hash>14bf49c98c1b5b802524b9a21126d453</Hash>
</Codenesium>*/