using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>81bfba01cbc7fa4f07bf611eff801129</Hash>
</Codenesium>*/