using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class VersionInfoRepository: AbstractVersionInfoRepository, IVersionInfoRepository
	{
		public VersionInfoRepository(
			IDALVersionInfoMapper mapper,
			ILogger<VersionInfoRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>3649359fce7c0b35ff79889be2528e00</Hash>
</Codenesium>*/