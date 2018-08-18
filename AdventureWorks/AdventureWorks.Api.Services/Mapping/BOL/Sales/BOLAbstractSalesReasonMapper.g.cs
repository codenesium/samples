using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesReasonMapper
	{
		public virtual BOSalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonRequestModel model
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

		public virtual ApiSalesReasonResponseModel MapBOToModel(
			BOSalesReason boSalesReason)
		{
			var model = new ApiSalesReasonResponseModel();

			model.SetProperties(boSalesReason.SalesReasonID, boSalesReason.ModifiedDate, boSalesReason.Name, boSalesReason.ReasonType);

			return model;
		}

		public virtual List<ApiSalesReasonResponseModel> MapBOToModel(
			List<BOSalesReason> items)
		{
			List<ApiSalesReasonResponseModel> response = new List<ApiSalesReasonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>65004e3bca16c5350bbcad3c4b549b32</Hash>
</Codenesium>*/