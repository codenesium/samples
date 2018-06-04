using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductDocumentMapper
	{
		ProductDocument MapBOToEF(
			BOProductDocument bo);

		BOProductDocument MapEFToBO(
			ProductDocument efProductDocument);

		List<BOProductDocument> MapEFToBO(
			List<ProductDocument> records);
	}
}

/*<Codenesium>
    <Hash>2cf9f453d51d387419a5482e9ccd0820</Hash>
</Codenesium>*/