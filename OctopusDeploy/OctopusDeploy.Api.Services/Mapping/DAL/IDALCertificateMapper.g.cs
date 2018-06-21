using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALCertificateMapper
        {
                Certificate MapBOToEF(
                        BOCertificate bo);

                BOCertificate MapEFToBO(
                        Certificate efCertificate);

                List<BOCertificate> MapEFToBO(
                        List<Certificate> records);
        }
}

/*<Codenesium>
    <Hash>e26be50f13df9c0bf08228b2c0cbff45</Hash>
</Codenesium>*/