using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiUnitMeasureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiUnitMeasureResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>1174a574a073da25aa8c203df8886e7d</Hash>
</Codenesium>*/