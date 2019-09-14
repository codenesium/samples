using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALLinkTypeMapper : IDALLinkTypeMapper
	{
		public virtual LinkType MapModelToEntity(
			int id,
			ApiLinkTypeServerRequestModel model
			)
		{
			LinkType item = new LinkType();
			item.SetProperties(
				id,
				model.RwType);
			return item;
		}

		public virtual ApiLinkTypeServerResponseModel MapEntityToModel(
			LinkType item)
		{
			var model = new ApiLinkTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.RwType);

			return model;
		}

		public virtual List<ApiLinkTypeServerResponseModel> MapEntityToModel(
			List<LinkType> items)
		{
			List<ApiLinkTypeServerResponseModel> response = new List<ApiLinkTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f2df8e68a109db32a5e3fd4b2260f1d3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/