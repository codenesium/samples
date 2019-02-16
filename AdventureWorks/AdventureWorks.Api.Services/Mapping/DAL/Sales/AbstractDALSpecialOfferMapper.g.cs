using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSpecialOfferMapper
	{
		public virtual SpecialOffer MapModelToBO(
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

		public virtual ApiSpecialOfferServerResponseModel MapBOToModel(
			SpecialOffer item)
		{
			var model = new ApiSpecialOfferServerResponseModel();

			model.SetProperties(item.SpecialOfferID, item.Category, item.Description, item.DiscountPct, item.EndDate, item.MaxQty, item.MinQty, item.ModifiedDate, item.Rowguid, item.StartDate);

			return model;
		}

		public virtual List<ApiSpecialOfferServerResponseModel> MapBOToModel(
			List<SpecialOffer> items)
		{
			List<ApiSpecialOfferServerResponseModel> response = new List<ApiSpecialOfferServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5b54f45031f5708faeddec74c0c1d3a3</Hash>
</Codenesium>*/