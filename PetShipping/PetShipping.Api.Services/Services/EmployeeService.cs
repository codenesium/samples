using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolemployeeMapper,
			IDALEmployeeMapper dalemployeeMapper,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base(logger,
			       employeeRepository,
			       employeeModelValidator,
			       bolemployeeMapper,
			       dalemployeeMapper,
			       bolClientCommunicationMapper,
			       dalClientCommunicationMapper,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3a33a83992888ee7d35bcd55552f6773</Hash>
</Codenesium>*/