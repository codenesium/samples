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
    <Hash>120a88ee89adc1909ec9ba68bb837e5c</Hash>
</Codenesium>*/