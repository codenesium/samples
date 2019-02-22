using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALUnitMapper
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
    <Hash>afd38325de4043169d117ec2dceb9bb2</Hash>
</Codenesium>*/