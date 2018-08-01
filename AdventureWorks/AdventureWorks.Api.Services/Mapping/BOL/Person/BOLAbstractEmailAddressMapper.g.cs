using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmailAddressMapper
	{
		public virtual BOEmailAddress MapModelToBO(
			int businessEntityID,
			ApiEmailAddressRequestModel model
			)
		{
			BOEmailAddress boEmailAddress = new BOEmailAddress();
			boEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddress1,
				model.EmailAddressID,
				model.ModifiedDate,
				model.Rowguid);
			return boEmailAddress;
		}

		public virtual ApiEmailAddressResponseModel MapBOToModel(
			BOEmailAddress boEmailAddress)
		{
			var model = new ApiEmailAddressResponseModel();

			model.SetProperties(boEmailAddress.BusinessEntityID, boEmailAddress.EmailAddress1, boEmailAddress.EmailAddressID, boEmailAddress.ModifiedDate, boEmailAddress.Rowguid);

			return model;
		}

		public virtual List<ApiEmailAddressResponseModel> MapBOToModel(
			List<BOEmailAddress> items)
		{
			List<ApiEmailAddressResponseModel> response = new List<ApiEmailAddressResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2527ee4b18aa1b5ecc957337b40c0b93</Hash>
</Codenesium>*/