using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractCustomerMapper
	{
		public virtual Customer MapBOToEF(
			BOCustomer bo)
		{
			Customer efCustomer = new Customer();
			efCustomer.SetProperties(
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Phone);
			return efCustomer;
		}

		public virtual BOCustomer MapEFToBO(
			Customer ef)
		{
			var bo = new BOCustomer();

			bo.SetProperties(
				ef.Id,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone);
			return bo;
		}

		public virtual List<BOCustomer> MapEFToBO(
			List<Customer> records)
		{
			List<BOCustomer> response = new List<BOCustomer>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e9ad16016d86481aa357075041da5b6</Hash>
</Codenesium>*/