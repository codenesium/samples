using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class DALAbstractSaleMapper
	{
		public virtual Sale MapBOToEF(
			BOSale bo)
		{
			Sale efSale = new Sale();
			efSale.SetProperties(
				bo.Amount,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.PaymentTypeId,
				bo.PetId,
				bo.Phone);
			return efSale;
		}

		public virtual BOSale MapEFToBO(
			Sale ef)
		{
			var bo = new BOSale();

			bo.SetProperties(
				ef.Id,
				ef.Amount,
				ef.FirstName,
				ef.LastName,
				ef.PaymentTypeId,
				ef.PetId,
				ef.Phone);
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
    <Hash>c6e85ad42baedafc3b0614eb3ae819e7</Hash>
</Codenesium>*/