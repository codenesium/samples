using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProduct dto,
			Product efProduct);

		DTOProduct MapEFToDTO(
			Product efProduct);
	}
}

/*<Codenesium>
    <Hash>85a2865b43de9402514fb190fc76dbba</Hash>
</Codenesium>*/