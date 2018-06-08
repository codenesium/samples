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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>6174f4347d9b7824f07308981cf6fd36</Hash>
</Codenesium>*/