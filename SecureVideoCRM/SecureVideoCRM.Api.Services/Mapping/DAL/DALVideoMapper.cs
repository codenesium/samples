using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace SecureVideoCRMNS.Api.Services
{
	public class DALVideoMapper : IDALVideoMapper
	{
		public virtual Video MapModelToEntity(
			int id,
			ApiVideoServerRequestModel model
			)
		{
			Video item = new Video();
			item.SetProperties(
				id,
				model.Description,
				model.Title,
				model.Url);
			return item;
		}

		public virtual ApiVideoServerResponseModel MapEntityToModel(
			Video item)
		{
			var model = new ApiVideoServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Description,
			                    item.Title,
			                    item.Url);

			return model;
		}

		public virtual List<ApiVideoServerResponseModel> MapEntityToModel(
			List<Video> items)
		{
			List<ApiVideoServerResponseModel> response = new List<ApiVideoServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>62f28105c03c653dc2a01b1aa0e4c19d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/