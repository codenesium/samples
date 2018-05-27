using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALJobCandidateMapper
	{
		public virtual void MapDTOToEF(
			int jobCandidateID,
			DTOJobCandidate dto,
			JobCandidate efJobCandidate)
		{
			efJobCandidate.SetProperties(
				jobCandidateID,
				dto.BusinessEntityID,
				dto.ModifiedDate,
				dto.Resume);
		}

		public virtual DTOJobCandidate MapEFToDTO(
			JobCandidate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOJobCandidate();

			dto.SetProperties(
				ef.JobCandidateID,
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.Resume);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>dd2b546cf835866ca4e0a07dbd60aae2</Hash>
</Codenesium>*/