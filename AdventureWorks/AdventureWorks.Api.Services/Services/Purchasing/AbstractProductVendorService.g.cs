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
	public abstract class AbstractProductVendorService: AbstractService
	{
		private IProductVendorRepository productVendorRepository;
		private IApiProductVendorRequestModelValidator productVendorModelValidator;
		private IBOLProductVendorMapper BOLProductVendorMapper;
		private IDALProductVendorMapper DALProductVendorMapper;
		private ILogger logger;

		public AbstractProductVendorService(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorRequestModelValidator productVendorModelValidator,
			IBOLProductVendorMapper bolproductVendorMapper,
			IDALProductVendorMapper dalproductVendorMapper)
			: base()

		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
			this.BOLProductVendorMapper = bolproductVendorMapper;
			this.DALProductVendorMapper = dalproductVendorMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productVendorRepository.All(skip, take, orderClause);

			return this.BOLProductVendorMapper.MapBOToModel(this.DALProductVendorMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductVendorResponseModel> Get(int productID)
		{
			var record = await productVendorRepository.Get(productID);

			return this.BOLProductVendorMapper.MapBOToModel(this.DALProductVendorMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductVendorResponseModel>> Create(
			ApiProductVendorRequestModel model)
		{
			CreateResponse<ApiProductVendorResponseModel> response = new CreateResponse<ApiProductVendorResponseModel>(await this.productVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductVendorMapper.MapModelToBO(default (int), model);
				var record = await this.productVendorRepository.Create(this.DALProductVendorMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductVendorMapper.MapBOToModel(this.DALProductVendorMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductVendorRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var bo = this.BOLProductVendorMapper.MapModelToBO(productID, model);
				await this.productVendorRepository.Update(this.DALProductVendorMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productVendorRepository.Delete(productID);
			}
			return response;
		}

		public async Task<List<ApiProductVendorResponseModel>> GetBusinessEntityID(int businessEntityID)
		{
			List<ProductVendor> records = await this.productVendorRepository.GetBusinessEntityID(businessEntityID);

			return this.BOLProductVendorMapper.MapBOToModel(this.DALProductVendorMapper.MapEFToBO(records));
		}
		public async Task<List<ApiProductVendorResponseModel>> GetUnitMeasureCode(string unitMeasureCode)
		{
			List<ProductVendor> records = await this.productVendorRepository.GetUnitMeasureCode(unitMeasureCode);

			return this.BOLProductVendorMapper.MapBOToModel(this.DALProductVendorMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6d7e29154f1ed0f33c4572f5eb3dd394</Hash>
</Codenesium>*/