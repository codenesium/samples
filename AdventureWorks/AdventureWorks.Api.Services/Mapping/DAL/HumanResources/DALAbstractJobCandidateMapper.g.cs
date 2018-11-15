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
    <Hash>a239a6d6a5a6b2902db10385e53eab30</Hash>
</Codenesium>*/