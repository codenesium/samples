using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

			model.SetProperties(boScrapReason.ModifiedDate, boScrapReason.Name, boScrapReason.ScrapReasonID);

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
    <Hash>f9ee356df5744610943e94eb56036c07</Hash>
</Codenesium>*/