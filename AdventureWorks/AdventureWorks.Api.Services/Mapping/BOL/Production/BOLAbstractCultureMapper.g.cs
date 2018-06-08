using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractCultureMapper
        {
                public virtual BOCulture MapModelToBO(
                        string cultureID,
                        ApiCultureRequestModel model
                        )
                {
                        BOCulture boCulture = new BOCulture();

                        boCulture.SetProperties(
                                cultureID,
                                model.ModifiedDate,
                                model.Name);
                        return boCulture;
                }

                public virtual ApiCultureResponseModel MapBOToModel(
                        BOCulture boCulture)
                {
                        var model = new ApiCultureResponseModel();

                        model.SetProperties(boCulture.CultureID, boCulture.ModifiedDate, boCulture.Name);

                        return model;
                }

                public virtual List<ApiCultureResponseModel> MapBOToModel(
                        List<BOCulture> items)
                {
                        List<ApiCultureResponseModel> response = new List<ApiCultureResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5d5f66966a1e4935cc8f8cd71294cfdf</Hash>
</Codenesium>*/