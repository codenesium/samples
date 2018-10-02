using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALVProductAndDescriptionMapper
	{
		VProductAndDescription MapBOToEF(
			BOVProductAndDescription bo);

		BOVProductAndDescription MapEFToBO(
			VProductAndDescription efVProductAndDescription);

		List<BOVProductAndDescription> MapEFToBO(
			List<VProductAndDescription> records);
	}
}

/*<Codenesium>
    <Hash>d6e7785ea1df32dc9498a0973c50c80d</Hash>
</Codenesium>*/