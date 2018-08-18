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
    <Hash>9ed4060acee55dafe7c5fb19fbde970e</Hash>
</Codenesium>*/