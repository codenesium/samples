using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALTagMapper
	{
		Tag MapBOToEF(
			BOTag bo);

		BOTag MapEFToBO(
			Tag efTag);

		List<BOTag> MapEFToBO(
			List<Tag> records);
	}
}

/*<Codenesium>
    <Hash>144d6699e733429406530eed89573deb</Hash>
</Codenesium>*/