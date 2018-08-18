using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesReasonMapper
	{
		public virtual SalesReason MapBOToEF(
			BOSalesReason bo)
		{
			SalesReason efSalesReason = new SalesReason();
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
    <Hash>0f7167a370eaae26dd603960edafc57c</Hash>
</Codenesium>*/