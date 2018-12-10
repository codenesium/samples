using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractClaspMapper
	{
		public virtual Clasp MapBOToEF(
			BOClasp bo)
		{
			Clasp efClasp = new Clasp();
			efClasp.SetProperties(
				bo.Id,
				bo.NextChainId,
				bo.PreviousChainId);
			return efClasp;
		}

		public virtual BOClasp MapEFToBO(
			Clasp ef)
		{
			var bo = new BOClasp();

			bo.SetProperties(
				ef.Id,
				ef.NextChainId,
				ef.PreviousChainId);
			return bo;
		}

		public virtual List<BOClasp> MapEFToBO(
			List<Clasp> records)
		{
			List<BOClasp> response = new List<BOClasp>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9ac105e0018cd28120e0e4b769fd0e7d</Hash>
</Codenesium>*/