using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>ec803b7ed558732f513198c8566517d4</Hash>
</Codenesium>*/