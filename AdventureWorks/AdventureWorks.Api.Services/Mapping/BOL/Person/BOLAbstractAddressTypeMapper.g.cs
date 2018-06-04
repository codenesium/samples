using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAddressTypeMapper
	{
		public virtual BOAddressType MapModelToBO(
			int addressTypeID,
			ApiAddressTypeRequestModel model
			)
		{
			BOAddressType BOAddressType = new BOAddressType();

			BOAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return BOAddressType;
		}

		public virtual ApiAddressTypeResponseModel MapBOToModel(
			BOAddressType BOAddressType)
		{
			if (BOAddressType == null)
			{
				return null;
			}

			var model = new ApiAddressTypeResponseModel();

			model.SetProperties(BOAddressType.AddressTypeID, BOAddressType.ModifiedDate, BOAddressType.Name, BOAddressType.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeResponseModel> MapBOToModel(
			List<BOAddressType> BOs)
		{
			List<ApiAddressTypeResponseModel> response = new List<ApiAddressTypeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>899f4762be2ede490033c985381ca759</Hash>
</Codenesium>*/