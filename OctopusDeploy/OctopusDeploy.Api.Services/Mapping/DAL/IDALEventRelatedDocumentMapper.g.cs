using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALEventRelatedDocumentMapper
	{
		EventRelatedDocument MapBOToEF(
			BOEventRelatedDocument bo);

		BOEventRelatedDocument MapEFToBO(
			EventRelatedDocument efEventRelatedDocument);

		List<BOEventRelatedDocument> MapEFToBO(
			List<EventRelatedDocument> records);
	}
}

/*<Codenesium>
    <Hash>6b7477a44f7874c628453bea387e6f37</Hash>
</Codenesium>*/