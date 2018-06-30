using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractPipelineMapper
        {
                public virtual Pipeline MapBOToEF(
                        BOPipeline bo)
                {
                        Pipeline efPipeline = new Pipeline();
                        efPipeline.SetProperties(
                                bo.Id,
                                bo.PipelineStatusId,
                                bo.SaleId);
                        return efPipeline;
                }

                public virtual BOPipeline MapEFToBO(
                        Pipeline ef)
                {
                        var bo = new BOPipeline();

                        bo.SetProperties(
                                ef.Id,
                                ef.PipelineStatusId,
                                ef.SaleId);
                        return bo;
                }

                public virtual List<BOPipeline> MapEFToBO(
                        List<Pipeline> records)
                {
                        List<BOPipeline> response = new List<BOPipeline>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8ab941661c0a8928fecf0dd8bd56bc09</Hash>
</Codenesium>*/