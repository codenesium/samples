using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALPostTypeMapper : IDALPostTypeMapper
	{
		public virtual PostType MapModelToEntity(
			int id,
			ApiPostTypeServerRequestModel model
			)
		{
			PostType item = new PostType();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiPostTypeServerResponseModel MapEntityToModel(
			PostType item)
		{
			var model = new ApiPostTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiPostTypeServerResponseModel> MapEntityToModel(
			List<PostType> items)
		{
			List<ApiPostTypeServerResponseModel> response = new List<ApiPostTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a21b7e6d71756a6e668986fdf14c7f6a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/