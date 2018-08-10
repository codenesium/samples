using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class CertificateRepository : AbstractCertificateRepository, ICertificateRepository
	{
		public CertificateRepository(
			ILogger<CertificateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca9967e068d3f6d181076b7cb9b1c823</Hash>
</Codenesium>*/