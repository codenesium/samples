using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesReasonMapper
	{
		public virtual SalesReason MapModelToEntity(
			int salesReasonID,
			ApiSalesReasonServerRequestModel model
			)
		{
			SalesReason item = new SalesReason();
			item.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
			return item;
		}

		public virtual ApiSalesReasonServerResponseModel MapEntityToModel(
			SalesReason item)
		{
			var model = new ApiSalesReasonServerResponseModel();

			model.SetProperties(item.SalesReasonID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.ReasonType);

			return model;
		}

		public virtual List<ApiSalesReasonServerResponseModel> MapEntityToModel(
			List<SalesReason> items)
		{
			List<ApiSalesReasonServerResponseModel> response = new List<ApiSalesReasonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3fbd3ff0211d42475a25cd8a689a566e</Hash>
</Codenesium>*/