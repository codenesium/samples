using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class DALAbstractOtherTransportMapper
        {
                public virtual OtherTransport MapBOToEF(
                        BOOtherTransport bo)
                {
                        OtherTransport efOtherTransport = new OtherTransport();

                        efOtherTransport.SetProperties(
                                bo.HandlerId,
                                bo.Id,
                                bo.PipelineStepId);
                        return efOtherTransport;
                }

                public virtual BOOtherTransport MapEFToBO(
                        OtherTransport ef)
                {
                        var bo = new BOOtherTransport();

                        bo.SetProperties(
                                ef.Id,
                                ef.HandlerId,
                                ef.PipelineStepId);
                        return bo;
                }

                public virtual List<BOOtherTransport> MapEFToBO(
                        List<OtherTransport> records)
                {
                        List<BOOtherTransport> response = new List<BOOtherTransport>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>226e77fddc952e2d3484d6e7a9e0f117</Hash>
</Codenesium>*/