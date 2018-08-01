using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>c88f94bd1d96d18652074c2bbf778fa7</Hash>
</Codenesium>*/