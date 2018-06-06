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

			model.SetProperties(boSalesReason.ModifiedDate, boSalesReason.Name, boSalesReason.ReasonType, boSalesReason.SalesReasonID);

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
    <Hash>fd98ea9e2ee0e286ad09adfb25eb1a78</Hash>
</Codenesium>*/