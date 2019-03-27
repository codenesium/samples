using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class UnitOfficerRepository : AbstractUnitOfficerRepository, IUnitOfficerRepository
	{
		public UnitOfficerRepository(
			ILogger<UnitOfficerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>255974d2e9d4ccca13a6d69d444cb3c3</Hash>
</Codenesium>*/