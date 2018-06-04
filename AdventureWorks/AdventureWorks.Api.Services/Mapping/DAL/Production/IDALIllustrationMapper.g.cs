using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALIllustrationMapper
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
    <Hash>89591b122da84bb3af20f6a65f5ae5c3</Hash>
</Codenesium>*/