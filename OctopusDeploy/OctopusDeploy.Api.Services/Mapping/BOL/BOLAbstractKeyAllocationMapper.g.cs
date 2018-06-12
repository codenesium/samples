using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractKeyAllocationMapper
        {
                public virtual BOKeyAllocation MapModelToBO(
                        string collectionName,
                        ApiKeyAllocationRequestModel model
                        )
                {
                        BOKeyAllocation boKeyAllocation = new BOKeyAllocation();

                        boKeyAllocation.SetProperties(
                                collectionName,
                                model.Allocated);
                        return boKeyAllocation;
                }

                public virtual ApiKeyAllocationResponseModel MapBOToModel(
                        BOKeyAllocation boKeyAllocation)
                {
                        var model = new ApiKeyAllocationResponseModel();

                        model.SetProperties(boKeyAllocation.Allocated, boKeyAllocation.CollectionName);

                        return model;
                }

                public virtual List<ApiKeyAllocationResponseModel> MapBOToModel(
                        List<BOKeyAllocation> items)
                {
                        List<ApiKeyAllocationResponseModel> response = new List<ApiKeyAllocationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>401051acccb6d4d6804ad763b87ef1e4</Hash>
</Codenesium>*/