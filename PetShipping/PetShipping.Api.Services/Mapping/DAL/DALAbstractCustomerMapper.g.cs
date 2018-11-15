using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				bo.Note,
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
				ef.Note,
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
    <Hash>765f2327226b12d3aced27b3784e778b</Hash>
</Codenesium>*/