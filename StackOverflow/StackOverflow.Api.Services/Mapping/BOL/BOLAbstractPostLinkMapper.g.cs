using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostLinkMapper
	{
		public virtual BOPostLink MapModelToBO(
			int id,
			ApiPostLinkServerRequestModel model
			)
		{
			BOPostLink boPostLink = new BOPostLink();
			boPostLink.SetProperties(
				id,
				model.CreationDate,
				model.LinkTypeId,
				model.PostId,
				model.RelatedPostId);
			return boPostLink;
		}

		public virtual ApiPostLinkServerResponseModel MapBOToModel(
			BOPostLink boPostLink)
		{
			var model = new ApiPostLinkServerResponseModel();

			model.SetProperties(boPostLink.Id, boPostLink.CreationDate, boPostLink.LinkTypeId, boPostLink.PostId, boPostLink.RelatedPostId);

			return model;
		}

		public virtual List<ApiPostLinkServerResponseModel> MapBOToModel(
			List<BOPostLink> items)
		{
			List<ApiPostLinkServerResponseModel> response = new List<ApiPostLinkServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f6967ffc7c3f4c1dd834b05eb5fe858d</Hash>
</Codenesium>*/