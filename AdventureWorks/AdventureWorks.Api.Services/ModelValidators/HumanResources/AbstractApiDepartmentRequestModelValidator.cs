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

                public ValidationResult Validate(ApiDepartmentRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDepartmentRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IDepartmentRepository DepartmentRepository { get; set; }
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDepartmentRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiDepartmentRequestModel model,  CancellationToken cancellationToken)
                {
                        Department record = await this.DepartmentRepository.GetName(model.Name);

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
    <Hash>62153f87a375e411acb3a9f86fb0e22d</Hash>
</Codenesium>*/