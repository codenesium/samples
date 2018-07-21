using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface ICertificateService
        {
                Task<CreateResponse<ApiCertificateResponseModel>> Create(
                        ApiCertificateRequestModel model);

                Task<UpdateResponse<ApiCertificateResponseModel>> Update(string id,
                                                                          ApiCertificateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiCertificateResponseModel> Get(string id);

                Task<List<ApiCertificateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCertificateResponseModel>> ByCreated(DateTimeOffset created);

                Task<List<ApiCertificateResponseModel>> ByDataVersion(byte[] dataVersion);

                Task<List<ApiCertificateResponseModel>> ByNotAfter(DateTimeOffset notAfter);

                Task<List<ApiCertificateResponseModel>> ByThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>92cdcdeaedc67aa199c286bae22511ee</Hash>
</Codenesium>*/