using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class CertificateService: AbstractCertificateService, ICertificateService
        {
                public CertificateService(
                        ILogger<CertificateRepository> logger,
                        ICertificateRepository certificateRepository,
                        IApiCertificateRequestModelValidator certificateModelValidator,
                        IBOLCertificateMapper bolcertificateMapper,
                        IDALCertificateMapper dalcertificateMapper

                        )
                        : base(logger,
                               certificateRepository,
                               certificateModelValidator,
                               bolcertificateMapper,
                               dalcertificateMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>080d454d3db79df117026b9d80656311</Hash>
</Codenesium>*/