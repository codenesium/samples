using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesReasonMapper
	{
		public virtual BOSalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonRequestModel model
			)
		{
			BOSalesReason BOSalesReason = new BOSalesReason();

			BOSalesReason.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
			return BOSalesReason;
		}

		public virtual ApiSalesReasonResponseModel MapBOToModel(
			BOSalesReason BOSalesReason)
		{
			if (BOSalesReason == null)
			{
				return null;
			}

			var model = new ApiSalesReasonResponseModel();

			model.SetProperties(BOSalesReason.ModifiedDate, BOSalesReason.Name, BOSalesReason.ReasonType, BOSalesReason.SalesReasonID);

			return model;
		}

		public virtual List<ApiSalesReasonResponseModel> MapBOToModel(
			List<BOSalesReason> BOs)
		{
			List<ApiSalesReasonResponseModel> response = new List<ApiSalesReasonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c77bf2d627b9aaeb78ab616949b15a8d</Hash>
</Codenesium>*/