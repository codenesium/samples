using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStudentXFamilyMapper
	{
		public virtual DTOStudentXFamily MapModelToDTO(
			int id,
			ApiStudentXFamilyRequestModel model
			)
		{
			DTOStudentXFamily dtoStudentXFamily = new DTOStudentXFamily();

			dtoStudentXFamily.SetProperties(
				id,
				model.FamilyId,
				model.StudentId);
			return dtoStudentXFamily;
		}

		public virtual ApiStudentXFamilyResponseModel MapDTOToModel(
			DTOStudentXFamily dtoStudentXFamily)
		{
			if (dtoStudentXFamily == null)
			{
				return null;
			}

			var model = new ApiStudentXFamilyResponseModel();

			model.SetProperties(dtoStudentXFamily.FamilyId, dtoStudentXFamily.Id, dtoStudentXFamily.StudentId);

			return model;
		}

		public virtual List<ApiStudentXFamilyResponseModel> MapDTOToModel(
			List<DTOStudentXFamily> dtos)
		{
			List<ApiStudentXFamilyResponseModel> response = new List<ApiStudentXFamilyResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>49fd538ccf392e8bfc5a5e9bf9ea0f84</Hash>
</Codenesium>*/