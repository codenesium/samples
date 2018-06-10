using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiEventRequestModelValidator: AbstractValidator<ApiEventRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiEventRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEventRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICityRepository CityRepository { get; set; }

                public virtual void Address1Rules()
                {
                        this.RuleFor(x => x.Address1).NotNull();
                        this.RuleFor(x => x.Address1).Length(0, 128);
                }

                public virtual void Address2Rules()
                {
                        this.RuleFor(x => x.Address2).NotNull();
                        this.RuleFor(x => x.Address2).Length(0, 128);
                }

                public virtual void CityIdRules()
                {
                        this.RuleFor(x => x.CityId).NotNull();
                        this.RuleFor(x => x.CityId).MustAsync(this.BeValidCity).When(x => x ?.CityId != null).WithMessage("Invalid reference");
                }

                public virtual void DateRules()
                {
                        this.RuleFor(x => x.Date).NotNull();
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).NotNull();
                        this.RuleFor(x => x.Description).Length(0, 2147483647);
                }

                public virtual void EndDateRules()
                {
                        this.RuleFor(x => x.EndDate).NotNull();
                }

                public virtual void FacebookRules()
                {
                        this.RuleFor(x => x.Facebook).NotNull();
                        this.RuleFor(x => x.Facebook).Length(0, 128);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void StartDateRules()
                {
                        this.RuleFor(x => x.StartDate).NotNull();
                }

                public virtual void WebsiteRules()
                {
                        this.RuleFor(x => x.Website).NotNull();
                        this.RuleFor(x => x.Website).Length(0, 128);
                }

                private async Task<bool> BeValidCity(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.CityRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>cf779555ffbd08ccb6dc9314cccd38f0</Hash>
</Codenesium>*/