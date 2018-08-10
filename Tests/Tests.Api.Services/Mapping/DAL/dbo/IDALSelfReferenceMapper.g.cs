using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALSelfReferenceMapper
	{
		SelfReference MapBOToEF(
			BOSelfReference bo);

		BOSelfReference MapEFToBO(
			SelfReference efSelfReference);

		List<BOSelfReference> MapEFToBO(
			List<SelfReference> records);
	}
}

/*<Codenesium>
    <Hash>7f07e3c9a46841eb35d155dcf2e9f97b</Hash>
</Codenesium>*/