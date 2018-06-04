using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractContactTypeMapper
	{
		public virtual BOContactType MapModelToBO(
			int contactTypeID,
			ApiContactTypeRequestModel model
			)
		{
			BOContactType BOContactType = new BOContactType();

			BOContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
			return BOContactType;
		}

		public virtual ApiContactTypeResponseModel MapBOToModel(
			BOContactType BOContactType)
		{
			if (BOContactType == null)
			{
				return null;
			}

			var model = new ApiContactTypeResponseModel();

			model.SetProperties(BOContactType.ContactTypeID, BOContactType.ModifiedDate, BOContactType.Name);

			return model;
		}

		public virtual List<ApiContactTypeResponseModel> MapBOToModel(
			List<BOContactType> BOs)
		{
			List<ApiContactTypeResponseModel> response = new List<ApiContactTypeResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9583f883134fc29cf823fa62ebd3d394</Hash>
</Codenesium>*/