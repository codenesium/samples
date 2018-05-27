using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALEmployeeMapper
	{
		void MapDTOToEF(
			int id,
			DTOEmployee dto,
			Employee efEmployee);

		DTOEmployee MapEFToDTO(
			Employee efEmployee);
	}
}

/*<Codenesium>
    <Hash>b7cf17f14c06d2062b60d2b71d8ead5c</Hash>
</Codenesium>*/