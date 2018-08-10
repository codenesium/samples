using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPenMapper
	{
		Pen MapBOToEF(
			BOPen bo);

		BOPen MapEFToBO(
			Pen efPen);

		List<BOPen> MapEFToBO(
			List<Pen> records);
	}
}

/*<Codenesium>
    <Hash>44bf3e1e1d7d80a39c0a347bd10bab87</Hash>
</Codenesium>*/