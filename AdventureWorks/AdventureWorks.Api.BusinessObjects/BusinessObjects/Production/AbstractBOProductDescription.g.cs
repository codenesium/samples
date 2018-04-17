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

		public virtual ApiResponse GetById(int productDescriptionID)
		{
			return this.productDescriptionRepository.GetById(productDescriptionID);
		}

		public virtual POCOProductDescription GetByIdDirect(int productDescriptionID)
		{
			return this.productDescriptionRepository.GetByIdDirect(productDescriptionID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDescriptionRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDescriptionRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDescriptionRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6c0decda5a882345b0dd3270731e80ca</Hash>
</Codenesium>*/