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
	public abstract class AbstractBOSpecialOfferProduct: AbstractBOManager
	{
		private ISpecialOfferProductRepository specialOfferProductRepository;
		private IApiSpecialOfferProductModelValidator specialOfferProductModelValidator;
		private ILogger logger;

		public AbstractBOSpecialOfferProduct(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductModelValidator specialOfferProductModelValidator)
			: base()

		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferProductRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSpecialOfferProduct> Get(int specialOfferID)
		{
			return this.specialOfferProductRepository.Get(specialOfferID);
		}

		public virtual async Task<CreateResponse<POCOSpecialOfferProduct>> Create(
			ApiSpecialOfferProductModel model)
		{
			CreateResponse<POCOSpecialOfferProduct> response = new CreateResponse<POCOSpecialOfferProduct>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpecialOfferProduct record = await this.specialOfferProductRepository.Create(model);

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
				await this.specialOfferProductRepository.Update(specialOfferID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				await this.specialOfferProductRepository.Delete(specialOfferID);
			}
			return response;
		}

		public async Task<List<POCOSpecialOfferProduct>> GetProductID(int productID)
		{
			return await this.specialOfferProductRepository.GetProductID(productID);
		}
	}
}

/*<Codenesium>
    <Hash>36b9af1252648f44f652459fae284ce3</Hash>
</Codenesium>*/