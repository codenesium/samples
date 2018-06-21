using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractPostHistoryTypesMapper
        {
                public virtual BOPostHistoryTypes MapModelToBO(
                        int id,
                        ApiPostHistoryTypesRequestModel model
                        )
                {
                        BOPostHistoryTypes boPostHistoryTypes = new BOPostHistoryTypes();
                        boPostHistoryTypes.SetProperties(
                                id,
                                model.Type);
                        return boPostHistoryTypes;
                }

                public virtual ApiPostHistoryTypesResponseModel MapBOToModel(
                        BOPostHistoryTypes boPostHistoryTypes)
                {
                        var model = new ApiPostHistoryTypesResponseModel();

                        model.SetProperties(boPostHistoryTypes.Id, boPostHistoryTypes.Type);

                        return model;
                }

                public virtual List<ApiPostHistoryTypesResponseModel> MapBOToModel(
                        List<BOPostHistoryTypes> items)
                {
                        List<ApiPostHistoryTypesResponseModel> response = new List<ApiPostHistoryTypesResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>699fe4ae0ed7d614586d33022e7c1328</Hash>
</Codenesium>*/