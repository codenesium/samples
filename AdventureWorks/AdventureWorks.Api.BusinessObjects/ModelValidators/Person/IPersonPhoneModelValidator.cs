using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonPhoneModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f00b6cd216afa16e9721d2d977f8735e</Hash>
</Codenesium>*/