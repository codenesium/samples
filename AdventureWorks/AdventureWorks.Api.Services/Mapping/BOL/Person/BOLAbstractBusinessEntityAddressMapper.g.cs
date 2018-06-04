using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractBusinessEntityAddressMapper
	{
		public virtual BOBusinessEntityAddress MapModelToBO(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model
			)
		{
			BOBusinessEntityAddress BOBusinessEntityAddress = new BOBusinessEntityAddress();

			BOBusinessEntityAddress.SetProperties(
				businessEntityID,
				model.AddressID,
				model.AddressTypeID,
				model.ModifiedDate,
				model.Rowguid);
			return BOBusinessEntityAddress;
		}

		public virtual ApiBusinessEntityAddressResponseModel MapBOToModel(
			BOBusinessEntityAddress BOBusinessEntityAddress)
		{
			if (BOBusinessEntityAddress == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityAddressResponseModel();

			model.SetProperties(BOBusinessEntityAddress.AddressID, BOBusinessEntityAddress.AddressTypeID, BOBusinessEntityAddress.BusinessEntityID, BOBusinessEntityAddress.ModifiedDate, BOBusinessEntityAddress.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityAddressResponseModel> MapBOToModel(
			List<BOBusinessEntityAddress> BOs)
		{
			List<ApiBusinessEntityAddressResponseModel> response = new List<ApiBusinessEntityAddressResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f0e91dbe3c5b13a01484c8040e63bc13</Hash>
</Codenesium>*/