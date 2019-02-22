using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALUnitDispositionMapper
	{
		public virtual UnitDisposition MapModelToEntity(
			int id,
			ApiUnitDispositionServerRequestModel model
			)
		{
			UnitDisposition item = new UnitDisposition();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiUnitDispositionServerResponseModel MapEntityToModel(
			UnitDisposition item)
		{
			var model = new ApiUnitDispositionServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiUnitDispositionServerResponseModel> MapEntityToModel(
			List<UnitDisposition> items)
		{
			List<ApiUnitDispositionServerResponseModel> response = new List<ApiUnitDispositionServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b4961168bdbe5776ea46b5de2f1be720</Hash>
</Codenesium>*/