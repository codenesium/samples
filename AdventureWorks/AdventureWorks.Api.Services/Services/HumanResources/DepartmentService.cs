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
			IBOLDepartmentMapper bolDepartmentMapper,
			IDALDepartmentMapper dalDepartmentMapper)
			: base(logger,
			       mediator,
			       departmentRepository,
			       departmentModelValidator,
			       bolDepartmentMapper,
			       dalDepartmentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eb5e452e16af504f7ac3c0168f883c70</Hash>
</Codenesium>*/