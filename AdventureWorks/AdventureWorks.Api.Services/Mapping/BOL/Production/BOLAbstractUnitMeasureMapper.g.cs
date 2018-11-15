using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractUnitMeasureMapper
	{
		public virtual BOUnitMeasure MapModelToBO(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel model
			)
		{
			BOUnitMeasure boUnitMeasure = new BOUnitMeasure();
			boUnitMeasure.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
			return boUnitMeasure;
		}

		public virtual ApiUnitMeasureServerResponseModel MapBOToModel(
			BOUnitMeasure boUnitMeasure)
		{
			var model = new ApiUnitMeasureServerResponseModel();

			model.SetProperties(boUnitMeasure.UnitMeasureCode, boUnitMeasure.ModifiedDate, boUnitMeasure.Name);

			return model;
		}

		public virtual List<ApiUnitMeasureServerResponseModel> MapBOToModel(
			List<BOUnitMeasure> items)
		{
			List<ApiUnitMeasureServerResponseModel> response = new List<ApiUnitMeasureServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6e97e671ceac68ea0d9e7c3b97982c55</Hash>
</Codenesium>*/