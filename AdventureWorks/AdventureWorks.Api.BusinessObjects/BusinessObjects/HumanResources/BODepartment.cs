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
			IDepartmentModelValidator departmentModelValidator)
			: base(logger, departmentRepository, departmentModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e4f732e75c087abb0dd63532cba17fb3</Hash>
</Codenesium>*/