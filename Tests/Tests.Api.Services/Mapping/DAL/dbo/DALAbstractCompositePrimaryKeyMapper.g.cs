using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class DALAbstractCompositePrimaryKeyMapper
	{
		public virtual CompositePrimaryKey MapBOToEF(
			BOCompositePrimaryKey bo)
		{
			CompositePrimaryKey efCompositePrimaryKey = new CompositePrimaryKey();
			efCompositePrimaryKey.SetProperties(
				bo.Id,
				bo.Id2);
			return efCompositePrimaryKey;
		}

		public virtual BOCompositePrimaryKey MapEFToBO(
			CompositePrimaryKey ef)
		{
			var bo = new BOCompositePrimaryKey();

			bo.SetProperties(
				ef.Id,
				ef.Id2);
			return bo;
		}

		public virtual List<BOCompositePrimaryKey> MapEFToBO(
			List<CompositePrimaryKey> records)
		{
			List<BOCompositePrimaryKey> response = new List<BOCompositePrimaryKey>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3646d8ad0c3d07b0cba4ca27fbaf1bcf</Hash>
</Codenesium>*/