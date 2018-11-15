using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesReasonMapper
	{
		public virtual BOSalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonServerRequestModel model
			)
		{
			BOSalesReason boSalesReason = new BOSalesReason();
			boSalesReason.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
			return boSalesReason;
		}

		public virtual ApiSalesReasonServerResponseModel MapBOToModel(
			BOSalesReason boSalesReason)
		{
			var model = new ApiSalesReasonServerResponseModel();

			model.SetProperties(boSalesReason.SalesReasonID, boSalesReason.ModifiedDate, boSalesReason.Name, boSalesReason.ReasonType);

			return model;
		}

		public virtual List<ApiSalesReasonServerResponseModel> MapBOToModel(
			List<BOSalesReason> items)
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
    <Hash>f41e39298ae4a5c084e8f0b9d04562b8</Hash>
</Codenesium>*/