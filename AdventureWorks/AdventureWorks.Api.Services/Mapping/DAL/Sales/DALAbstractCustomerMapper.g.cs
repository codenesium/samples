using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractCustomerMapper
	{
		public virtual Customer MapBOToEF(
			BOCustomer bo)
		{
			Customer efCustomer = new Customer();
			efCustomer.SetProperties(
				bo.AccountNumber,
				bo.CustomerID,
				bo.ModifiedDate,
				bo.PersonID,
				bo.Rowguid,
				bo.StoreID,
				bo.TerritoryID);
			return efCustomer;
		}

		public virtual BOCustomer MapEFToBO(
			Customer ef)
		{
			var bo = new BOCustomer();

			bo.SetProperties(
				ef.CustomerID,
				ef.AccountNumber,
				ef.ModifiedDate,
				ef.PersonID,
				ef.Rowguid,
				ef.StoreID,
				ef.TerritoryID);
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
    <Hash>f4a9fd7c04b673413150a653776c4817</Hash>
</Codenesium>*/