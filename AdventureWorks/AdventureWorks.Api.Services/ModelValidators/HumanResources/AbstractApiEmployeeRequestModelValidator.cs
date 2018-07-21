using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiEmployeeRequestModelValidator : AbstractValidator<ApiEmployeeRequestModel>
        {
                private int existingRecordId;

                private IEmployeeRepository employeeRepository;

                public AbstractApiEmployeeRequestModelValidator(IEmployeeRepository employeeRepository)
                {
                        this.employeeRepository = employeeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByLoginID).When(x => x?.LoginID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.LoginID));
                        this.RuleFor(x => x.LoginID).Length(0, 256);
                }

                public virtual void MaritalStatuRules()
                {
                        this.RuleFor(x => x.MaritalStatu).NotNull();
                        this.RuleFor(x => x.MaritalStatu).Length(0, 1);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NationalIDNumberRules()
                {
                        this.RuleFor(x => x.NationalIDNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByNationalIDNumber).When(x => x?.NationalIDNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.NationalIDNumber));
                        this.RuleFor(x => x.NationalIDNumber).Length(0, 15);
                }

                public virtual void OrganizationLevelRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalariedFlagRules()
                {
                }

                public virtual void SickLeaveHourRules()
                {
                }

                public virtual void VacationHourRules()
                {
                }

                private async Task<bool> BeUniqueByLoginID(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
                {
                        Employee record = await this.employeeRepository.ByLoginID(model.LoginID);

                        if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }

                private async Task<bool> BeUniqueByNationalIDNumber(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
                {
                        Employee record = await this.employeeRepository.ByNationalIDNumber(model.NationalIDNumber);

                        if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
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
    <Hash>8f636bfaddd2f0beebe63190dec7925d</Hash>
</Codenesium>*/