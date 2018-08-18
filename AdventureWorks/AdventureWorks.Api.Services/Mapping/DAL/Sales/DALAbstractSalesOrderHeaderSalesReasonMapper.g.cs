using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractSalesOrderHeaderSalesReasonMapper
	{
		public virtual SalesOrderHeaderSalesReason MapBOToEF(
			BOSalesOrderHeaderSalesReason bo)
		{
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
			efSalesOrderHeaderSalesReason.SetProperties(
				bo.ModifiedDate,
				bo.SalesOrderID,
				bo.SalesReasonID);
			return efSalesOrderHeaderSalesReason;
		}

		public virtual BOSalesOrderHeaderSalesReason MapEFToBO(
			SalesOrderHeaderSalesReason ef)
		{
			var bo = new BOSalesOrderHeaderSalesReason();

			bo.SetProperties(
				ef.SalesOrderID,
				ef.ModifiedDate,
				ef.SalesReasonID);
			return bo;
		}

		public virtual List<BOSalesOrderHeaderSalesReason> MapEFToBO(
			List<SalesOrderHeaderSalesReason> records)
		{
			List<BOSalesOrderHeaderSalesReason> response = new List<BOSalesOrderHeaderSalesReason>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e632dbebefe496c0886999e82a6b79f9</Hash>
</Codenesium>*/