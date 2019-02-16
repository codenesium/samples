using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALPostLinkMapper
	{
		public virtual PostLink MapModelToEntity(
			int id,
			ApiPostLinkServerRequestModel model
			)
		{
			PostLink item = new PostLink();
			item.SetProperties(
				id,
				model.CreationDate,
				model.LinkTypeId,
				model.PostId,
				model.RelatedPostId);
			return item;
		}

		public virtual ApiPostLinkServerResponseModel MapEntityToModel(
			PostLink item)
		{
			var model = new ApiPostLinkServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CreationDate,
			                    item.LinkTypeId,
			                    item.PostId,
			                    item.RelatedPostId);

			return model;
		}

		public virtual List<ApiPostLinkServerResponseModel> MapEntityToModel(
			List<PostLink> items)
		{
			List<ApiPostLinkServerResponseModel> response = new List<ApiPostLinkServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e7fcfa1fa450690e1aadcf6b8607ce9</Hash>
</Codenesium>*/