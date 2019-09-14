using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALUnitDispositionMapper : IDALUnitDispositionMapper
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
    <Hash>a01dbe9fd646d3a56a3c6c79814a0004</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/