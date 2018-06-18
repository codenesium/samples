using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>19bf3a55e40dc89c8ade993f2bfce599</Hash>
</Codenesium>*/