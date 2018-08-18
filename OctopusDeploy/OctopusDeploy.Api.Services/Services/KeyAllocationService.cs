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
    <Hash>958589a958f3b8581a4c305ad76e093f</Hash>
</Codenesium>*/