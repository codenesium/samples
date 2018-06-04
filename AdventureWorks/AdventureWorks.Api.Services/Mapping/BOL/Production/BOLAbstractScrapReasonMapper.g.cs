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
			BOScrapReason BOScrapReason = new BOScrapReason();

			BOScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
			return BOScrapReason;
		}

		public virtual ApiScrapReasonResponseModel MapBOToModel(
			BOScrapReason BOScrapReason)
		{
			if (BOScrapReason == null)
			{
				return null;
			}

			var model = new ApiScrapReasonResponseModel();

			model.SetProperties(BOScrapReason.ModifiedDate, BOScrapReason.Name, BOScrapReason.ScrapReasonID);

			return model;
		}

		public virtual List<ApiScrapReasonResponseModel> MapBOToModel(
			List<BOScrapReason> BOs)
		{
			List<ApiScrapReasonResponseModel> response = new List<ApiScrapReasonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5366a9471baed634a57aa79a819a48c</Hash>
</Codenesium>*/