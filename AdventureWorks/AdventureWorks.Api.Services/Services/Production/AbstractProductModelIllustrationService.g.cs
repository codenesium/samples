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
	public abstract class AbstractProductModelIllustrationService : AbstractService
	{
		protected IProductModelIllustrationRepository ProductModelIllustrationRepository { get; private set; }

		protected IApiProductModelIllustrationRequestModelValidator ProductModelIllustrationModelValidator { get; private set; }

		protected IBOLProductModelIllustrationMapper BolProductModelIllustrationMapper { get; private set; }

		protected IDALProductModelIllustrationMapper DalProductModelIllustrationMapper { get; private set; }

		private ILogger logger;

		public AbstractProductModelIllustrationService(
			ILogger logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
			IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
			IDALProductModelIllustrationMapper dalProductModelIllustrationMapper)
			: base()
		{
			this.ProductModelIllustrationRepository = productModelIllustrationRepository;
			this.ProductModelIllustrationModelValidator = productModelIllustrationModelValidator;
			this.BolProductModelIllustrationMapper = bolProductModelIllustrationMapper;
			this.DalProductModelIllustrationMapper = dalProductModelIllustrationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductModelIllustrationRepository.All(limit, offset);

			return this.BolProductModelIllustrationMapper.MapBOToModel(this.DalProductModelIllustrationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelIllustrationResponseModel> Get(int productModelID)
		{
			var record = await this.ProductModelIllustrationRepository.Get(productModelID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductModelIllustrationMapper.MapBOToModel(this.DalProductModelIllustrationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
			ApiProductModelIllustrationRequestModel model)
		{
			CreateResponse<ApiProductModelIllustrationResponseModel> response = new CreateResponse<ApiProductModelIllustrationResponseModel>(await this.ProductModelIllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductModelIllustrationMapper.MapModelToBO(default(int), model);
				var record = await this.ProductModelIllustrationRepository.Create(this.DalProductModelIllustrationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductModelIllustrationMapper.MapBOToModel(this.DalProductModelIllustrationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductModelIllustrationResponseModel>> Update(
			int productModelID,
			ApiProductModelIllustrationRequestModel model)
		{
			var validationResult = await this.ProductModelIllustrationModelValidator.ValidateUpdateAsync(productModelID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductModelIllustrationMapper.MapModelToBO(productModelID, model);
				await this.ProductModelIllustrationRepository.Update(this.DalProductModelIllustrationMapper.MapBOToEF(bo));

				var record = await this.ProductModelIllustrationRepository.Get(productModelID);

				return new UpdateResponse<ApiProductModelIllustrationResponseModel>(this.BolProductModelIllustrationMapper.MapBOToModel(this.DalProductModelIllustrationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductModelIllustrationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.ProductModelIllustrationModelValidator.ValidateDeleteAsync(productModelID));
			if (response.Success)
			{
				await this.ProductModelIllustrationRepository.Delete(productModelID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ecdba3cc04401dfd9853edba29cfba48</Hash>
</Codenesium>*/