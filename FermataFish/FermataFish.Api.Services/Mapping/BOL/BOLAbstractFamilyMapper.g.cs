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
			BOFamily BOFamily = new BOFamily();

			BOFamily.SetProperties(
				id,
				model.Notes,
				model.PcEmail,
				model.PcFirstName,
				model.PcLastName,
				model.PcPhone,
				model.StudioId);
			return BOFamily;
		}

		public virtual ApiFamilyResponseModel MapBOToModel(
			BOFamily BOFamily)
		{
			if (BOFamily == null)
			{
				return null;
			}

			var model = new ApiFamilyResponseModel();

			model.SetProperties(BOFamily.Id, BOFamily.Notes, BOFamily.PcEmail, BOFamily.PcFirstName, BOFamily.PcLastName, BOFamily.PcPhone, BOFamily.StudioId);

			return model;
		}

		public virtual List<ApiFamilyResponseModel> MapBOToModel(
			List<BOFamily> BOs)
		{
			List<ApiFamilyResponseModel> response = new List<ApiFamilyResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>74b60df7129f52ab9e34c070aaab11a9</Hash>
</Codenesium>*/