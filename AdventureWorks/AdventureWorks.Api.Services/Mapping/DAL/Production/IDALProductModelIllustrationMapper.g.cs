using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductModelIllustrationMapper
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
    <Hash>30bcfd646e270be04263d09740e62a68</Hash>
</Codenesium>*/