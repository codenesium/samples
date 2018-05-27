using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALVendorMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOVendor dto,
			Vendor efVendor)
		{
			efVendor.SetProperties(
				businessEntityID,
				dto.AccountNumber,
				dto.ActiveFlag,
				dto.CreditRating,
				dto.ModifiedDate,
				dto.Name,
				dto.PreferredVendorStatus,
				dto.PurchasingWebServiceURL);
		}

		public virtual DTOVendor MapEFToDTO(
			Vendor ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOVendor();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.AccountNumber,
				ef.ActiveFlag,
				ef.CreditRating,
				ef.ModifiedDate,
				ef.Name,
				ef.PreferredVendorStatus,
				ef.PurchasingWebServiceURL);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>f06a1a0562dd521cd1d14e114b334b00</Hash>
</Codenesium>*/