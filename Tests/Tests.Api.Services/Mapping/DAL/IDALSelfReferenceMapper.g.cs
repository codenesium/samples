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
    <Hash>d6a516c06f7087d4f5b882e62e64b463</Hash>
</Codenesium>*/