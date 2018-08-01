using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALEventRelatedDocumentMapper
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
    <Hash>52c09b2e45748774c0643f1e53551bcd</Hash>
</Codenesium>*/