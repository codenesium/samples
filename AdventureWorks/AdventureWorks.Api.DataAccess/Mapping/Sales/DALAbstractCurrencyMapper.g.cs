using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCurrencyMapper
	{
		public virtual void MapDTOToEF(
			string currencyCode,
			DTOCurrency dto,
			Currency efCurrency)
		{
			efCurrency.SetProperties(
				currencyCode,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOCurrency MapEFToDTO(
			Currency ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCurrency();

			dto.SetProperties(
				ef.CurrencyCode,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>de8312caae2eb0c2ec5aa3734ed5de14</Hash>
</Codenesium>*/