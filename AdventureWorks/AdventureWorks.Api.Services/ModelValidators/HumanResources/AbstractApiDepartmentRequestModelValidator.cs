using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiDepartmentRequestModelValidator: AbstractValidator<ApiDepartmentRequestModel>
        {
                private short existingRecordId;

                IDepartmentRepository departmentRepository;

                public AbstractApiDepartmentRequestModelValidator(IDepartmentRepository departmentRepository)
                {
                        this.departmentRepository = departmentRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDepartmentRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void GroupNameRules()
                {
                        this.RuleFor(x => x.GroupName).NotNull();
                        this.RuleFor(x => x.GroupName).Length(0, 50);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDepartmentRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueByName(ApiDepartmentRequestModel model,  CancellationToken cancellationToken)
                {
                        Department record = await this.departmentRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default (short) && record.DepartmentID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c279afdf51f5f557b281bde3292714b9</Hash>
</Codenesium>*/