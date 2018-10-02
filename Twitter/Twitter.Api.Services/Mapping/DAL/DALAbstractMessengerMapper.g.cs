using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractMessengerMapper
	{
		public virtual Messenger MapBOToEF(
			BOMessenger bo)
		{
			Messenger efMessenger = new Messenger();
			efMessenger.SetProperties(
				bo.Date,
				bo.FromUserId,
				bo.Id,
				bo.MessageId,
				bo.Time,
				bo.ToUserId,
				bo.UserId);
			return efMessenger;
		}

		public virtual BOMessenger MapEFToBO(
			Messenger ef)
		{
			var bo = new BOMessenger();

			bo.SetProperties(
				ef.Id,
				ef.Date,
				ef.FromUserId,
				ef.MessageId,
				ef.Time,
				ef.ToUserId,
				ef.UserId);
			return bo;
		}

		public virtual List<BOMessenger> MapEFToBO(
			List<Messenger> records)
		{
			List<BOMessenger> response = new List<BOMessenger>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e09084d742b166335b2235ce95ec5a36</Hash>
</Codenesium>*/