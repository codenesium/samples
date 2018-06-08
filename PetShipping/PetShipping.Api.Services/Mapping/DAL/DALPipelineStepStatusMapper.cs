using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALPipelineStepStatusMapper: DALAbstractPipelineStepStatusMapper, IDALPipelineStepStatusMapper
        {
                public DALPipelineStepStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7f25362dde69cf7c81cba03748a364d8</Hash>
</Codenesium>*/