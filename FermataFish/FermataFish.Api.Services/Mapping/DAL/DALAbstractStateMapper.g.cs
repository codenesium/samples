using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractStateMapper
	{
		public virtual State MapBOToEF(
			BOState bo)
		{
			State efState = new State();
			efState.SetProperties(
				bo.Id,
				bo.Name);
			return efState;
		}

		public virtual BOState MapEFToBO(
			State ef)
		{
			var bo = new BOState();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOState> MapEFToBO(
			List<State> records)
		{
			List<BOState> response = new List<BOState>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>06f2f4ce28eb3ec8078eae57f29a6a81</Hash>
</Codenesium>*/