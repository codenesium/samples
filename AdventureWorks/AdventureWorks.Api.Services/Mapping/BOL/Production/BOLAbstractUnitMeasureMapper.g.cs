using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractUnitMeasureMapper
        {
                public virtual BOUnitMeasure MapModelToBO(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel model
                        )
                {
                        BOUnitMeasure boUnitMeasure = new BOUnitMeasure();
                        boUnitMeasure.SetProperties(
                                unitMeasureCode,
                                model.ModifiedDate,
                                model.Name);
                        return boUnitMeasure;
                }

                public virtual ApiUnitMeasureResponseModel MapBOToModel(
                        BOUnitMeasure boUnitMeasure)
                {
                        var model = new ApiUnitMeasureResponseModel();

                        model.SetProperties(boUnitMeasure.ModifiedDate, boUnitMeasure.Name, boUnitMeasure.UnitMeasureCode);

                        return model;
                }

                public virtual List<ApiUnitMeasureResponseModel> MapBOToModel(
                        List<BOUnitMeasure> items)
                {
                        List<ApiUnitMeasureResponseModel> response = new List<ApiUnitMeasureResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>bd62471ea5d17f9f2cd81a62b92d85ca</Hash>
</Codenesium>*/