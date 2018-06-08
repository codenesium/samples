using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>a271d0407a7108fed00e50772b03855d</Hash>
</Codenesium>*/