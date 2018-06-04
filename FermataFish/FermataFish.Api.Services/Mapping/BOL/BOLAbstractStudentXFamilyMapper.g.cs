using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStudentXFamilyMapper
	{
		public virtual BOStudentXFamily MapModelToBO(
			int id,
			ApiStudentXFamilyRequestModel model
			)
		{
			BOStudentXFamily BOStudentXFamily = new BOStudentXFamily();

			BOStudentXFamily.SetProperties(
				id,
				model.FamilyId,
				model.StudentId);
			return BOStudentXFamily;
		}

		public virtual ApiStudentXFamilyResponseModel MapBOToModel(
			BOStudentXFamily BOStudentXFamily)
		{
			if (BOStudentXFamily == null)
			{
				return null;
			}

			var model = new ApiStudentXFamilyResponseModel();

			model.SetProperties(BOStudentXFamily.FamilyId, BOStudentXFamily.Id, BOStudentXFamily.StudentId);

			return model;
		}

		public virtual List<ApiStudentXFamilyResponseModel> MapBOToModel(
			List<BOStudentXFamily> BOs)
		{
			List<ApiStudentXFamilyResponseModel> response = new List<ApiStudentXFamilyResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6e479bdf89a6b72243802abae0d3b2ba</Hash>
</Codenesium>*/