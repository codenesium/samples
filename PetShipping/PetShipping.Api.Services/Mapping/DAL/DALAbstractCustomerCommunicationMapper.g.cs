using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractCustomerCommunicationMapper
	{
		public virtual CustomerCommunication MapBOToEF(
			BOCustomerCommunication bo)
		{
			CustomerCommunication efCustomerCommunication = new CustomerCommunication();
			efCustomerCommunication.SetProperties(
				bo.CustomerId,
				bo.DateCreated,
				bo.EmployeeId,
				bo.Id,
				bo.Note);
			return efCustomerCommunication;
		}

		public virtual BOCustomerCommunication MapEFToBO(
			CustomerCommunication ef)
		{
			var bo = new BOCustomerCommunication();

			bo.SetProperties(
				ef.Id,
				ef.CustomerId,
				ef.DateCreated,
				ef.EmployeeId,
				ef.Note);
			return bo;
		}

		public virtual List<BOCustomerCommunication> MapEFToBO(
			List<CustomerCommunication> records)
		{
			List<BOCustomerCommunication> response = new List<BOCustomerCommunication>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0f85a519e0c4651ace38765583ad03ba</Hash>
</Codenesium>*/