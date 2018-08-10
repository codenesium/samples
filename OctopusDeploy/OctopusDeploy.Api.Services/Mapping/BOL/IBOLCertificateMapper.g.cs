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
    <Hash>2e01be2f1c7de32db8534e59741cc5d5</Hash>
</Codenesium>*/