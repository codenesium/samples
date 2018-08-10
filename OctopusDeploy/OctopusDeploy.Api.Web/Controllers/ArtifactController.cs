using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/artifacts")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ArtifactController : AbstractArtifactController
	{
		public ArtifactController(
			ApiSettings settings,
			ILogger<ArtifactController> logger,
			ITransactionCoordinator transactionCoordinator,
			IArtifactService artifactService,
			IApiArtifactModelMapper artifactModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       artifactService,
			       artifactModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>07a2db6c63d56452a219776f4ac34566</Hash>
</Codenesium>*/