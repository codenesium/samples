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
	public partial class PersonTypeRepository : AbstractPersonTypeRepository, IPersonTypeRepository
	{
		public PersonTypeRepository(
			ILogger<PersonTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ee1b1725e2160d8594f13347e286b4a8</Hash>
</Codenesium>*/