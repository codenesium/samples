using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALRowVersionCheckMapper : IDALRowVersionCheckMapper
	{
		public virtual RowVersionCheck MapModelToEntity(
			int id,
			ApiRowVersionCheckServerRequestModel model
			)
		{
			RowVersionCheck item = new RowVersionCheck();
			item.SetProperties(
				id,
				model.Name,
				model.RowVersion);
			return item;
		}

		public virtual ApiRowVersionCheckServerResponseModel MapEntityToModel(
			RowVersionCheck item)
		{
			var model = new ApiRowVersionCheckServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.RowVersion);

			return model;
		}

		public virtual List<ApiRowVersionCheckServerResponseModel> MapEntityToModel(
			List<RowVersionCheck> items)
		{
			List<ApiRowVersionCheckServerResponseModel> response = new List<ApiRowVersionCheckServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a5c3294587123655e5d90cacfaeaf469</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/