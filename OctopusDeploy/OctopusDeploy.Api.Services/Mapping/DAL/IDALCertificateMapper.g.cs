using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALCertificateMapper
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
    <Hash>0fa784d01db6148db6b72354e2a3e0dd</Hash>
</Codenesium>*/