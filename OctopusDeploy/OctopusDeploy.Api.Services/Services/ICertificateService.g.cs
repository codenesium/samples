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

                Task<ActionResponse> Update(string id,
                                            ApiCertificateRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiCertificateResponseModel> Get(string id);

                Task<List<ApiCertificateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCertificateResponseModel>> GetCreated(DateTimeOffset created);

                Task<List<ApiCertificateResponseModel>> GetDataVersion(byte[] dataVersion);

                Task<List<ApiCertificateResponseModel>> GetNotAfter(DateTimeOffset notAfter);

                Task<List<ApiCertificateResponseModel>> GetThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>0b0f1cc0a3ba25475dacbb7a85601188</Hash>
</Codenesium>*/