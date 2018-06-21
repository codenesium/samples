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
        public abstract class AbstractApiEmployeePayHistoryRequestModelValidator : AbstractValidator<ApiEmployeePayHistoryRequestModel>
        {
                private int existingRecordId;

                private IEmployeePayHistoryRepository employeePayHistoryRepository;

                public AbstractApiEmployeePayHistoryRequestModelValidator(IEmployeePayHistoryRepository employeePayHistoryRepository)
                {
                        this.employeePayHistoryRepository = employeePayHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeePayHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PayFrequencyRules()
                {
                }

                public virtual void RateRules()
                {
                }

                public virtual void RateChangeDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>71aff8be86eb2c6fe8d6faf7cb05c746</Hash>
</Codenesium>*/