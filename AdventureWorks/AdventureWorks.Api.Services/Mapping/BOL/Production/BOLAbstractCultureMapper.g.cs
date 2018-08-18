using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCultureMapper
	{
		public virtual BOCulture MapModelToBO(
			string cultureID,
			ApiCultureRequestModel model
			)
		{
			BOCulture boCulture = new BOCulture();
			boCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return boCulture;
		}

		public virtual ApiCultureResponseModel MapBOToModel(
			BOCulture boCulture)
		{
			var model = new ApiCultureResponseModel();

			model.SetProperties(boCulture.CultureID, boCulture.ModifiedDate, boCulture.Name);

			return model;
		}

		public virtual List<ApiCultureResponseModel> MapBOToModel(
			List<BOCulture> items)
		{
			List<ApiCultureResponseModel> response = new List<ApiCultureResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f8534f61de09c3da24d123771e7f640a</Hash>
</Codenesium>*/