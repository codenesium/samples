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
			BOSpecialOffer BOSpecialOffer = new BOSpecialOffer();

			BOSpecialOffer.SetProperties(
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
			return BOSpecialOffer;
		}

		public virtual ApiSpecialOfferResponseModel MapBOToModel(
			BOSpecialOffer BOSpecialOffer)
		{
			if (BOSpecialOffer == null)
			{
				return null;
			}

			var model = new ApiSpecialOfferResponseModel();

			model.SetProperties(BOSpecialOffer.Category, BOSpecialOffer.Description, BOSpecialOffer.DiscountPct, BOSpecialOffer.EndDate, BOSpecialOffer.MaxQty, BOSpecialOffer.MinQty, BOSpecialOffer.ModifiedDate, BOSpecialOffer.Rowguid, BOSpecialOffer.SpecialOfferID, BOSpecialOffer.StartDate, BOSpecialOffer.Type);

			return model;
		}

		public virtual List<ApiSpecialOfferResponseModel> MapBOToModel(
			List<BOSpecialOffer> BOs)
		{
			List<ApiSpecialOfferResponseModel> response = new List<ApiSpecialOfferResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d5c836b924d4074f8e8fb5eaaf5278c4</Hash>
</Codenesium>*/