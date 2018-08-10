using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALCommentsMapper
	{
		Comments MapBOToEF(
			BOComments bo);

		BOComments MapEFToBO(
			Comments efComments);

		List<BOComments> MapEFToBO(
			List<Comments> records);
	}
}

/*<Codenesium>
    <Hash>0b96a660be3a151004f67097543705b1</Hash>
</Codenesium>*/