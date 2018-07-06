using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int pipelineStepStatusId,
                        int shipperId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PipelineStepStatusId = pipelineStepStatusId;
                        this.ShipperId = shipperId;

                        this.PipelineStepStatusIdEntity = nameof(ApiResponse.PipelineStepStatus);
                        this.ShipperIdEntity = nameof(ApiResponse.Employees);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int PipelineStepStatusId { get; private set; }

                public string PipelineStepStatusIdEntity { get; set; }

                public int ShipperId { get; private set; }

                public string ShipperIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>c9ab54d30e45f4133f47984bece2cca0</Hash>
</Codenesium>*/