using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
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
    <Hash>5ac3892592a6a0e042434f4311d95605</Hash>
</Codenesium>*/