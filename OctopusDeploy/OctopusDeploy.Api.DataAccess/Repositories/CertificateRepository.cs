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
    <Hash>193344cc3f0cbed3c3aaa4dffc45b76f</Hash>
</Codenesium>*/