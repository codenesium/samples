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
    <Hash>db28249301c02975984253f642ed9f9b</Hash>
</Codenesium>*/