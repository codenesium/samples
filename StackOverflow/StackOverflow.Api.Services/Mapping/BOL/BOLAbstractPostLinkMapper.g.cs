using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostLinkMapper
	{
		public virtual BOPostLink MapModelToBO(
			int id,
			ApiPostLinkRequestModel model
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

		public virtual ApiPostLinkResponseModel MapBOToModel(
			BOPostLink boPostLink)
		{
			var model = new ApiPostLinkResponseModel();

			model.SetProperties(boPostLink.Id, boPostLink.CreationDate, boPostLink.LinkTypeId, boPostLink.PostId, boPostLink.RelatedPostId);

			return model;
		}

		public virtual List<ApiPostLinkResponseModel> MapBOToModel(
			List<BOPostLink> items)
		{
			List<ApiPostLinkResponseModel> response = new List<ApiPostLinkResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>514f54951ef6ee32f05ba6748a3cb2e4</Hash>
</Codenesium>*/