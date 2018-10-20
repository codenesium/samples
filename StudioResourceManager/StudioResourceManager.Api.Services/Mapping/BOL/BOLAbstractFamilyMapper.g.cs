using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractFamilyMapper
	{
		public virtual BOFamily MapModelToBO(
			int id,
			ApiFamilyRequestModel model
			)
		{
			BOFamily boFamily = new BOFamily();
			boFamily.SetProperties(
				id,
				model.Note,
				model.PrimaryContactEmail,
				model.PrimaryContactFirstName,
				model.PrimaryContactLastName,
				model.PrimaryContactPhone,
				model.IsDeleted);
			return boFamily;
		}

		public virtual ApiFamilyResponseModel MapBOToModel(
			BOFamily boFamily)
		{
			var model = new ApiFamilyResponseModel();

			model.SetProperties(boFamily.Id, boFamily.Note, boFamily.PrimaryContactEmail, boFamily.PrimaryContactFirstName, boFamily.PrimaryContactLastName, boFamily.PrimaryContactPhone, boFamily.IsDeleted);

			return model;
		}

		public virtual List<ApiFamilyResponseModel> MapBOToModel(
			List<BOFamily> items)
		{
			List<ApiFamilyResponseModel> response = new List<ApiFamilyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1c0f31445806fe3024762bd90e2221e7</Hash>
</Codenesium>*/