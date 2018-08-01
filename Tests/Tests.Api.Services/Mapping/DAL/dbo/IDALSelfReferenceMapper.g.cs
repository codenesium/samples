using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IDALSelfReferenceMapper
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
    <Hash>52a14aad3e5585d3f6f875b0a8b862db</Hash>
</Codenesium>*/