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
	public abstract class AbstractBOProduct: AbstractBOManager
	{
		private IProductRepository productRepository;
		private IApiProductRequestModelValidator productModelValidator;
		private IBOLProductMapper productMapper;
		private ILogger logger;

		public AbstractBOProduct(
			ILogger logger,
			IProductRepository productRepository,
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper productMapper)
			: base()

		{
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
			this.productMapper = productMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productRepository.All(skip, take, orderClause);

			return this.productMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductResponseModel> Get(int productID)
		{
			var record = await productRepository.Get(productID);

			return this.productMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model)
		{
			CreateResponse<ApiProductResponseModel> response = new CreateResponse<ApiProductResponseModel>(await this.productModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productMapper.MapModelToDTO(default (int), model);
				var record = await this.productRepository.Create(dto);

				response.SetRecord(this.productMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productMapper.MapModelToDTO(productID, model);
				await this.productRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productRepository.Delete(productID);
			}
			return response;
		}

		public async Task<ApiProductResponseModel> GetName(string name)
		{
			DTOProduct record = await this.productRepository.GetName(name);

			return this.productMapper.MapDTOToModel(record);
		}
		public async Task<ApiProductResponseModel> GetProductNumber(string productNumber)
		{
			DTOProduct record = await this.productRepository.GetProductNumber(productNumber);

			return this.productMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>3807a4c65cf81af5f0d68303a849b019</Hash>
</Codenesium>*/