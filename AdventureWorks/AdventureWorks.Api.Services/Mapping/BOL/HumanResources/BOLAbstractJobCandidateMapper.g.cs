using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a74767992c40b612ea438e765bff764d</Hash>
</Codenesium>*/