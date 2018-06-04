using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALScrapReasonMapper
	{
		public virtual ScrapReason MapBOToEF(
			BOScrapReason bo)
		{
			ScrapReason efScrapReason = new ScrapReason ();

			efScrapReason.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.ScrapReasonID);
			return efScrapReason;
		}

		public virtual BOScrapReason MapEFToBO(
			ScrapReason ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOScrapReason();

			bo.SetProperties(
				ef.ScrapReasonID,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOScrapReason> MapEFToBO(
			List<ScrapReason> records)
		{
			List<BOScrapReason> response = new List<BOScrapReason>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5ac6e3c50a64a02aeabd93a5014283ba</Hash>
</Codenesium>*/