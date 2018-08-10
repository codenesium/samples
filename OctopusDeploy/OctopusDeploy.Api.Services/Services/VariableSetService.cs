using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class VariableSetService : AbstractVariableSetService, IVariableSetService
	{
		public VariableSetService(
			ILogger<IVariableSetRepository> logger,
			IVariableSetRepository variableSetRepository,
			IApiVariableSetRequestModelValidator variableSetModelValidator,
			IBOLVariableSetMapper bolvariableSetMapper,
			IDALVariableSetMapper dalvariableSetMapper
			)
			: base(logger,
			       variableSetRepository,
			       variableSetModelValidator,
			       bolvariableSetMapper,
			       dalvariableSetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c0dcee4d9e7fe3e928fc990050431e72</Hash>
</Codenesium>*/