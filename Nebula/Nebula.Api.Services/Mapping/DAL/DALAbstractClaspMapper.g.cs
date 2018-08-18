using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
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
    <Hash>c2f63fec6c4d34afd65f9d33f03ac308</Hash>
</Codenesium>*/