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

                        model.SetProperties(boChain.ChainStatusId, boChain.ExternalId, boChain.Id, boChain.Name, boChain.TeamId);

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
    <Hash>7b52dc829f5925981ab956384bb9fa1b</Hash>
</Codenesium>*/