using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiWorkOrderRequestModelValidator : AbstractApiWorkOrderRequestModelValidator, IApiWorkOrderRequestModelValidator
        {
                public ApiWorkOrderRequestModelValidator(IWorkOrderRepository workOrderRepository)
                        : base(workOrderRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model)
                {
                        this.DueDateRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.OrderQtyRules();
                        this.ProductIDRules();
                        this.ScrappedQtyRules();
                        this.ScrapReasonIDRules();
                        this.StartDateRules();
                        this.StockedQtyRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model)
                {
                        this.DueDateRules();
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.OrderQtyRules();
                        this.ProductIDRules();
                        this.ScrappedQtyRules();
                        this.ScrapReasonIDRules();
                        this.StartDateRules();
                        this.StockedQtyRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>e9a0fdb6d692f0f1fa44dbef59561458</Hash>
</Codenesium>*/