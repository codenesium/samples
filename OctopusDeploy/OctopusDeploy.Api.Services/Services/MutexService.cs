using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class MutexService : AbstractMutexService, IMutexService
	{
		public MutexService(
			ILogger<IMutexRepository> logger,
			IMutexRepository mutexRepository,
			IApiMutexRequestModelValidator mutexModelValidator,
			IBOLMutexMapper bolmutexMapper,
			IDALMutexMapper dalmutexMapper
			)
			: base(logger,
			       mutexRepository,
			       mutexModelValidator,
			       bolmutexMapper,
			       dalmutexMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>73fedc1589071c9ec318230ce1d9e5c1</Hash>
</Codenesium>*/