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

namespace OctopusDeployNS.Api.Web
{
	[Route("api/certificates")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CertificateController : AbstractCertificateController
	{
		public CertificateController(
			ApiSettings settings,
			ILogger<CertificateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICertificateService certificateService,
			IApiCertificateModelMapper certificateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       certificateService,
			       certificateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>09a950f9b98743e10724ec22760f63ac</Hash>
</Codenesium>*/