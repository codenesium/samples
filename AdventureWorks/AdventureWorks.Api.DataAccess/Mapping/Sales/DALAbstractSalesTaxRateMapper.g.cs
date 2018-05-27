using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesTaxRateMapper
	{
		public virtual void MapDTOToEF(
			int salesTaxRateID,
			DTOSalesTaxRate dto,
			SalesTaxRate efSalesTaxRate)
		{
			efSalesTaxRate.SetProperties(
				salesTaxRateID,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid,
				dto.StateProvinceID,
				dto.TaxRate,
				dto.TaxType);
		}

		public virtual DTOSalesTaxRate MapEFToDTO(
			SalesTaxRate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesTaxRate();

			dto.SetProperties(
				ef.SalesTaxRateID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.StateProvinceID,
				ef.TaxRate,
				ef.TaxType);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>c7b3a28b411f0f960ce6beb4064a09e3</Hash>
</Codenesium>*/