using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCustomerMapper
	{
		void MapDTOToEF(
			int customerID,
			DTOCustomer dto,
			Customer efCustomer);

		DTOCustomer MapEFToDTO(
			Customer efCustomer);
	}
}

/*<Codenesium>
    <Hash>f6e36f64b1df0d7423bd30919cdf2267</Hash>
</Codenesium>*/