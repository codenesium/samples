using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
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
    <Hash>c9623836e0189419fe435d58e66a80b2</Hash>
</Codenesium>*/