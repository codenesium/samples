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
    <Hash>7980bcf74f53e6ae06ac80063dee0e3e</Hash>
</Codenesium>*/