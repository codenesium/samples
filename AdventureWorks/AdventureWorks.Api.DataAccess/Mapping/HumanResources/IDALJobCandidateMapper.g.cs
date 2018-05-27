using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALJobCandidateMapper
	{
		void MapDTOToEF(
			int jobCandidateID,
			DTOJobCandidate dto,
			JobCandidate efJobCandidate);

		DTOJobCandidate MapEFToDTO(
			JobCandidate efJobCandidate);
	}
}

/*<Codenesium>
    <Hash>168632dbf4c5723684530a4bb4c96334</Hash>
</Codenesium>*/