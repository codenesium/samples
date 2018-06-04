using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractUnitMeasureMapper
	{
		public virtual BOUnitMeasure MapModelToBO(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model
			)
		{
			BOUnitMeasure BOUnitMeasure = new BOUnitMeasure();

			BOUnitMeasure.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
			return BOUnitMeasure;
		}

		public virtual ApiUnitMeasureResponseModel MapBOToModel(
			BOUnitMeasure BOUnitMeasure)
		{
			if (BOUnitMeasure == null)
			{
				return null;
			}

			var model = new ApiUnitMeasureResponseModel();

			model.SetProperties(BOUnitMeasure.ModifiedDate, BOUnitMeasure.Name, BOUnitMeasure.UnitMeasureCode);

			return model;
		}

		public virtual List<ApiUnitMeasureResponseModel> MapBOToModel(
			List<BOUnitMeasure> BOs)
		{
			List<ApiUnitMeasureResponseModel> response = new List<ApiUnitMeasureResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de2b71e59668368d3acab57808effcca</Hash>
</Codenesium>*/