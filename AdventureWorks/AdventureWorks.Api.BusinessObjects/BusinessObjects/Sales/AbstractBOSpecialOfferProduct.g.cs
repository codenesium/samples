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
	public abstract class AbstractBOSpecialOfferProduct
	{
		private ISpecialOfferProductRepository specialOfferProductRepository;
		private ISpecialOfferProductModelValidator specialOfferProductModelValidator;
		private ILogger logger;

		public AbstractBOSpecialOfferProduct(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			ISpecialOfferProductModelValidator specialOfferProductModelValidator)

		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SpecialOfferProductModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.specialOfferProductRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			SpecialOfferProductModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				this.specialOfferProductRepository.Update(specialOfferID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				this.specialOfferProductRepository.Delete(specialOfferID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int specialOfferID)
		{
			return this.specialOfferProductRepository.GetById(specialOfferID);
		}

		public virtual POCOSpecialOfferProduct GetByIdDirect(int specialOfferID)
		{
			return this.specialOfferProductRepository.GetByIdDirect(specialOfferID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferProductRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferProductRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferProductRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8b8e5ff861ca9db19e0ac87be1e215af</Hash>
</Codenesium>*/