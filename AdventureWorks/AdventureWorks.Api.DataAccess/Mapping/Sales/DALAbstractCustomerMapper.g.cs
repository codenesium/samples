using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCustomerMapper
	{
		public virtual void MapDTOToEF(
			int customerID,
			DTOCustomer dto,
			Customer efCustomer)
		{
			efCustomer.SetProperties(
				customerID,
				dto.AccountNumber,
				dto.ModifiedDate,
				dto.PersonID,
				dto.Rowguid,
				dto.StoreID,
				dto.TerritoryID);
		}

		public virtual DTOCustomer MapEFToDTO(
			Customer ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCustomer();

			dto.SetProperties(
				ef.CustomerID,
				ef.AccountNumber,
				ef.ModifiedDate,
				ef.PersonID,
				ef.Rowguid,
				ef.StoreID,
				ef.TerritoryID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>5ec85e14beffdfe2f6db1925443117aa</Hash>
</Codenesium>*/