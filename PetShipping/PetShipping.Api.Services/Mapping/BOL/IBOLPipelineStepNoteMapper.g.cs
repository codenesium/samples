using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStepNoteMapper
        {
                BOPipelineStepNote MapModelToBO(
                        int id,
                        ApiPipelineStepNoteRequestModel model);

                ApiPipelineStepNoteResponseModel MapBOToModel(
                        BOPipelineStepNote boPipelineStepNote);

                List<ApiPipelineStepNoteResponseModel> MapBOToModel(
                        List<BOPipelineStepNote> items);
        }
}

/*<Codenesium>
    <Hash>b369c821faccf11ce68fdae1ec519fb7</Hash>
</Codenesium>*/