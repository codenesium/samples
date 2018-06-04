using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALCultureMapper
	{
		Culture MapBOToEF(
			BOCulture bo);

		BOCulture MapEFToBO(
			Culture efCulture);

		List<BOCulture> MapEFToBO(
			List<Culture> records);
	}
}

/*<Codenesium>
    <Hash>576285fd0661822203c34e15fb9be452</Hash>
</Codenesium>*/