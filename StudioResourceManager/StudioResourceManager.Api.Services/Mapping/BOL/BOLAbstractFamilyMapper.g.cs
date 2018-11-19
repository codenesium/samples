using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractFamilyMapper
	{
		public virtual BOFamily MapModelToBO(
			int id,
			ApiFamilyServerRequestModel model
			)
		{
			BOFamily boFamily = new BOFamily();
			boFamily.SetProperties(
				id,
				model.Note,
				model.PrimaryContactEmail,
				model.PrimaryContactFirstName,
				model.PrimaryContactLastName,
				model.PrimaryContactPhone);
			return boFamily;
		}

		public virtual ApiFamilyServerResponseModel MapBOToModel(
			BOFamily boFamily)
		{
			var model = new ApiFamilyServerResponseModel();

			model.SetProperties(boFamily.Id, boFamily.Note, boFamily.PrimaryContactEmail, boFamily.PrimaryContactFirstName, boFamily.PrimaryContactLastName, boFamily.PrimaryContactPhone);

			return model;
		}

		public virtual List<ApiFamilyServerResponseModel> MapBOToModel(
			List<BOFamily> items)
		{
			List<ApiFamilyServerResponseModel> response = new List<ApiFamilyServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>68f41a82462d9e29590017ca2a561c91</Hash>
</Codenesium>*/