using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>802189d8e16d891121724710c458559d</Hash>
</Codenesium>*/