using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALCertificateMapper
	{
		Certificate MapBOToEF(
			BOCertificate bo);

		BOCertificate MapEFToBO(
			Certificate efCertificate);

		List<BOCertificate> MapEFToBO(
			List<Certificate> records);
	}
}

/*<Codenesium>
    <Hash>cd141f05c45301493ccf16592c076b90</Hash>
</Codenesium>*/