using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallPersonServerRequestModelValidator : AbstractApiCallPersonServerRequestModelValidator, IApiCallPersonServerRequestModelValidator
	{
		public ApiCallPersonServerRequestModelValidator(ICallPersonRepository callPersonRepository)
			: base(callPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallPersonServerRequestModel model)
		{
			this.NoteRules();
			this.PersonIdRules();
			this.PersonTypeIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallPersonServerRequestModel model)
		{
			this.NoteRules();
			this.PersonIdRules();
			this.PersonTypeIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7481403fa17ed7f7bfa34405a09d6bb6</Hash>
</Codenesium>*/