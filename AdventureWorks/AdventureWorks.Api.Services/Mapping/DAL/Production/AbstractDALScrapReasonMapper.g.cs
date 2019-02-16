using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALScrapReasonMapper
	{
		public virtual ScrapReason MapModelToBO(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel model
			)
		{
			ScrapReason item = new ScrapReason();
			item.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiScrapReasonServerResponseModel MapBOToModel(
			ScrapReason item)
		{
			var model = new ApiScrapReasonServerResponseModel();

			model.SetProperties(item.ScrapReasonID, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiScrapReasonServerResponseModel> MapBOToModel(
			List<ScrapReason> items)
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
    <Hash>bd7f6050500e9ef1f8370b9d19acf9af</Hash>
</Codenesium>*/