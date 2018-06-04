using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCultureMapper
	{
		public virtual BOCulture MapModelToBO(
			string cultureID,
			ApiCultureRequestModel model
			)
		{
			BOCulture BOCulture = new BOCulture();

			BOCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return BOCulture;
		}

		public virtual ApiCultureResponseModel MapBOToModel(
			BOCulture BOCulture)
		{
			if (BOCulture == null)
			{
				return null;
			}

			var model = new ApiCultureResponseModel();

			model.SetProperties(BOCulture.CultureID, BOCulture.ModifiedDate, BOCulture.Name);

			return model;
		}

		public virtual List<ApiCultureResponseModel> MapBOToModel(
			List<BOCulture> BOs)
		{
			List<ApiCultureResponseModel> response = new List<ApiCultureResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8394991a1c1e052880958d77d240d19f</Hash>
</Codenesium>*/