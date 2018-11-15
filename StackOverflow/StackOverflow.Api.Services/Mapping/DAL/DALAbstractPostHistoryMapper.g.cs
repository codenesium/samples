using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractPostHistoryMapper
	{
		public virtual PostHistory MapBOToEF(
			BOPostHistory bo)
		{
			PostHistory efPostHistory = new PostHistory();
			efPostHistory.SetProperties(
				bo.Comment,
				bo.CreationDate,
				bo.Id,
				bo.PostHistoryTypeId,
				bo.PostId,
				bo.RevisionGUID,
				bo.Text,
				bo.UserDisplayName,
				bo.UserId);
			return efPostHistory;
		}

		public virtual BOPostHistory MapEFToBO(
			PostHistory ef)
		{
			var bo = new BOPostHistory();

			bo.SetProperties(
				ef.Id,
				ef.Comment,
				ef.CreationDate,
				ef.PostHistoryTypeId,
				ef.PostId,
				ef.RevisionGUID,
				ef.Text,
				ef.UserDisplayName,
				ef.UserId);
			return bo;
		}

		public virtual List<BOPostHistory> MapEFToBO(
			List<PostHistory> records)
		{
			List<BOPostHistory> response = new List<BOPostHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5796a1176252aa5fc38774a2af03b8ff</Hash>
</Codenesium>*/