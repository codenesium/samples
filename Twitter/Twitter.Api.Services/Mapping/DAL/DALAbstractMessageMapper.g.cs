using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractMessageMapper
	{
		public virtual Message MapBOToEF(
			BOMessage bo)
		{
			Message efMessage = new Message();
			efMessage.SetProperties(
				bo.Content,
				bo.MessageId,
				bo.SenderUserId);
			return efMessage;
		}

		public virtual BOMessage MapEFToBO(
			Message ef)
		{
			var bo = new BOMessage();

			bo.SetProperties(
				ef.MessageId,
				ef.Content,
				ef.SenderUserId);
			return bo;
		}

		public virtual List<BOMessage> MapEFToBO(
			List<Message> records)
		{
			List<BOMessage> response = new List<BOMessage>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a1fbe645295d07bc6746247a9f89c662</Hash>
</Codenesium>*/