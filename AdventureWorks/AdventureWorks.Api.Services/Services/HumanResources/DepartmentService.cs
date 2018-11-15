using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DepartmentService : AbstractDepartmentService, IDepartmentService
	{
		public DepartmentService(
			ILogger<IDepartmentRepository> logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentServerRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper bolDepartmentMapper,
			IDALDepartmentMapper dalDepartmentMapper)
			: base(logger,
			       departmentRepository,
			       departmentModelValidator,
			       bolDepartmentMapper,
			       dalDepartmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bf3939e82ea9d216d3378f35bbcc7f5d</Hash>
</Codenesium>*/