using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALTableMapper
	{
		public virtual Table MapModelToEntity(
			int id,
			ApiTableServerRequestModel model
			)
		{
			Table item = new Table();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTableServerResponseModel MapEntityToModel(
			Table item)
		{
			var model = new ApiTableServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTableServerResponseModel> MapEntityToModel(
			List<Table> items)
		{
			List<ApiTableServerResponseModel> response = new List<ApiTableServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2a8520f4276ab91a44fd5e4f1e0804c8</Hash>
</Codenesium>*/