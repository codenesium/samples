using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractCertificateMapper
        {
                public virtual Certificate MapBOToEF(
                        BOCertificate bo)
                {
                        Certificate efCertificate = new Certificate();

                        efCertificate.SetProperties(
                                bo.Archived,
                                bo.Created,
                                bo.DataVersion,
                                bo.EnvironmentIds,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.NotAfter,
                                bo.Subject,
                                bo.TenantIds,
                                bo.TenantTags,
                                bo.Thumbprint);
                        return efCertificate;
                }

                public virtual BOCertificate MapEFToBO(
                        Certificate ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCertificate();

                        bo.SetProperties(
                                ef.Id,
                                ef.Archived,
                                ef.Created,
                                ef.DataVersion,
                                ef.EnvironmentIds,
                                ef.JSON,
                                ef.Name,
                                ef.NotAfter,
                                ef.Subject,
                                ef.TenantIds,
                                ef.TenantTags,
                                ef.Thumbprint);
                        return bo;
                }

                public virtual List<BOCertificate> MapEFToBO(
                        List<Certificate> records)
                {
                        List<BOCertificate> response = new List<BOCertificate>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>592de4816138e11bbeb58667edba5f89</Hash>
</Codenesium>*/