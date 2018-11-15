using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractBadgeMapper
	{
		public virtual BOBadge MapModelToBO(
			int id,
			ApiBadgeServerRequestModel model
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

		public virtual ApiBadgeServerResponseModel MapBOToModel(
			BOBadge boBadge)
		{
			var model = new ApiBadgeServerResponseModel();

			model.SetProperties(boBadge.Id, boBadge.Date, boBadge.Name, boBadge.UserId);

			return model;
		}

		public virtual List<ApiBadgeServerResponseModel> MapBOToModel(
			List<BOBadge> items)
		{
			List<ApiBadgeServerResponseModel> response = new List<ApiBadgeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0cc1e15da7aded3bd172555a9e27b8fc</Hash>
</Codenesium>*/