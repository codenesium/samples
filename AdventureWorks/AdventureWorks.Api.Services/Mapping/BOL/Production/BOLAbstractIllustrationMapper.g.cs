using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractIllustrationMapper
        {
                public virtual BOIllustration MapModelToBO(
                        int illustrationID,
                        ApiIllustrationRequestModel model
                        )
                {
                        BOIllustration boIllustration = new BOIllustration();

                        boIllustration.SetProperties(
                                illustrationID,
                                model.Diagram,
                                model.ModifiedDate);
                        return boIllustration;
                }

                public virtual ApiIllustrationResponseModel MapBOToModel(
                        BOIllustration boIllustration)
                {
                        var model = new ApiIllustrationResponseModel();

                        model.SetProperties(boIllustration.Diagram, boIllustration.IllustrationID, boIllustration.ModifiedDate);

                        return model;
                }

                public virtual List<ApiIllustrationResponseModel> MapBOToModel(
                        List<BOIllustration> items)
                {
                        List<ApiIllustrationResponseModel> response = new List<ApiIllustrationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e0b8c23d094cae1f7c5c6c88e2a24f77</Hash>
</Codenesium>*/