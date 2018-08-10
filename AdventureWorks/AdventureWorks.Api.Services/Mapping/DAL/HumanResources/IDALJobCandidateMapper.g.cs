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
    <Hash>e61fcde0bbfce870add69c33c79f1546</Hash>
</Codenesium>*/