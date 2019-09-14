using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALUnitMapper : IDALUnitMapper
	{
		public virtual Unit MapModelToEntity(
			int id,
			ApiUnitServerRequestModel model
			)
		{
			Unit item = new Unit();
			item.SetProperties(
				id,
				model.CallSign);
			return item;
		}

		public virtual ApiUnitServerResponseModel MapEntityToModel(
			Unit item)
		{
			var model = new ApiUnitServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CallSign);

			return model;
		}

		public virtual List<ApiUnitServerResponseModel> MapEntityToModel(
			List<Unit> items)
		{
			List<ApiUnitServerResponseModel> response = new List<ApiUnitServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>015fd51845bbc4fb8e68aa1be40c5ea9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/