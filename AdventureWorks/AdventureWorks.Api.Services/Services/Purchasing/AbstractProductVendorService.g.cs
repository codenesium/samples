using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductVendorService : AbstractService
	{
		protected IProductVendorRepository ProductVendorRepository { get; private set; }

		protected IApiProductVendorRequestModelValidator ProductVendorModelValidator { get; private set; }

		protected IBOLProductVendorMapper BolProductVendorMapper { get; private set; }

		protected IDALProductVendorMapper DalProductVendorMapper { get; private set; }

		private ILogger logger;

		public AbstractProductVendorService(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorRequestModelValidator productVendorModelValidator,
			IBOLProductVendorMapper bolProductVendorMapper,
			IDALProductVendorMapper dalProductVendorMapper)
			: base()
		{
			this.ProductVendorRepository = productVendorRepository;
			this.ProductVendorModelValidator = productVendorModelValidator;
			this.BolProductVendorMapper = bolProductVendorMapper;
			this.DalProductVendorMapper = dalProductVendorMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductVendorResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductVendorRepository.All(limit, offset);

			return this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductVendorResponseModel> Get(int productID)
		{
			var record = await this.ProductVendorRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductVendorResponseModel>> Create(
			ApiProductVendorRequestModel model)
		{
			CreateResponse<ApiProductVendorResponseModel> response = new CreateResponse<ApiProductVendorResponseModel>(await this.ProductVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductVendorMapper.MapModelToBO(default(int), model);
				var record = await this.ProductVendorRepository.Create(this.DalProductVendorMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductVendorResponseModel>> Update(
			int productID,
			ApiProductVendorRequestModel model)
		{
			var validationResult = await this.ProductVendorModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductVendorMapper.MapModelToBO(productID, model);
				await this.ProductVendorRepository.Update(this.DalProductVendorMapper.MapBOToEF(bo));

				var record = await this.ProductVendorRepository.Get(productID);

				return new UpdateResponse<ApiProductVendorResponseModel>(this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductVendorResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductVendorModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductVendorRepository.Delete(productID);
			}

			return response;
		}

		public async Task<List<ApiProductVendorResponseModel>> ByBusinessEntityID(int businessEntityID)
		{
			List<ProductVendor> records = await this.ProductVendorRepository.ByBusinessEntityID(businessEntityID);

			return this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(records));
		}

		public async Task<List<ApiProductVendorResponseModel>> ByUnitMeasureCode(string unitMeasureCode)
		{
			List<ProductVendor> records = await this.ProductVendorRepository.ByUnitMeasureCode(unitMeasureCode);

			return this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3b471543fb750764142a5355106e6950</Hash>
</Codenesium>*/