using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractCommentsMapper
	{
		public virtual Comments MapBOToEF(
			BOComments bo)
		{
			Comments efComments = new Comments();
			efComments.SetProperties(
				bo.CreationDate,
				bo.Id,
				bo.PostId,
				bo.Score,
				bo.Text,
				bo.UserId);
			return efComments;
		}

		public virtual BOComments MapEFToBO(
			Comments ef)
		{
			var bo = new BOComments();

			bo.SetProperties(
				ef.Id,
				ef.CreationDate,
				ef.PostId,
				ef.Score,
				ef.Text,
				ef.UserId);
			return bo;
		}

		public virtual List<BOComments> MapEFToBO(
			List<Comments> records)
		{
			List<BOComments> response = new List<BOComments>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c21c34b318b2fe3ebff44a82bcb50355</Hash>
</Codenesium>*/