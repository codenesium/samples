using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IDALPaymentTypeMapper
	{
		void MapDTOToEF(
			int id,
			DTOPaymentType dto,
			PaymentType efPaymentType);

		DTOPaymentType MapEFToDTO(
			PaymentType efPaymentType);
	}
}

/*<Codenesium>
    <Hash>5edbe36f65ac0eddc3a9827bdec7fcec</Hash>
</Codenesium>*/