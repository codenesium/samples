using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDepartmentMapper
	{
		public virtual BODepartment MapModelToBO(
			short departmentID,
			ApiDepartmentRequestModel model
			)
		{
			BODepartment BODepartment = new BODepartment();

			BODepartment.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
			return BODepartment;
		}

		public virtual ApiDepartmentResponseModel MapBOToModel(
			BODepartment BODepartment)
		{
			if (BODepartment == null)
			{
				return null;
			}

			var model = new ApiDepartmentResponseModel();

			model.SetProperties(BODepartment.DepartmentID, BODepartment.GroupName, BODepartment.ModifiedDate, BODepartment.Name);

			return model;
		}

		public virtual List<ApiDepartmentResponseModel> MapBOToModel(
			List<BODepartment> BOs)
		{
			List<ApiDepartmentResponseModel> response = new List<ApiDepartmentResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c443669f8b61a3f51c039d76150d6cb9</Hash>
</Codenesium>*/