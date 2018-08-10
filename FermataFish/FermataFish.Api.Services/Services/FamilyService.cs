using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class FamilyService : AbstractFamilyService, IFamilyService
	{
		public FamilyService(
			ILogger<IFamilyRepository> logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
			IBOLFamilyMapper bolfamilyMapper,
			IDALFamilyMapper dalfamilyMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper
			)
			: base(logger,
			       familyRepository,
			       familyModelValidator,
			       bolfamilyMapper,
			       dalfamilyMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolStudentXFamilyMapper,
			       dalStudentXFamilyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e9045df6fa45ada877ef3cefb9938989</Hash>
</Codenesium>*/