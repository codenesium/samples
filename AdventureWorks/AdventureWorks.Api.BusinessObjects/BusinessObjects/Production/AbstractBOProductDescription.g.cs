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
	public abstract class AbstractBOProductDescription
	{
		private IProductDescriptionRepository productDescriptionRepository;
		private IProductDescriptionModelValidator productDescriptionModelValidator;
		private ILogger logger;

		public AbstractBOProductDescription(
			ILogger logger,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator)

		{
			this.productDescriptionRepository = productDescriptionRepository;
			this.productDescriptionModelValidator = productDescriptionModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductDescriptionModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productDescriptionRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productDescriptionID,
			ProductDescriptionModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model));

			if (response.Success)
			{
				this.productDescriptionRepository.Update(productDescriptionID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));

			if (response.Success)
			{
				this.productDescriptionRepository.Delete(productDescriptionID);
			}
			return response;
		}

		public virtual POCOProductDescription Get(int productDescriptionID)
		{
			return this.productDescriptionRepository.Get(productDescriptionID);
		}

		public virtual List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDescriptionRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4898b1f39297a2c4c809e6045269bb87</Hash>
</Codenesium>*/