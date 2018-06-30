using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public abstract class BOLAbstractChainMapper
        {
                public virtual BOChain MapModelToBO(
                        int id,
                        ApiChainRequestModel model
                        )
                {
                        BOChain boChain = new BOChain();
                        boChain.SetProperties(
                                id,
                                model.ChainStatusId,
                                model.ExternalId,
                                model.Name,
                                model.TeamId);
                        return boChain;
                }

                public virtual ApiChainResponseModel MapBOToModel(
                        BOChain boChain)
                {
                        var model = new ApiChainResponseModel();

                        model.SetProperties(boChain.Id, boChain.ChainStatusId, boChain.ExternalId, boChain.Name, boChain.TeamId);

                        return model;
                }

                public virtual List<ApiChainResponseModel> MapBOToModel(
                        List<BOChain> items)
                {
                        List<ApiChainResponseModel> response = new List<ApiChainResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9d7bb2a1b81570b375c322949dbd1d4a</Hash>
</Codenesium>*/