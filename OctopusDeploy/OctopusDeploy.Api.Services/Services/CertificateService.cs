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
    <Hash>dd4c215b2ffa33b466c9ddd40a06b41f</Hash>
</Codenesium>*/