using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineStepStatusMapper
        {
                public virtual PipelineStepStatus MapBOToEF(
                        BOPipelineStepStatus bo)
                {
                        PipelineStepStatus efPipelineStepStatus = new PipelineStepStatus();
                        efPipelineStepStatus.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efPipelineStepStatus;
                }

                public virtual BOPipelineStepStatus MapEFToBO(
                        PipelineStepStatus ef)
                {
                        var bo = new BOPipelineStepStatus();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOPipelineStepStatus> MapEFToBO(
                        List<PipelineStepStatus> records)
                {
                        List<BOPipelineStepStatus> response = new List<BOPipelineStepStatus>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>396e3790fddb3d5d339a6bf8cf1449fb</Hash>
</Codenesium>*/