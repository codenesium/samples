using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSpecialOfferProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c01192a667f6d879982b0c875b53dddf</Hash>
</Codenesium>*/