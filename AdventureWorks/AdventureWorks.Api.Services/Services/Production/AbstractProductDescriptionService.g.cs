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
	public abstract class AbstractProductDescriptionService : AbstractService
	{
		protected IProductDescriptionRepository ProductDescriptionRepository { get; private set; }

		protected IApiProductDescriptionRequestModelValidator ProductDescriptionModelValidator { get; private set; }

		protected IBOLProductDescriptionMapper BolProductDescriptionMapper { get; private set; }

		protected IDALProductDescriptionMapper DalProductDescriptionMapper { get; private set; }

		protected IBOLProductModelProductDescriptionCultureMapper BolProductModelProductDescriptionCultureMapper { get; private set; }

		protected IDALProductModelProductDescriptionCultureMapper DalProductModelProductDescriptionCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractProductDescriptionService(
			ILogger logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper bolProductDescriptionMapper,
			IDALProductDescriptionMapper dalProductDescriptionMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base()
		{
			this.ProductDescriptionRepository = productDescriptionRepository;
			this.ProductDescriptionModelValidator = productDescriptionModelValidator;
			this.BolProductDescriptionMapper = bolProductDescriptionMapper;
			this.DalProductDescriptionMapper = dalProductDescriptionMapper;
			this.BolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
			this.DalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductDescriptionRepository.All(limit, offset);

			return this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID)
		{
			var record = await this.ProductDescriptionRepository.Get(productDescriptionID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model)
		{
			CreateResponse<ApiProductDescriptionResponseModel> response = new CreateResponse<ApiProductDescriptionResponseModel>(await this.ProductDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductDescriptionMapper.MapModelToBO(default(int), model);
				var record = await this.ProductDescriptionRepository.Create(this.DalProductDescriptionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductDescriptionResponseModel>> Update(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model)
		{
			var validationResult = await this.ProductDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductDescriptionMapper.MapModelToBO(productDescriptionID, model);
				await this.ProductDescriptionRepository.Update(this.DalProductDescriptionMapper.MapBOToEF(bo));

				var record = await this.ProductDescriptionRepository.Get(productDescriptionID);

				return new UpdateResponse<ApiProductDescriptionResponseModel>(this.BolProductDescriptionMapper.MapBOToModel(this.DalProductDescriptionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductDescriptionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = new ActionResponse(await this.ProductDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));
			if (response.Success)
			{
				await this.ProductDescriptionRepository.Delete(productDescriptionID);
			}

			return response;
		}

		public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModelProductDescriptionCulture> records = await this.ProductDescriptionRepository.ProductModelProductDescriptionCultures(productDescriptionID, limit, offset);

			return this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>34868d52efb1f58227324732c47fbc92</Hash>
</Codenesium>*/