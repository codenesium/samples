using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractScrapReasonMapper
	{
		public virtual BOScrapReason MapModelToBO(
			short scrapReasonID,
			ApiScrapReasonRequestModel model
			)
		{
			BOScrapReason boScrapReason = new BOScrapReason();
			boScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
			return boScrapReason;
		}

		public virtual ApiScrapReasonResponseModel MapBOToModel(
			BOScrapReason boScrapReason)
		{
			var model = new ApiScrapReasonResponseModel();

			model.SetProperties(boScrapReason.ScrapReasonID, boScrapReason.ModifiedDate, boScrapReason.Name);

			return model;
		}

		public virtual List<ApiScrapReasonResponseModel> MapBOToModel(
			List<BOScrapReason> items)
		{
			List<ApiScrapReasonResponseModel> response = new List<ApiScrapReasonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>265c2a0ea7dd39559afc22e4f0fdcb7b</Hash>
</Codenesium>*/