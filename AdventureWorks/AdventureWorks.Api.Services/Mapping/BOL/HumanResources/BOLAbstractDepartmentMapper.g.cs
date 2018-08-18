using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDepartmentMapper
	{
		public virtual BODepartment MapModelToBO(
			short departmentID,
			ApiDepartmentRequestModel model
			)
		{
			BODepartment boDepartment = new BODepartment();
			boDepartment.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
			return boDepartment;
		}

		public virtual ApiDepartmentResponseModel MapBOToModel(
			BODepartment boDepartment)
		{
			var model = new ApiDepartmentResponseModel();

			model.SetProperties(boDepartment.DepartmentID, boDepartment.GroupName, boDepartment.ModifiedDate, boDepartment.Name);

			return model;
		}

		public virtual List<ApiDepartmentResponseModel> MapBOToModel(
			List<BODepartment> items)
		{
			List<ApiDepartmentResponseModel> response = new List<ApiDepartmentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2ee21dac43fb109b58a8b02aa02e7a01</Hash>
</Codenesium>*/