using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSpecialOfferMapper
	{
		public virtual SpecialOffer MapModelToEntity(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel model
			)
		{
			SpecialOffer item = new SpecialOffer();
			item.SetProperties(
				specialOfferID,
				model.Category,
				model.Description,
				model.DiscountPct,
				model.EndDate,
				model.MaxQty,
				model.MinQty,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate);
			return item;
		}

		public virtual ApiSpecialOfferServerResponseModel MapEntityToModel(
			SpecialOffer item)
		{
			var model = new ApiSpecialOfferServerResponseModel();

			model.SetProperties(item.SpecialOfferID,
			                    item.Category,
			                    item.Description,
			                    item.DiscountPct,
			                    item.EndDate,
			                    item.MaxQty,
			                    item.MinQty,
			                    item.ModifiedDate,
			                    item.Rowguid,
			                    item.StartDate);

			return model;
		}

		public virtual List<ApiSpecialOfferServerResponseModel> MapEntityToModel(
			List<SpecialOffer> items)
		{
			List<ApiSpecialOfferServerResponseModel> response = new List<ApiSpecialOfferServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5beaf3715dc6e76bac285b446c45fd6</Hash>
</Codenesium>*/