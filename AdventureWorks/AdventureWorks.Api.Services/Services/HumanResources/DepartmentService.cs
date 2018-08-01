using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class DepartmentService : AbstractDepartmentService, IDepartmentService
	{
		public DepartmentService(
			ILogger<IDepartmentRepository> logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper boldepartmentMapper,
			IDALDepartmentMapper daldepartmentMapper,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper
			)
			: base(logger,
			       departmentRepository,
			       departmentModelValidator,
			       boldepartmentMapper,
			       daldepartmentMapper,
			       bolEmployeeDepartmentHistoryMapper,
			       dalEmployeeDepartmentHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5362e17c841319d9216c8c46f47f96e0</Hash>
</Codenesium>*/