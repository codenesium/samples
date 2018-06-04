using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALDocumentMapper
	{
		Document MapBOToEF(
			BODocument bo);

		BODocument MapEFToBO(
			Document efDocument);

		List<BODocument> MapEFToBO(
			List<Document> records);
	}
}

/*<Codenesium>
    <Hash>9eec3ee0ea10e7b3996a23496f262e0c</Hash>
</Codenesium>*/