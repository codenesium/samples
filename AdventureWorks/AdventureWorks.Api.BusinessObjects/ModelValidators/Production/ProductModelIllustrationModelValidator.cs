using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductModelIllustrationModelValidator: AbstractProductModelIllustrationModelValidator, IProductModelIllustrationModelValidator
	{
		public ProductModelIllustrationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductModelIllustrationModel model)
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelIllustrationModel model)
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d640d0bf1afcfee28ca8efe86eb0ea84</Hash>
</Codenesium>*/