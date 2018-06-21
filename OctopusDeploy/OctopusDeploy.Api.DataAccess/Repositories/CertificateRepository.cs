using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class CertificateRepository : AbstractCertificateRepository, ICertificateRepository
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
    <Hash>51063991857ea9fe6fe4c585d65fc742</Hash>
</Codenesium>*/