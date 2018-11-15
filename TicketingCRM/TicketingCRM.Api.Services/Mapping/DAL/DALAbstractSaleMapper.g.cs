using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractSaleMapper
	{
		public virtual Sale MapBOToEF(
			BOSale bo)
		{
			Sale efSale = new Sale();
			efSale.SetProperties(
				bo.Id,
				bo.IpAddress,
				bo.Note,
				bo.SaleDate,
				bo.TransactionId);
			return efSale;
		}

		public virtual BOSale MapEFToBO(
			Sale ef)
		{
			var bo = new BOSale();

			bo.SetProperties(
				ef.Id,
				ef.IpAddress,
				ef.Note,
				ef.SaleDate,
				ef.TransactionId);
			return bo;
		}

		public virtual List<BOSale> MapEFToBO(
			List<Sale> records)
		{
			List<BOSale> response = new List<BOSale>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59ec2abe466aaaa844e751a604bfda03</Hash>
</Codenesium>*/