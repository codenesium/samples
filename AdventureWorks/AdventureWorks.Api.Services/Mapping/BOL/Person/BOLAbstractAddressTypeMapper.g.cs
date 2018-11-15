using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAddressTypeMapper
	{
		public virtual BOAddressType MapModelToBO(
			int addressTypeID,
			ApiAddressTypeServerRequestModel model
			)
		{
			BOAddressType boAddressType = new BOAddressType();
			boAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boAddressType;
		}

		public virtual ApiAddressTypeServerResponseModel MapBOToModel(
			BOAddressType boAddressType)
		{
			var model = new ApiAddressTypeServerResponseModel();

			model.SetProperties(boAddressType.AddressTypeID, boAddressType.ModifiedDate, boAddressType.Name, boAddressType.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeServerResponseModel> MapBOToModel(
			List<BOAddressType> items)
		{
			List<ApiAddressTypeServerResponseModel> response = new List<ApiAddressTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e89a69bd3bc2707273c133553fbe60c2</Hash>
</Codenesium>*/