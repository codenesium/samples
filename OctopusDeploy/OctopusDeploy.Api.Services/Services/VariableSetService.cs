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
    <Hash>d97654e3acf66b23a655d312eba07541</Hash>
</Codenesium>*/