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
	public partial class CertificateService : AbstractCertificateService, ICertificateService
	{
		public CertificateService(
			ILogger<ICertificateRepository> logger,
			ICertificateRepository certificateRepository,
			IApiCertificateRequestModelValidator certificateModelValidator,
			IBOLCertificateMapper bolcertificateMapper,
			IDALCertificateMapper dalcertificateMapper
			)
			: base(logger,
			       certificateRepository,
			       certificateModelValidator,
			       bolcertificateMapper,
			       dalcertificateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a2ff3502afc53d63e4f310051380339f</Hash>
</Codenesium>*/