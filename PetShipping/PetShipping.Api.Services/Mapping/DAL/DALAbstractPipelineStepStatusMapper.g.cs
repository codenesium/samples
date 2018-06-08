using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>9170b1991904d1c66daee5445b6470db</Hash>
</Codenesium>*/