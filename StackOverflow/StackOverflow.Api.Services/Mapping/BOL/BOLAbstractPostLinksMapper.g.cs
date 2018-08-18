using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostLinksMapper
	{
		public virtual BOPostLinks MapModelToBO(
			int id,
			ApiPostLinksRequestModel model
			)
		{
			BOPostLinks boPostLinks = new BOPostLinks();
			boPostLinks.SetProperties(
				id,
				model.CreationDate,
				model.LinkTypeId,
				model.PostId,
				model.RelatedPostId);
			return boPostLinks;
		}

		public virtual ApiPostLinksResponseModel MapBOToModel(
			BOPostLinks boPostLinks)
		{
			var model = new ApiPostLinksResponseModel();

			model.SetProperties(boPostLinks.Id, boPostLinks.CreationDate, boPostLinks.LinkTypeId, boPostLinks.PostId, boPostLinks.RelatedPostId);

			return model;
		}

		public virtual List<ApiPostLinksResponseModel> MapBOToModel(
			List<BOPostLinks> items)
		{
			List<ApiPostLinksResponseModel> response = new List<ApiPostLinksResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>44c32e2f1037eef3811b60b16557eeaf</Hash>
</Codenesium>*/