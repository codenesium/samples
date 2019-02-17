using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDepartmentMapper
	{
		public virtual Department MapModelToEntity(
			short departmentID,
			ApiDepartmentServerRequestModel model
			)
		{
			Department item = new Department();
			item.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiDepartmentServerResponseModel MapEntityToModel(
			Department item)
		{
			var model = new ApiDepartmentServerResponseModel();

			model.SetProperties(item.DepartmentID,
			                    item.GroupName,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiDepartmentServerResponseModel> MapEntityToModel(
			List<Department> items)
		{
			List<ApiDepartmentServerResponseModel> response = new List<ApiDepartmentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ba74611e698a80b66d6c95b77f875bc2</Hash>
</Codenesium>*/