using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLCertificateMapper
        {
                BOCertificate MapModelToBO(
                        string id,
                        ApiCertificateRequestModel model);

                ApiCertificateResponseModel MapBOToModel(
                        BOCertificate boCertificate);

                List<ApiCertificateResponseModel> MapBOToModel(
                        List<BOCertificate> items);
        }
}

/*<Codenesium>
    <Hash>b1f5c74e266f151183d32c047f1ede41</Hash>
</Codenesium>*/