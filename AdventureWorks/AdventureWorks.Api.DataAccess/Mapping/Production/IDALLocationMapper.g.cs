using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALLocationMapper
	{
		void MapDTOToEF(
			short locationID,
			DTOLocation dto,
			Location efLocation);

		DTOLocation MapEFToDTO(
			Location efLocation);
	}
}

/*<Codenesium>
    <Hash>74bee237e37e7adef8452956500f3e7c</Hash>
</Codenesium>*/