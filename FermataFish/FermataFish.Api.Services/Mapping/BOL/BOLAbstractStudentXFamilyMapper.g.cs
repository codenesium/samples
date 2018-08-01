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
				model.StudentId);
			return boStudentXFamily;
		}

		public virtual ApiStudentXFamilyResponseModel MapBOToModel(
			BOStudentXFamily boStudentXFamily)
		{
			var model = new ApiStudentXFamilyResponseModel();

			model.SetProperties(boStudentXFamily.Id, boStudentXFamily.FamilyId, boStudentXFamily.StudentId);

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
    <Hash>c8b0c24f2dcac4f62c00d1b48c13d68d</Hash>
</Codenesium>*/