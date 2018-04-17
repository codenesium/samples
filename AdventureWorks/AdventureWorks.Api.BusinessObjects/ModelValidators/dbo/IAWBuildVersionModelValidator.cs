using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAWBuildVersionModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AWBuildVersionModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AWBuildVersionModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>868d42582ff8a8094f32a230575606d8</Hash>
</Codenesium>*/