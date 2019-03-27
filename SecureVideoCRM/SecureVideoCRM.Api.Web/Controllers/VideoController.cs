using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Web
{
	[Route("api/videos")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VideoController : AbstractVideoController
	{
		public VideoController(
			ApiSettings settings,
			ILogger<VideoController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVideoService videoService,
			IApiVideoServerModelMapper videoModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       videoService,
			       videoModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ee65597a056b35bb26a699f580850a02</Hash>
</Codenesium>*/