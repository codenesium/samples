using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractDALPaymentTypeMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPaymentType dto,
			PaymentType efPaymentType)
		{
			efPaymentType.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOPaymentType MapEFToDTO(
			PaymentType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPaymentType();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>7e3f2fea95c8d54cc3a3cc510f147581</Hash>
</Codenesium>*/