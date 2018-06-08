using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractScrapReasonMapper
        {
                public virtual BOScrapReason MapModelToBO(
                        short scrapReasonID,
                        ApiScrapReasonRequestModel model
                        )
                {
                        BOScrapReason boScrapReason = new BOScrapReason();

                        boScrapReason.SetProperties(
                                scrapReasonID,
                                model.ModifiedDate,
                                model.Name);
                        return boScrapReason;
                }

                public virtual ApiScrapReasonResponseModel MapBOToModel(
                        BOScrapReason boScrapReason)
                {
                        var model = new ApiScrapReasonResponseModel();

                        model.SetProperties(boScrapReason.ModifiedDate, boScrapReason.Name, boScrapReason.ScrapReasonID);

                        return model;
                }

                public virtual List<ApiScrapReasonResponseModel> MapBOToModel(
                        List<BOScrapReason> items)
                {
                        List<ApiScrapReasonResponseModel> response = new List<ApiScrapReasonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8c90313e67b0f354bd9aa5fbfa6df3a1</Hash>
</Codenesium>*/