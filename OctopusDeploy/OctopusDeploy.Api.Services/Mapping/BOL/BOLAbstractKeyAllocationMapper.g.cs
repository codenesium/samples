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

                        model.SetProperties(boKeyAllocation.CollectionName, boKeyAllocation.Allocated);

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
    <Hash>d2dcd5258a41a3aced7a2d77898d0008</Hash>
</Codenesium>*/