using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class BOLAbstractPenMapper
        {
                public virtual BOPen MapModelToBO(
                        int id,
                        ApiPenRequestModel model
                        )
                {
                        BOPen boPen = new BOPen();

                        boPen.SetProperties(
                                id,
                                model.Name);
                        return boPen;
                }

                public virtual ApiPenResponseModel MapBOToModel(
                        BOPen boPen)
                {
                        var model = new ApiPenResponseModel();

                        model.SetProperties(boPen.Id, boPen.Name);

                        return model;
                }

                public virtual List<ApiPenResponseModel> MapBOToModel(
                        List<BOPen> items)
                {
                        List<ApiPenResponseModel> response = new List<ApiPenResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f0ff6a0bd72d7a021ca9a4a105b296b5</Hash>
</Codenesium>*/