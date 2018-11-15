using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCultureMapper
	{
		public virtual BOCulture MapModelToBO(
			string cultureID,
			ApiCultureServerRequestModel model
			)
		{
			BOCulture boCulture = new BOCulture();
			boCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return boCulture;
		}

		public virtual ApiCultureServerResponseModel MapBOToModel(
			BOCulture boCulture)
		{
			var model = new ApiCultureServerResponseModel();

			model.SetProperties(boCulture.CultureID, boCulture.ModifiedDate, boCulture.Name);

			return model;
		}

		public virtual List<ApiCultureServerResponseModel> MapBOToModel(
			List<BOCulture> items)
		{
			List<ApiCultureServerResponseModel> response = new List<ApiCultureServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4e79a9d490bf50c61669a3632f5c5f16</Hash>
</Codenesium>*/