using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiPipelineStepNoteRequestModelValidator: AbstractValidator<ApiPipelineStepNoteRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPipelineStepNoteRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStepNoteRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IEmployeeRepository EmployeeRepository { get; set; }

                public IPipelineStepRepository PipelineStepRepository { get; set; }

                public virtual void EmployeeIdRules()
                {
                        this.RuleFor(x => x.EmployeeId).MustAsync(this.BeValidEmployee).When(x => x ?.EmployeeId != null).WithMessage("Invalid reference");
                }

                public virtual void NoteRules()
                {
                        this.RuleFor(x => x.Note).NotNull();
                        this.RuleFor(x => x.Note).Length(0, 2147483647);
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.EmployeeRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.PipelineStepRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>289a23fc41a60a829b47b9ad342a4f83</Hash>
</Codenesium>*/