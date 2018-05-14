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
		private IApiProductModelIllustrationModelValidator productModelIllustrationModelValidator;
		private ILogger logger;

		public AbstractBOProductModelIllustration(
			ILogger logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationModelValidator productModelIllustrationModelValidator)

		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
			this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelIllustrationRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductModelIllustration Get(int productModelID)
		{
			return this.productModelIllustrationRepository.Get(productModelID);
		}

		public virtual async Task<CreateResponse<POCOProductModelIllustration>> Create(
			ApiProductModelIllustrationModel model)
		{
			CreateResponse<POCOProductModelIllustration> response = new CreateResponse<POCOProductModelIllustration>(await this.productModelIllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductModelIllustration record = this.productModelIllustrationRepository.Create(model);
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
	}
}

/*<Codenesium>
    <Hash>cc34b53ea1397c57de1ddfae45f3895b</Hash>
</Codenesium>*/