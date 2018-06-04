using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiSpecialOfferRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7d568e47a43eaa63b7c2ffd1c2ef2f29</Hash>
</Codenesium>*/