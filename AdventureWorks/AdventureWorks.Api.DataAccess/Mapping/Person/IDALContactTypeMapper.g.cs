using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALContactTypeMapper
	{
		void MapDTOToEF(
			int contactTypeID,
			DTOContactType dto,
			ContactType efContactType);

		DTOContactType MapEFToDTO(
			ContactType efContactType);
	}
}

/*<Codenesium>
    <Hash>f398f1b6e77746d75d956fd79f868deb</Hash>
</Codenesium>*/