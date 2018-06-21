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
        public class CertificateService : AbstractCertificateService, ICertificateService
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
    <Hash>8ab6fdddd8e08b5e2c3bdae443588078</Hash>
</Codenesium>*/