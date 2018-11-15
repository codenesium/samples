using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiContactTypeServerRequestModelValidator : AbstractApiContactTypeServerRequestModelValidator, IApiContactTypeServerRequestModelValidator
	{
		public ApiContactTypeServerRequestModelValidator(IContactTypeRepository contactTypeRepository)
			: base(contactTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiContactTypeServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>aae59ba28de27a0629331b5023a130a2</Hash>
</Codenesium>*/