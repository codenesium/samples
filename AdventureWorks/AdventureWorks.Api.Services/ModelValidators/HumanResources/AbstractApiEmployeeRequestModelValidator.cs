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
        public abstract class AbstractApiEmployeeRequestModelValidator: AbstractValidator<ApiEmployeeRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiEmployeeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IEmployeeRepository EmployeeRepository { get; set; }
                public virtual void BirthDateRules()
                {
                }

                public virtual void CurrentFlagRules()
                {
                }

                public virtual void GenderRules()
                {
                        this.RuleFor(x => x.Gender).NotNull();
                        this.RuleFor(x => x.Gender).Length(0, 1);
                }

                public virtual void HireDateRules()
                {
                }

                public virtual void JobTitleRules()
                {
                        this.RuleFor(x => x.JobTitle).NotNull();
                        this.RuleFor(x => x.JobTitle).Length(0, 50);
                }

                public virtual void LoginIDRules()
                {
                        this.RuleFor(x => x.LoginID).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetLoginID).When(x => x ?.LoginID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.LoginID));
                        this.RuleFor(x => x.LoginID).Length(0, 256);
                }

                public virtual void MaritalStatusRules()
                {
                        this.RuleFor(x => x.MaritalStatus).NotNull();
                        this.RuleFor(x => x.MaritalStatus).Length(0, 1);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NationalIDNumberRules()
                {
                        this.RuleFor(x => x.NationalIDNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetNationalIDNumber).When(x => x ?.NationalIDNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.NationalIDNumber));
                        this.RuleFor(x => x.NationalIDNumber).Length(0, 15);
                }

                public virtual void OrganizationLevelRules()
                {
                }

                public virtual void OrganizationNodeRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalariedFlagRules()
                {
                }

                public virtual void SickLeaveHoursRules()
                {
                }

                public virtual void VacationHoursRules()
                {
                }

                private async Task<bool> BeUniqueGetLoginID(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
                {
                        Employee record = await this.EmployeeRepository.GetLoginID(model.LoginID);

                        if (record == null || (this.existingRecordId != default (int) && record.BusinessEntityID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetNationalIDNumber(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
                {
                        Employee record = await this.EmployeeRepository.GetNationalIDNumber(model.NationalIDNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.BusinessEntityID == this.existingRecordId))
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
    <Hash>224d547396a714d60c365ca6572f3eed</Hash>
</Codenesium>*/