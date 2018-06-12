using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>0684f04aa8b7e45fdc63b26a7c1e5f4e</Hash>
</Codenesium>*/