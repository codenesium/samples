using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolEmployeeMapper,
			IDALEmployeeMapper dalEmployeeMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base(logger,
			       employeeRepository,
			       employeeModelValidator,
			       bolEmployeeMapper,
			       dalEmployeeMapper,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper,
			       bolCustomerCommunicationMapper,
			       dalCustomerCommunicationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6098789b39297be3ff8bff849afa8fca</Hash>
</Codenesium>*/