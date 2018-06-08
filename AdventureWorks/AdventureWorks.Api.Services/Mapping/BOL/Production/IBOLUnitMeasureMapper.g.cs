using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLUnitMeasureMapper
        {
                BOUnitMeasure MapModelToBO(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel model);

                ApiUnitMeasureResponseModel MapBOToModel(
                        BOUnitMeasure boUnitMeasure);

                List<ApiUnitMeasureResponseModel> MapBOToModel(
                        List<BOUnitMeasure> items);
        }
}

/*<Codenesium>
    <Hash>c3dd2162f90a0cf51daee61e439be777</Hash>
</Codenesium>*/