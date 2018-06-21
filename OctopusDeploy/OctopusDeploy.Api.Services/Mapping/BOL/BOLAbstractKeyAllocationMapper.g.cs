using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1205cb4c4a675d9eed44c8645eae97b3</Hash>
</Codenesium>*/