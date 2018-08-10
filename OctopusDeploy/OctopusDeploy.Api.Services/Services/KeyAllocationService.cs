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
	public partial class KeyAllocationService : AbstractKeyAllocationService, IKeyAllocationService
	{
		public KeyAllocationService(
			ILogger<IKeyAllocationRepository> logger,
			IKeyAllocationRepository keyAllocationRepository,
			IApiKeyAllocationRequestModelValidator keyAllocationModelValidator,
			IBOLKeyAllocationMapper bolkeyAllocationMapper,
			IDALKeyAllocationMapper dalkeyAllocationMapper
			)
			: base(logger,
			       keyAllocationRepository,
			       keyAllocationModelValidator,
			       bolkeyAllocationMapper,
			       dalkeyAllocationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>57f5682d20d44dd6e13311dc0426e275</Hash>
</Codenesium>*/