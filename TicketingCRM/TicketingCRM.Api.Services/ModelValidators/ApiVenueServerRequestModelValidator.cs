using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiVenueServerRequestModelValidator : AbstractApiVenueServerRequestModelValidator, IApiVenueServerRequestModelValidator
	{
		public ApiVenueServerRequestModelValidator(IVenueRepository venueRepository)
			: base(venueRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVenueServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.AdminIdRules();
			this.EmailRules();
			this.FacebookRules();
			this.NameRules();
			this.PhoneRules();
			this.ProvinceIdRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.AdminIdRules();
			this.EmailRules();
			this.FacebookRules();
			this.NameRules();
			this.PhoneRules();
			this.ProvinceIdRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c702c27ec63f5d780337d89ee3288bc3</Hash>
</Codenesium>*/