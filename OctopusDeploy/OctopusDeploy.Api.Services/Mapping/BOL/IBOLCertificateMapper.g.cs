using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLCertificateMapper
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
    <Hash>8d748e9821e6145e3cd9732abe994ab1</Hash>
</Codenesium>*/