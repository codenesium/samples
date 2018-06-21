using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractJobCandidateMapper
        {
                public virtual BOJobCandidate MapModelToBO(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel model
                        )
                {
                        BOJobCandidate boJobCandidate = new BOJobCandidate();
                        boJobCandidate.SetProperties(
                                jobCandidateID,
                                model.BusinessEntityID,
                                model.ModifiedDate,
                                model.Resume);
                        return boJobCandidate;
                }

                public virtual ApiJobCandidateResponseModel MapBOToModel(
                        BOJobCandidate boJobCandidate)
                {
                        var model = new ApiJobCandidateResponseModel();

                        model.SetProperties(boJobCandidate.BusinessEntityID, boJobCandidate.JobCandidateID, boJobCandidate.ModifiedDate, boJobCandidate.Resume);

                        return model;
                }

                public virtual List<ApiJobCandidateResponseModel> MapBOToModel(
                        List<BOJobCandidate> items)
                {
                        List<ApiJobCandidateResponseModel> response = new List<ApiJobCandidateResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7b201ba9108a3ed9ebc2f6b11f7bc6d8</Hash>
</Codenesium>*/