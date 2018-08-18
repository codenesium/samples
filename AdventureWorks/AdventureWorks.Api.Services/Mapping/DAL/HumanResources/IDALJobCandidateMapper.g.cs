using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALJobCandidateMapper
	{
		JobCandidate MapBOToEF(
			BOJobCandidate bo);

		BOJobCandidate MapEFToBO(
			JobCandidate efJobCandidate);

		List<BOJobCandidate> MapEFToBO(
			List<JobCandidate> records);
	}
}

/*<Codenesium>
    <Hash>491de76e9cd31b25f2790c31f3d32d09</Hash>
</Codenesium>*/