using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int pipelineStatusId,
                        int saleId)
                {
                        this.Id = id;
                        this.PipelineStatusId = pipelineStatusId;
                        this.SaleId = saleId;

                        this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
                }

                public int Id { get; private set; }

                public int PipelineStatusId { get; private set; }

                public string PipelineStatusIdEntity { get; set; }

                public int SaleId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e259437147369114fc0bdb5c9b0b6943</Hash>
</Codenesium>*/