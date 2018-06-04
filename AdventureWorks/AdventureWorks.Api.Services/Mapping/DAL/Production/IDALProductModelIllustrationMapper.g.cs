using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductModelIllustrationMapper
	{
		ProductModelIllustration MapBOToEF(
			BOProductModelIllustration bo);

		BOProductModelIllustration MapEFToBO(
			ProductModelIllustration efProductModelIllustration);

		List<BOProductModelIllustration> MapEFToBO(
			List<ProductModelIllustration> records);
	}
}

/*<Codenesium>
    <Hash>a9cb451135fee2ab37d06e60a2181304</Hash>
</Codenesium>*/