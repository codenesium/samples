using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>c380547bce9c7e0290df57b7b89fbf23</Hash>
</Codenesium>*/