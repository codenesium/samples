using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALReplyMapper
	{
		Reply MapBOToEF(
			BOReply bo);

		BOReply MapEFToBO(
			Reply efReply);

		List<BOReply> MapEFToBO(
			List<Reply> records);
	}
}

/*<Codenesium>
    <Hash>99185f4f9871b540438a642b4beab6f8</Hash>
</Codenesium>*/