using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStudentXFamilyMapper
	{
		public virtual BOStudentXFamily MapModelToBO(
			int id,
			ApiStudentXFamilyRequestModel model
			)
		{
			BOStudentXFamily boStudentXFamily = new BOStudentXFamily();
			boStudentXFamily.SetProperties(
				id,
				model.FamilyId,
				model.StudentId,
				model.StudioId);
			return boStudentXFamily;
		}

		public virtual ApiStudentXFamilyResponseModel MapBOToModel(
			BOStudentXFamily boStudentXFamily)
		{
			var model = new ApiStudentXFamilyResponseModel();

			model.SetProperties(boStudentXFamily.Id, boStudentXFamily.FamilyId, boStudentXFamily.StudentId, boStudentXFamily.StudioId);

			return model;
		}

		public virtual List<ApiStudentXFamilyResponseModel> MapBOToModel(
			List<BOStudentXFamily> items)
		{
			List<ApiStudentXFamilyResponseModel> response = new List<ApiStudentXFamilyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f403d500ddb2a8f497b3dd69a7d3daf6</Hash>
</Codenesium>*/