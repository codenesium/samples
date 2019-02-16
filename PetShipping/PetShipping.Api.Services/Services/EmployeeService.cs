using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IMediator mediator,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IDALEmployeeMapper dalEmployeeMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base(logger,
			       mediator,
			       employeeRepository,
			       employeeModelValidator,
			       dalEmployeeMapper,
			       dalCustomerCommunicationMapper,
			       dalPipelineStepMapper,
			       dalPipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5268e76e1c8fab225f5b73182b49d773</Hash>
</Codenesium>*/