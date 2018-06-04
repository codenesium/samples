using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public interface IDALPenMapper
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
    <Hash>380d67ef05f05933214e9e26b7954a41</Hash>
</Codenesium>*/