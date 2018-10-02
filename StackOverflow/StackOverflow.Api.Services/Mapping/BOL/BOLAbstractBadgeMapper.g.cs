using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractBadgeMapper
	{
		public virtual BOBadge MapModelToBO(
			int id,
			ApiBadgeRequestModel model
			)
		{
			BOBadge boBadge = new BOBadge();
			boBadge.SetProperties(
				id,
				model.Date,
				model.Name,
				model.UserId);
			return boBadge;
		}

		public virtual ApiBadgeResponseModel MapBOToModel(
			BOBadge boBadge)
		{
			var model = new ApiBadgeResponseModel();

			model.SetProperties(boBadge.Id, boBadge.Date, boBadge.Name, boBadge.UserId);

			return model;
		}

		public virtual List<ApiBadgeResponseModel> MapBOToModel(
			List<BOBadge> items)
		{
			List<ApiBadgeResponseModel> response = new List<ApiBadgeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b7802fb1973607909340dd3a43a9b9fd</Hash>
</Codenesium>*/