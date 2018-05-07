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
	public abstract class AbstractBOProductModelIllustration
	{
		private IProductModelIllustrationRepository productModelIllustrationRepository;
		private IProductModelIllustrationModelValidator productModelIllustrationModelValidator;
		private ILogger logger;

		public AbstractBOProductModelIllustration(
			ILogger logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator)

		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
			this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductModelIllustrationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productModelIllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productModelIllustrationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ProductModelIllustrationModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				this.productModelIllustrationRepository.Update(productModelID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				this.productModelIllustrationRepository.Delete(productModelID);
			}
			return response;
		}

		public virtual POCOProductModelIllustration Get(int productModelID)
		{
			return this.productModelIllustrationRepository.Get(productModelID);
		}

		public virtual List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelIllustrationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>ddc46e399e08e33aa4ae6684c5a9dad5</Hash>
</Codenesium>*/