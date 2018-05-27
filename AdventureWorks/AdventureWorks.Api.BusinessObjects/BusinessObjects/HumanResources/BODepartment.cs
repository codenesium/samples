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
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper departmentMapper)
			: base(logger, departmentRepository, departmentModelValidator, departmentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a318ad525eefd0d058c6d60e1396a8a6</Hash>
</Codenesium>*/