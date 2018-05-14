using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BODepartment: AbstractBODepartment, IBODepartment
	{
		public BODepartment(
			ILogger<DepartmentRepository> logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentModelValidator departmentModelValidator)
			: base(logger, departmentRepository, departmentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>42abe7bbe4e290e2774e5ea679734b0e</Hash>
</Codenesium>*/