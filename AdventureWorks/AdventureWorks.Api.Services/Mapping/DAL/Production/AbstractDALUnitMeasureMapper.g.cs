using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALUnitMeasureMapper
	{
		public virtual UnitMeasure MapModelToBO(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel model
			)
		{
			UnitMeasure item = new UnitMeasure();
			item.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiUnitMeasureServerResponseModel MapBOToModel(
			UnitMeasure item)
		{
			var model = new ApiUnitMeasureServerResponseModel();

			model.SetProperties(item.UnitMeasureCode, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiUnitMeasureServerResponseModel> MapBOToModel(
			List<UnitMeasure> items)
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
    <Hash>98be6486fd1ee7804b70df804fb98a48</Hash>
</Codenesium>*/