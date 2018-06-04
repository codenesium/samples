using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class AbstractDALChainStatusMapper
	{
		public virtual ChainStatus MapBOToEF(
			BOChainStatus bo)
		{
			ChainStatus efChainStatus = new ChainStatus ();

			efChainStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efChainStatus;
		}

		public virtual BOChainStatus MapEFToBO(
			ChainStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOChainStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOChainStatus> MapEFToBO(
			List<ChainStatus> records)
		{
			List<BOChainStatus> response = new List<BOChainStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1a55703cea224315805042c83b53c8d8</Hash>
</Codenesium>*/