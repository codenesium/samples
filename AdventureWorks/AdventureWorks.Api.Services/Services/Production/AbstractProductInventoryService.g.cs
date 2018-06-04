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
	public abstract class AbstractProductInventoryService: AbstractService
	{
		private IProductInventoryRepository productInventoryRepository;
		private IApiProductInventoryRequestModelValidator productInventoryModelValidator;
		private IBOLProductInventoryMapper BOLProductInventoryMapper;
		private IDALProductInventoryMapper DALProductInventoryMapper;
		private ILogger logger;

		public AbstractProductInventoryService(
			ILogger logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper bolproductInventoryMapper,
			IDALProductInventoryMapper dalproductInventoryMapper)
			: base()

		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
			this.BOLProductInventoryMapper = bolproductInventoryMapper;
			this.DALProductInventoryMapper = dalproductInventoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productInventoryRepository.All(skip, take, orderClause);

			return this.BOLProductInventoryMapper.MapBOToModel(this.DALProductInventoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductInventoryResponseModel> Get(int productID)
		{
			var record = await productInventoryRepository.Get(productID);

			return this.BOLProductInventoryMapper.MapBOToModel(this.DALProductInventoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
			ApiProductInventoryRequestModel model)
		{
			CreateResponse<ApiProductInventoryResponseModel> response = new CreateResponse<ApiProductInventoryResponseModel>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductInventoryMapper.MapModelToBO(default (int), model);
				var record = await this.productInventoryRepository.Create(this.DALProductInventoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductInventoryMapper.MapBOToModel(this.DALProductInventoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductInventoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var bo = this.BOLProductInventoryMapper.MapModelToBO(productID, model);
				await this.productInventoryRepository.Update(this.DALProductInventoryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productInventoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de312be60bbf4bd235be45c355fbc946</Hash>
</Codenesium>*/