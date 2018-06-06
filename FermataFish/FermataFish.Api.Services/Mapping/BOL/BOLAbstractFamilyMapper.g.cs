using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
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
				model.Notes,
				model.PcEmail,
				model.PcFirstName,
				model.PcLastName,
				model.PcPhone,
				model.StudioId);
			return boFamily;
		}

		public virtual ApiFamilyResponseModel MapBOToModel(
			BOFamily boFamily)
		{
			var model = new ApiFamilyResponseModel();

			model.SetProperties(boFamily.Id, boFamily.Notes, boFamily.PcEmail, boFamily.PcFirstName, boFamily.PcLastName, boFamily.PcPhone, boFamily.StudioId);

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
    <Hash>959b8f807966a9f6ad184077dd595cb1</Hash>
</Codenesium>*/