using Codenesium.DataConversionExtensions;
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
    <Hash>2d3f1403a8c497f1f2a978adada98da1</Hash>
</Codenesium>*/