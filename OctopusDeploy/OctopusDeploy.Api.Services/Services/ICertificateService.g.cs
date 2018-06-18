using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>655b1dc9513220246454ff4814d236d5</Hash>
</Codenesium>*/