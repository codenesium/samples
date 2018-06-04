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
	public abstract class AbstractProductSubcategoryService: AbstractService
	{
		private IProductSubcategoryRepository productSubcategoryRepository;
		private IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator;
		private IBOLProductSubcategoryMapper BOLProductSubcategoryMapper;
		private IDALProductSubcategoryMapper DALProductSubcategoryMapper;
		private ILogger logger;

		public AbstractProductSubcategoryService(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper bolproductSubcategoryMapper,
			IDALProductSubcategoryMapper dalproductSubcategoryMapper)
			: base()

		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
			this.BOLProductSubcategoryMapper = bolproductSubcategoryMapper;
			this.DALProductSubcategoryMapper = dalproductSubcategoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productSubcategoryRepository.All(skip, take, orderClause);

			return this.BOLProductSubcategoryMapper.MapBOToModel(this.DALProductSubcategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID)
		{
			var record = await productSubcategoryRepository.Get(productSubcategoryID);

			return this.BOLProductSubcategoryMapper.MapBOToModel(this.DALProductSubcategoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
			ApiProductSubcategoryRequestModel model)
		{
			CreateResponse<ApiProductSubcategoryResponseModel> response = new CreateResponse<ApiProductSubcategoryResponseModel>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductSubcategoryMapper.MapModelToBO(default (int), model);
				var record = await this.productSubcategoryRepository.Create(this.DALProductSubcategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductSubcategoryMapper.MapBOToModel(this.DALProductSubcategoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model));

			if (response.Success)
			{
				var bo = this.BOLProductSubcategoryMapper.MapModelToBO(productSubcategoryID, model);
				await this.productSubcategoryRepository.Update(this.DALProductSubcategoryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				await this.productSubcategoryRepository.Delete(productSubcategoryID);
			}
			return response;
		}

		public async Task<ApiProductSubcategoryResponseModel> GetName(string name)
		{
			ProductSubcategory record = await this.productSubcategoryRepository.GetName(name);

			return this.BOLProductSubcategoryMapper.MapBOToModel(this.DALProductSubcategoryMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>702b5979dfddd1f6a42aed2641f0c652</Hash>
</Codenesium>*/