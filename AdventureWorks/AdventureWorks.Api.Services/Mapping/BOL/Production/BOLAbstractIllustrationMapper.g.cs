using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2750dbc13611af1bc7ef50b903b6c040</Hash>
</Codenesium>*/