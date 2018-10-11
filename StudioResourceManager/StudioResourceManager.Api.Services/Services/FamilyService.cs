using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
			IDALStudentMapper dalStudentMapper)
			: base(logger,
			       familyRepository,
			       familyModelValidator,
			       bolfamilyMapper,
			       dalfamilyMapper,
			       bolStudentMapper,
			       dalStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3948951bb8021cad1888b51056b83c0e</Hash>
</Codenesium>*/