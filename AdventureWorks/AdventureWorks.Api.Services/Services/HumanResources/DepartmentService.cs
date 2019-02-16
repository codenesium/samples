using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class DepartmentService : AbstractDepartmentService, IDepartmentService
	{
		public DepartmentService(
			ILogger<IDepartmentRepository> logger,
			IMediator mediator,
			IDepartmentRepository departmentRepository,
			IApiDepartmentServerRequestModelValidator departmentModelValidator,
			IDALDepartmentMapper dalDepartmentMapper)
			: base(logger,
			       mediator,
			       departmentRepository,
			       departmentModelValidator,
			       dalDepartmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d9a95b09f112af2fde04024f159f89e1</Hash>
</Codenesium>*/