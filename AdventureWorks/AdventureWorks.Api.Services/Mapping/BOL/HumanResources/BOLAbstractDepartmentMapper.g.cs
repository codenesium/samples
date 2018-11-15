using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDepartmentMapper
	{
		public virtual BODepartment MapModelToBO(
			short departmentID,
			ApiDepartmentServerRequestModel model
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

		public virtual ApiDepartmentServerResponseModel MapBOToModel(
			BODepartment boDepartment)
		{
			var model = new ApiDepartmentServerResponseModel();

			model.SetProperties(boDepartment.DepartmentID, boDepartment.GroupName, boDepartment.ModifiedDate, boDepartment.Name);

			return model;
		}

		public virtual List<ApiDepartmentServerResponseModel> MapBOToModel(
			List<BODepartment> items)
		{
			List<ApiDepartmentServerResponseModel> response = new List<ApiDepartmentServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cd9cd6f1aaae6178f342fc2aa99c9372</Hash>
</Codenesium>*/