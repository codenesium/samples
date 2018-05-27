using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALBusinessEntityContactMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntityContact dto,
			BusinessEntityContact efBusinessEntityContact);

		DTOBusinessEntityContact MapEFToDTO(
			BusinessEntityContact efBusinessEntityContact);
	}
}

/*<Codenesium>
    <Hash>aa7cbc2040357fbc8ffc87eae10c1fdf</Hash>
</Codenesium>*/