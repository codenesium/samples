using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class AbstractDALStateMapper
	{
		public virtual State MapBOToEF(
			BOState bo)
		{
			State efState = new State ();

			efState.SetProperties(
				bo.Id,
				bo.Name);
			return efState;
		}

		public virtual BOState MapEFToBO(
			State ef)
		{
			if (ef == null)
			{
				return null;
			}

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
    <Hash>0738c1b6bcb46429e4561c43e16aa6fc</Hash>
</Codenesium>*/