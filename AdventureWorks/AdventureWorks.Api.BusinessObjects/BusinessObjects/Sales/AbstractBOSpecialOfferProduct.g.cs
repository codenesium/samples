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
		private IApiSpecialOfferProductModelValidator specialOfferProductModelValidator;
		private ILogger logger;

		public AbstractBOSpecialOfferProduct(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductModelValidator specialOfferProductModelValidator)

		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferProductRepository.All(skip, take, orderClause);
		}

		public virtual POCOSpecialOfferProduct Get(int specialOfferID)
		{
			return this.specialOfferProductRepository.Get(specialOfferID);
		}

		public virtual async Task<CreateResponse<POCOSpecialOfferProduct>> Create(
			ApiSpecialOfferProductModel model)
		{
			CreateResponse<POCOSpecialOfferProduct> response = new CreateResponse<POCOSpecialOfferProduct>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpecialOfferProduct record = this.specialOfferProductRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			ApiSpecialOfferProductModel model)
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

		public List<POCOSpecialOfferProduct> GetProductID(int productID)
		{
			return this.specialOfferProductRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>dc4a1c35f93ecfe74dc9661af971db89</Hash>
</Codenesium>*/