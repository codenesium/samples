using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALUnitMeasureMapper
	{
		public virtual UnitMeasure MapModelToEntity(
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

		public virtual ApiUnitMeasureServerResponseModel MapEntityToModel(
			UnitMeasure item)
		{
			var model = new ApiUnitMeasureServerResponseModel();

			model.SetProperties(item.UnitMeasureCode,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiUnitMeasureServerResponseModel> MapEntityToModel(
			List<UnitMeasure> items)
		{
			List<ApiUnitMeasureServerResponseModel> response = new List<ApiUnitMeasureServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>660c8e71385afc78df85897d9f44ed47</Hash>
</Codenesium>*/