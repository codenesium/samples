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

			model.SetProperties(boUnitMeasure.UnitMeasureCode, boUnitMeasure.ModifiedDate, boUnitMeasure.Name);

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
    <Hash>a31e93d695b73cb4520565b1f93926b3</Hash>
</Codenesium>*/