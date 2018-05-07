using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IIllustrationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(IllustrationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, IllustrationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>61217dcaececf45c02ca47759f39f2fc</Hash>
</Codenesium>*/