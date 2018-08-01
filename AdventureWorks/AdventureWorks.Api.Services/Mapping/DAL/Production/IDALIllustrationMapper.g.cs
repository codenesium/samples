using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALIllustrationMapper
	{
		Illustration MapBOToEF(
			BOIllustration bo);

		BOIllustration MapEFToBO(
			Illustration efIllustration);

		List<BOIllustration> MapEFToBO(
			List<Illustration> records);
	}
}

/*<Codenesium>
    <Hash>330615e06575c249a617176b75869188</Hash>
</Codenesium>*/