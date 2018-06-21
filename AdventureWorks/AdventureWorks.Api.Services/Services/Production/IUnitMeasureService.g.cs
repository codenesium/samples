using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IUnitMeasureService
        {
                Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
                        ApiUnitMeasureRequestModel model);

                Task<ActionResponse> Update(string unitMeasureCode,
                                            ApiUnitMeasureRequestModel model);

                Task<ActionResponse> Delete(string unitMeasureCode);

                Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode);

                Task<List<ApiUnitMeasureResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiUnitMeasureResponseModel> ByName(string name);

                Task<List<ApiBillOfMaterialsResponseModel>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductResponseModel>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>37bd6fc24406367c265d26013bb06e2b</Hash>
</Codenesium>*/