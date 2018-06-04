using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductDescriptionMapper
	{
		public virtual BOProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model
			)
		{
			BOProductDescription BOProductDescription = new BOProductDescription();

			BOProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
			return BOProductDescription;
		}

		public virtual ApiProductDescriptionResponseModel MapBOToModel(
			BOProductDescription BOProductDescription)
		{
			if (BOProductDescription == null)
			{
				return null;
			}

			var model = new ApiProductDescriptionResponseModel();

			model.SetProperties(BOProductDescription.Description, BOProductDescription.ModifiedDate, BOProductDescription.ProductDescriptionID, BOProductDescription.Rowguid);

			return model;
		}

		public virtual List<ApiProductDescriptionResponseModel> MapBOToModel(
			List<BOProductDescription> BOs)
		{
			List<ApiProductDescriptionResponseModel> response = new List<ApiProductDescriptionResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>772933458d58993984052bddb428adf3</Hash>
</Codenesium>*/