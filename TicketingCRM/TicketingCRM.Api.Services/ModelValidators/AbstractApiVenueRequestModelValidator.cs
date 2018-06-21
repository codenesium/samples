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
        public abstract class AbstractApiVenueRequestModelValidator : AbstractValidator<ApiVenueRequestModel>
        {
                private int existingRecordId;

                private IVenueRepository venueRepository;

                public AbstractApiVenueRequestModelValidator(IVenueRepository venueRepository)
                {
                        this.venueRepository = venueRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiVenueRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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

                public virtual void AdminIdRules()
                {
                        this.RuleFor(x => x.AdminId).MustAsync(this.BeValidAdmin).When(x => x?.AdminId != null).WithMessage("Invalid reference");
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).NotNull();
                        this.RuleFor(x => x.Email).Length(0, 128);
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

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).NotNull();
                        this.RuleFor(x => x.Phone).Length(0, 128);
                }

                public virtual void ProvinceIdRules()
                {
                        this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvince).When(x => x?.ProvinceId != null).WithMessage("Invalid reference");
                }

                public virtual void WebsiteRules()
                {
                        this.RuleFor(x => x.Website).NotNull();
                        this.RuleFor(x => x.Website).Length(0, 128);
                }

                private async Task<bool> BeValidAdmin(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.venueRepository.GetAdmin(id);

                        return record != null;
                }

                private async Task<bool> BeValidProvince(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.venueRepository.GetProvince(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>ee155cb5c1d700d3f7f6e607639d0519</Hash>
</Codenesium>*/