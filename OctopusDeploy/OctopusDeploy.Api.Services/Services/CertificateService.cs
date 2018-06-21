using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>f03799bd5a8a7ab493fa54b6a3f5a0e9</Hash>
</Codenesium>*/