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
        public abstract class AbstractApiSalesPersonRequestModelValidator : AbstractValidator<ApiSalesPersonRequestModel>
        {
                private int existingRecordId;

                private ISalesPersonRepository salesPersonRepository;

                public AbstractApiSalesPersonRequestModelValidator(ISalesPersonRepository salesPersonRepository)
                {
                        this.salesPersonRepository = salesPersonRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesPersonRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BonusRules()
                {
                }

                public virtual void CommissionPctRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalesLastYearRules()
                {
                }

                public virtual void SalesQuotaRules()
                {
                }

                public virtual void SalesYTDRules()
                {
                }

                public virtual void TerritoryIDRules()
                {
                        this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x?.TerritoryID != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSalesTerritory(Nullable<int> id,  CancellationToken cancellationToken)
                {
                        var record = await this.salesPersonRepository.GetSalesTerritory(id.GetValueOrDefault());

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>81823b334b4394e2b98f08c18978e210</Hash>
</Codenesium>*/