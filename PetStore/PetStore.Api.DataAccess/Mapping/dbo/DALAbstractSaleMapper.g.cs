using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
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
				dto.FirstName,
				dto.LastName,
				dto.PaymentTypeId,
				dto.PetId,
				dto.Phone);
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
				ef.FirstName,
				ef.LastName,
				ef.PaymentTypeId,
				ef.PetId,
				ef.Phone);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>4fb83522df7e6d7263cca4804527e254</Hash>
</Codenesium>*/