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
			BOAddressType boAddressType = new BOAddressType();

			boAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return boAddressType;
		}

		public virtual ApiAddressTypeResponseModel MapBOToModel(
			BOAddressType boAddressType)
		{
			var model = new ApiAddressTypeResponseModel();

			model.SetProperties(boAddressType.AddressTypeID, boAddressType.ModifiedDate, boAddressType.Name, boAddressType.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeResponseModel> MapBOToModel(
			List<BOAddressType> items)
		{
			List<ApiAddressTypeResponseModel> response = new List<ApiAddressTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a67fbb4c06ca4f31692f3aeaa1268704</Hash>
</Codenesium>*/