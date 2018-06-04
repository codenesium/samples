using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesOrderHeaderSalesReasonMapper
	{
		public virtual BOSalesOrderHeaderSalesReason MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model
			)
		{
			BOSalesOrderHeaderSalesReason BOSalesOrderHeaderSalesReason = new BOSalesOrderHeaderSalesReason();

			BOSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				model.ModifiedDate,
				model.SalesReasonID);
			return BOSalesOrderHeaderSalesReason;
		}

		public virtual ApiSalesOrderHeaderSalesReasonResponseModel MapBOToModel(
			BOSalesOrderHeaderSalesReason BOSalesOrderHeaderSalesReason)
		{
			if (BOSalesOrderHeaderSalesReason == null)
			{
				return null;
			}

			var model = new ApiSalesOrderHeaderSalesReasonResponseModel();

			model.SetProperties(BOSalesOrderHeaderSalesReason.ModifiedDate, BOSalesOrderHeaderSalesReason.SalesOrderID, BOSalesOrderHeaderSalesReason.SalesReasonID);

			return model;
		}

		public virtual List<ApiSalesOrderHeaderSalesReasonResponseModel> MapBOToModel(
			List<BOSalesOrderHeaderSalesReason> BOs)
		{
			List<ApiSalesOrderHeaderSalesReasonResponseModel> response = new List<ApiSalesOrderHeaderSalesReasonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>05a4008a34bfab134a6a64adc23626b6</Hash>
</Codenesium>*/