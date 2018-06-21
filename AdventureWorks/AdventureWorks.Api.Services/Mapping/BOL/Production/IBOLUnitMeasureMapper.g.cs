using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>21f398bfc8654c9cbf9efaaab3e72f5e</Hash>
</Codenesium>*/