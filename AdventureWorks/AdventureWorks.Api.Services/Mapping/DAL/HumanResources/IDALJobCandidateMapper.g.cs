using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALJobCandidateMapper
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
    <Hash>d7024e3a17f60f6a8b1017bdd56dfc08</Hash>
</Codenesium>*/