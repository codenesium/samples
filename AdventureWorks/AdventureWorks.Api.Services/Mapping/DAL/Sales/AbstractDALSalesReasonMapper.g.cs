using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesReasonMapper
	{
		public virtual SalesReason MapModelToBO(
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

		public virtual ApiSalesReasonServerResponseModel MapBOToModel(
			SalesReason item)
		{
			var model = new ApiSalesReasonServerResponseModel();

			model.SetProperties(item.SalesReasonID, item.ModifiedDate, item.Name, item.ReasonType);

			return model;
		}

		public virtual List<ApiSalesReasonServerResponseModel> MapBOToModel(
			List<SalesReason> items)
		{
			List<ApiSalesReasonServerResponseModel> response = new List<ApiSalesReasonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4d5dbeee024a2a7624d862ec863c4b2d</Hash>
</Codenesium>*/