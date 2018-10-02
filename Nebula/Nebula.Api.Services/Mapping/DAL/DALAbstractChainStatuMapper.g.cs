using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractChainStatuMapper
	{
		public virtual ChainStatu MapBOToEF(
			BOChainStatu bo)
		{
			ChainStatu efChainStatu = new ChainStatu();
			efChainStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efChainStatu;
		}

		public virtual BOChainStatu MapEFToBO(
			ChainStatu ef)
		{
			var bo = new BOChainStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOChainStatu> MapEFToBO(
			List<ChainStatu> records)
		{
			List<BOChainStatu> response = new List<BOChainStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9858c60252b4b02a5462c78e1add1e45</Hash>
</Codenesium>*/