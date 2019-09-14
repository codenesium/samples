using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALTableMapper : IDALTableMapper
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
    <Hash>0977ad1ef540af5fb6f3279225a58ab0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/