using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class CertificateRepository: AbstractCertificateRepository, ICertificateRepository
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
    <Hash>3cd09e9b1c058ea6f442307122fb218b</Hash>
</Codenesium>*/