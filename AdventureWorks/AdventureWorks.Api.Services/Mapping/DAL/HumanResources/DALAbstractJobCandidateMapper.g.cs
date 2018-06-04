using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALJobCandidateMapper
	{
		public virtual JobCandidate MapBOToEF(
			BOJobCandidate bo)
		{
			JobCandidate efJobCandidate = new JobCandidate ();

			efJobCandidate.SetProperties(
				bo.BusinessEntityID,
				bo.JobCandidateID,
				bo.ModifiedDate,
				bo.Resume);
			return efJobCandidate;
		}

		public virtual BOJobCandidate MapEFToBO(
			JobCandidate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOJobCandidate();

			bo.SetProperties(
				ef.JobCandidateID,
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.Resume);
			return bo;
		}

		public virtual List<BOJobCandidate> MapEFToBO(
			List<JobCandidate> records)
		{
			List<BOJobCandidate> response = new List<BOJobCandidate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>77390083ef9b99748d6940c896227f01</Hash>
</Codenesium>*/