using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>494e030a09c685693f7e94fd0a9a8c9b</Hash>
</Codenesium>*/