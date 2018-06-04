using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesReasonMapper
	{
		public virtual SalesReason MapBOToEF(
			BOSalesReason bo)
		{
			SalesReason efSalesReason = new SalesReason ();

			efSalesReason.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.ReasonType,
				bo.SalesReasonID);
			return efSalesReason;
		}

		public virtual BOSalesReason MapEFToBO(
			SalesReason ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOSalesReason();

			bo.SetProperties(
				ef.SalesReasonID,
				ef.ModifiedDate,
				ef.Name,
				ef.ReasonType);
			return bo;
		}

		public virtual List<BOSalesReason> MapEFToBO(
			List<SalesReason> records)
		{
			List<BOSalesReason> response = new List<BOSalesReason>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e73ef3b50db9074a73fa89c0402b28fb</Hash>
</Codenesium>*/