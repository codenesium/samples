using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IMediator mediator,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IDALEmployeeMapper dalEmployeeMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       mediator,
			       employeeRepository,
			       employeeModelValidator,
			       dalEmployeeMapper,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0ff5c79a5518967dc630f68b824d3030</Hash>
</Codenesium>*/