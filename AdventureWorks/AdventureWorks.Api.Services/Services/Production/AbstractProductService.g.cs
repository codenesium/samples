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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductService: AbstractService
	{
		private IProductRepository productRepository;
		private IApiProductRequestModelValidator productModelValidator;
		private IBOLProductMapper BOLProductMapper;
		private IDALProductMapper DALProductMapper;
		private ILogger logger;

		public AbstractProductService(
			ILogger logger,
			IProductRepository productRepository,
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper bolproductMapper,
			IDALProductMapper dalproductMapper)
			: base()

		{
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
			this.BOLProductMapper = bolproductMapper;
			this.DALProductMapper = dalproductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productRepository.All(skip, take, orderClause);

			return this.BOLProductMapper.MapBOToModel(this.DALProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductResponseModel> Get(int productID)
		{
			var record = await productRepository.Get(productID);

			return this.BOLProductMapper.MapBOToModel(this.DALProductMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model)
		{
			CreateResponse<ApiProductResponseModel> response = new CreateResponse<ApiProductResponseModel>(await this.productModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductMapper.MapModelToBO(default (int), model);
				var record = await this.productRepository.Create(this.DALProductMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductMapper.MapBOToModel(this.DALProductMapper.MapEFToBO(record)));
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
				var bo = this.BOLProductMapper.MapModelToBO(productID, model);
				await this.productRepository.Update(this.DALProductMapper.MapBOToEF(bo));
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
			Product record = await this.productRepository.GetName(name);

			return this.BOLProductMapper.MapBOToModel(this.DALProductMapper.MapEFToBO(record));
		}
		public async Task<ApiProductResponseModel> GetProductNumber(string productNumber)
		{
			Product record = await this.productRepository.GetProductNumber(productNumber);

			return this.BOLProductMapper.MapBOToModel(this.DALProductMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>31019f65cdc6236a9f3fa8a1865b4bed</Hash>
</Codenesium>*/