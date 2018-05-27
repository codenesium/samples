using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALSaleMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOSale dto,
			Sale efSale)
		{
			efSale.SetProperties(
				id,
				dto.Amount,
				dto.ClientId,
				dto.Note,
				dto.PetId,
				dto.SaleDate,
				dto.SalesPersonId);
		}

		public virtual DTOSale MapEFToDTO(
			Sale ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSale();

			dto.SetProperties(
				ef.Id,
				ef.Amount,
				ef.ClientId,
				ef.Note,
				ef.PetId,
				ef.SaleDate,
				ef.SalesPersonId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1aa02e764ac6ae881a2f2daecbd57995</Hash>
</Codenesium>*/