using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmailAddressMapper
	{
		public virtual BOEmailAddress MapModelToBO(
			int businessEntityID,
			ApiEmailAddressRequestModel model
			)
		{
			BOEmailAddress BOEmailAddress = new BOEmailAddress();

			BOEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddress1,
				model.EmailAddressID,
				model.ModifiedDate,
				model.Rowguid);
			return BOEmailAddress;
		}

		public virtual ApiEmailAddressResponseModel MapBOToModel(
			BOEmailAddress BOEmailAddress)
		{
			if (BOEmailAddress == null)
			{
				return null;
			}

			var model = new ApiEmailAddressResponseModel();

			model.SetProperties(BOEmailAddress.BusinessEntityID, BOEmailAddress.EmailAddress1, BOEmailAddress.EmailAddressID, BOEmailAddress.ModifiedDate, BOEmailAddress.Rowguid);

			return model;
		}

		public virtual List<ApiEmailAddressResponseModel> MapBOToModel(
			List<BOEmailAddress> BOs)
		{
			List<ApiEmailAddressResponseModel> response = new List<ApiEmailAddressResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>396473c4aff1ef408d49d2b5cfb97ea5</Hash>
</Codenesium>*/