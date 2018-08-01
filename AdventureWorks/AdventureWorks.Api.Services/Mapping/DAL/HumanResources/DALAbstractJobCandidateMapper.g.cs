using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractJobCandidateMapper
	{
		public virtual JobCandidate MapBOToEF(
			BOJobCandidate bo)
		{
			JobCandidate efJobCandidate = new JobCandidate();
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
    <Hash>de3f01bef5c93aeae639a7c6d3928281</Hash>
</Codenesium>*/