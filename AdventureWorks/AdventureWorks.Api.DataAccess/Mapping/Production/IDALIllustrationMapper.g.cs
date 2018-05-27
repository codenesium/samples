using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALIllustrationMapper
	{
		void MapDTOToEF(
			int illustrationID,
			DTOIllustration dto,
			Illustration efIllustration);

		DTOIllustration MapEFToDTO(
			Illustration efIllustration);
	}
}

/*<Codenesium>
    <Hash>3f7731c8229ac16b314fa4d9cbe3e0da</Hash>
</Codenesium>*/