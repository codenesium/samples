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
    <Hash>e1308916d9a9b6e6738292f549efd49f</Hash>
</Codenesium>*/