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
    <Hash>eb149ad81b7bc8fb955f0b54736ac2b7</Hash>
</Codenesium>*/