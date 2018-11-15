using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractReplyMapper
	{
		public virtual Reply MapBOToEF(
			BOReply bo)
		{
			Reply efReply = new Reply();
			efReply.SetProperties(
				bo.Content,
				bo.Date,
				bo.ReplierUserId,
				bo.ReplyId,
				bo.Time);
			return efReply;
		}

		public virtual BOReply MapEFToBO(
			Reply ef)
		{
			var bo = new BOReply();

			bo.SetProperties(
				ef.ReplyId,
				ef.Content,
				ef.Date,
				ef.ReplierUserId,
				ef.Time);
			return bo;
		}

		public virtual List<BOReply> MapEFToBO(
			List<Reply> records)
		{
			List<BOReply> response = new List<BOReply>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7bf65c4253dcffce8c0e1bf8c7cac5c6</Hash>
</Codenesium>*/