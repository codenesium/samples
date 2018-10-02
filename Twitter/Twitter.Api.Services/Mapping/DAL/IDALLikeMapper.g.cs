using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALLikeMapper
	{
		Like MapBOToEF(
			BOLike bo);

		BOLike MapEFToBO(
			Like efLike);

		List<BOLike> MapEFToBO(
			List<Like> records);
	}
}

/*<Codenesium>
    <Hash>cf35d5c9d5f1eff51a30b657f19244ff</Hash>
</Codenesium>*/