using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractScrapReasonMapper
	{
		public virtual BOScrapReason MapModelToBO(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel model
			)
		{
			BOScrapReason boScrapReason = new BOScrapReason();
			boScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
			return boScrapReason;
		}

		public virtual ApiScrapReasonServerResponseModel MapBOToModel(
			BOScrapReason boScrapReason)
		{
			var model = new ApiScrapReasonServerResponseModel();

			model.SetProperties(boScrapReason.ScrapReasonID, boScrapReason.ModifiedDate, boScrapReason.Name);

			return model;
		}

		public virtual List<ApiScrapReasonServerResponseModel> MapBOToModel(
			List<BOScrapReason> items)
		{
			List<ApiScrapReasonServerResponseModel> response = new List<ApiScrapReasonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9966d68762595ed9d307796f999952e2</Hash>
</Codenesium>*/