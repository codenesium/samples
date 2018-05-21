using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductModelIllustration: AbstractBOManager
	{
		private IProductModelIllustrationRepository productModelIllustrationRepository;
		private IApiProductModelIllustrationModelValidator productModelIllustrationModelValidator;
		private ILogger logger;

		public AbstractBOProductModelIllustration(
			ILogger logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationModelValidator productModelIllustrationModelValidator)
			: base()

		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
			this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelIllustrationRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductModelIllustration> Get(int productModelID)
		{
			return this.productModelIllustrationRepository.Get(productModelID);
		}

		public virtual async Task<CreateResponse<POCOProductModelIllustration>> Create(
			ApiProductModelIllustrationModel model)
		{
			CreateResponse<POCOProductModelIllustration> response = new CreateResponse<POCOProductModelIllustration>(await this.productModelIllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductModelIllustration record = await this.productModelIllustrationRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelIllustrationModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				await this.productModelIllustrationRepository.Update(productModelID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelIllustrationRepository.Delete(productModelID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b95d0a778158736a969e17b7e51ee801</Hash>
</Codenesium>*/