using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDocumentMapper
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
    <Hash>66e8779513858b6bc1332d9e9b8a534f</Hash>
</Codenesium>*/