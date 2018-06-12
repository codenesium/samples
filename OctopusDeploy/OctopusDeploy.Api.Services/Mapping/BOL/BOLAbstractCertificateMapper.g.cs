using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractCertificateMapper
        {
                public virtual BOCertificate MapModelToBO(
                        string id,
                        ApiCertificateRequestModel model
                        )
                {
                        BOCertificate boCertificate = new BOCertificate();

                        boCertificate.SetProperties(
                                id,
                                model.Archived,
                                model.Created,
                                model.DataVersion,
                                model.EnvironmentIds,
                                model.JSON,
                                model.Name,
                                model.NotAfter,
                                model.Subject,
                                model.TenantIds,
                                model.TenantTags,
                                model.Thumbprint);
                        return boCertificate;
                }

                public virtual ApiCertificateResponseModel MapBOToModel(
                        BOCertificate boCertificate)
                {
                        var model = new ApiCertificateResponseModel();

                        model.SetProperties(boCertificate.Archived, boCertificate.Created, boCertificate.DataVersion, boCertificate.EnvironmentIds, boCertificate.Id, boCertificate.JSON, boCertificate.Name, boCertificate.NotAfter, boCertificate.Subject, boCertificate.TenantIds, boCertificate.TenantTags, boCertificate.Thumbprint);

                        return model;
                }

                public virtual List<ApiCertificateResponseModel> MapBOToModel(
                        List<BOCertificate> items)
                {
                        List<ApiCertificateResponseModel> response = new List<ApiCertificateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>38f1eaa66e0aab21f858463d35213790</Hash>
</Codenesium>*/