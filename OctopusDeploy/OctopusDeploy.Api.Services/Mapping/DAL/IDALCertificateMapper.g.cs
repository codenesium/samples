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
    <Hash>dbf90102ead1064e26f705862c969e49</Hash>
</Codenesium>*/