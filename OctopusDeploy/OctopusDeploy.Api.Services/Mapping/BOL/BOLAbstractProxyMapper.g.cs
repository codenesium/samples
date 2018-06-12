using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractProxyMapper
        {
                public virtual BOProxy MapModelToBO(
                        string id,
                        ApiProxyRequestModel model
                        )
                {
                        BOProxy boProxy = new BOProxy();

                        boProxy.SetProperties(
                                id,
                                model.JSON,
                                model.Name);
                        return boProxy;
                }

                public virtual ApiProxyResponseModel MapBOToModel(
                        BOProxy boProxy)
                {
                        var model = new ApiProxyResponseModel();

                        model.SetProperties(boProxy.Id, boProxy.JSON, boProxy.Name);

                        return model;
                }

                public virtual List<ApiProxyResponseModel> MapBOToModel(
                        List<BOProxy> items)
                {
                        List<ApiProxyResponseModel> response = new List<ApiProxyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>66eb1445eed88beb4ed6cde2c2d0a818</Hash>
</Codenesium>*/