using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALIllustrationMapper
	{
		Illustration MapBOToEF(
			BOIllustration bo);

		BOIllustration MapEFToBO(
			Illustration efIllustration);

		List<BOIllustration> MapEFToBO(
			List<Illustration> records);
	}
}

/*<Codenesium>
    <Hash>2665ccf653efabd9c3870515c973dbc6</Hash>
</Codenesium>*/