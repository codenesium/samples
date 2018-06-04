using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class DepartmentService: AbstractDepartmentService, IDepartmentService
	{
		public DepartmentService(
			ILogger<DepartmentRepository> logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper BOLdepartmentMapper,
			IDALDepartmentMapper DALdepartmentMapper)
			: base(logger, departmentRepository,
			       departmentModelValidator,
			       BOLdepartmentMapper,
			       DALdepartmentMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>71d26fb5e54c587913da062e54b115c4</Hash>
</Codenesium>*/