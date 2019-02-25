using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALScrapReasonMapper
	{
		public virtual ScrapReason MapModelToEntity(
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

		public virtual ApiScrapReasonServerResponseModel MapEntityToModel(
			ScrapReason item)
		{
			var model = new ApiScrapReasonServerResponseModel();

			model.SetProperties(item.ScrapReasonID,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiScrapReasonServerResponseModel> MapEntityToModel(
			List<ScrapReason> items)
		{
			List<ApiScrapReasonServerResponseModel> response = new List<ApiScrapReasonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>03cbe3a6c095d651cd3188212be2f28d</Hash>
</Codenesium>*/