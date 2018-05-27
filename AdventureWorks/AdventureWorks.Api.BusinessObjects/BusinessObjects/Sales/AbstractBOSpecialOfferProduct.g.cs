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
		private IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator;
		private IBOLSpecialOfferProductMapper specialOfferProductMapper;
		private ILogger logger;

		public AbstractBOSpecialOfferProduct(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper specialOfferProductMapper)
			: base()

		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
			this.specialOfferProductMapper = specialOfferProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.specialOfferProductRepository.All(skip, take, orderClause);

			return this.specialOfferProductMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID)
		{
			var record = await specialOfferProductRepository.Get(specialOfferID);

			return this.specialOfferProductMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model)
		{
			CreateResponse<ApiSpecialOfferProductResponseModel> response = new CreateResponse<ApiSpecialOfferProductResponseModel>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.specialOfferProductMapper.MapModelToDTO(default (int), model);
				var record = await this.specialOfferProductRepository.Create(dto);

				response.SetRecord(this.specialOfferProductMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				var dto = this.specialOfferProductMapper.MapModelToDTO(specialOfferID, model);
				await this.specialOfferProductRepository.Update(specialOfferID, dto);
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

		public async Task<List<ApiSpecialOfferProductResponseModel>> GetProductID(int productID)
		{
			List<DTOSpecialOfferProduct> records = await this.specialOfferProductRepository.GetProductID(productID);

			return this.specialOfferProductMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>dfc75db2b19a673cdc6242717bc66c7b</Hash>
</Codenesium>*/