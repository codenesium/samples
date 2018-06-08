using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepNoteRequestModelValidator: AbstractApiPipelineStepNoteRequestModelValidator, IApiPipelineStepNoteRequestModelValidator
        {
                public ApiPipelineStepNoteRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model)
                {
                        this.EmployeeIdRules();
                        this.NoteRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model)
                {
                        this.EmployeeIdRules();
                        this.NoteRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>f1963de21ef197fa1712ada014168e25</Hash>
</Codenesium>*/