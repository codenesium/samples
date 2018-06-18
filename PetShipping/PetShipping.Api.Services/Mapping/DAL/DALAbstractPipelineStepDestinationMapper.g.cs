using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineStepDestinationMapper
        {
                public virtual PipelineStepDestination MapBOToEF(
                        BOPipelineStepDestination bo)
                {
                        PipelineStepDestination efPipelineStepDestination = new PipelineStepDestination();

                        efPipelineStepDestination.SetProperties(
                                bo.DestinationId,
                                bo.Id,
                                bo.PipelineStepId);
                        return efPipelineStepDestination;
                }

                public virtual BOPipelineStepDestination MapEFToBO(
                        PipelineStepDestination ef)
                {
                        var bo = new BOPipelineStepDestination();

                        bo.SetProperties(
                                ef.Id,
                                ef.DestinationId,
                                ef.PipelineStepId);
                        return bo;
                }

                public virtual List<BOPipelineStepDestination> MapEFToBO(
                        List<PipelineStepDestination> records)
                {
                        List<BOPipelineStepDestination> response = new List<BOPipelineStepDestination>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>433658f2c4714e850176aa81568f65f9</Hash>
</Codenesium>*/