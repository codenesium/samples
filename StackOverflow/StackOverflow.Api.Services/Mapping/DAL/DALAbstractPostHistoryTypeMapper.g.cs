using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostHistoryTypeMapper
	{
		public virtual PostHistoryType MapBOToEF(
			BOPostHistoryType bo)
		{
			PostHistoryType efPostHistoryType = new PostHistoryType();
			efPostHistoryType.SetProperties(
				bo.Id,
				bo.Type);
			return efPostHistoryType;
		}

		public virtual BOPostHistoryType MapEFToBO(
			PostHistoryType ef)
		{
			var bo = new BOPostHistoryType();

			bo.SetProperties(
				ef.Id,
				ef.Type);
			return bo;
		}

		public virtual List<BOPostHistoryType> MapEFToBO(
			List<PostHistoryType> records)
		{
			List<BOPostHistoryType> response = new List<BOPostHistoryType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1fe4cd7a8493cd7c35db401f85e6cce7</Hash>
</Codenesium>*/