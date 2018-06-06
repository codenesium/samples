using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSpecialOfferMapper
	{
		public virtual BOSpecialOffer MapModelToBO(
			int specialOfferID,
			ApiSpecialOfferRequestModel model
			)
		{
			BOSpecialOffer boSpecialOffer = new BOSpecialOffer();

			boSpecialOffer.SetProperties(
				specialOfferID,
				model.Category,
				model.Description,
				model.DiscountPct,
				model.EndDate,
				model.MaxQty,
				model.MinQty,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.Type);
			return boSpecialOffer;
		}

		public virtual ApiSpecialOfferResponseModel MapBOToModel(
			BOSpecialOffer boSpecialOffer)
		{
			var model = new ApiSpecialOfferResponseModel();

			model.SetProperties(boSpecialOffer.Category, boSpecialOffer.Description, boSpecialOffer.DiscountPct, boSpecialOffer.EndDate, boSpecialOffer.MaxQty, boSpecialOffer.MinQty, boSpecialOffer.ModifiedDate, boSpecialOffer.Rowguid, boSpecialOffer.SpecialOfferID, boSpecialOffer.StartDate, boSpecialOffer.Type);

			return model;
		}

		public virtual List<ApiSpecialOfferResponseModel> MapBOToModel(
			List<BOSpecialOffer> items)
		{
			List<ApiSpecialOfferResponseModel> response = new List<ApiSpecialOfferResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aaff5483e737397011cb9c6e77cba584</Hash>
</Codenesium>*/