using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDepartmentMapper
	{
		public virtual DTODepartment MapModelToDTO(
			short departmentID,
			ApiDepartmentRequestModel model
			)
		{
			DTODepartment dtoDepartment = new DTODepartment();

			dtoDepartment.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
			return dtoDepartment;
		}

		public virtual ApiDepartmentResponseModel MapDTOToModel(
			DTODepartment dtoDepartment)
		{
			if (dtoDepartment == null)
			{
				return null;
			}

			var model = new ApiDepartmentResponseModel();

			model.SetProperties(dtoDepartment.DepartmentID, dtoDepartment.GroupName, dtoDepartment.ModifiedDate, dtoDepartment.Name);

			return model;
		}

		public virtual List<ApiDepartmentResponseModel> MapDTOToModel(
			List<DTODepartment> dtos)
		{
			List<ApiDepartmentResponseModel> response = new List<ApiDepartmentResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5e523be6e65b1ce5ea9df5d97ad3e132</Hash>
</Codenesium>*/