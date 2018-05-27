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
	public abstract class AbstractBOProductModelIllustration: AbstractBOManager
	{
		private IProductModelIllustrationRepository productModelIllustrationRepository;
		private IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator;
		private IBOLProductModelIllustrationMapper productModelIllustrationMapper;
		private ILogger logger;

		public AbstractBOProductModelIllustration(
			ILogger logger,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
			IBOLProductModelIllustrationMapper productModelIllustrationMapper)
			: base()

		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
			this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
			this.productModelIllustrationMapper = productModelIllustrationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productModelIllustrationRepository.All(skip, take, orderClause);

			return this.productModelIllustrationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductModelIllustrationResponseModel> Get(int productModelID)
		{
			var record = await productModelIllustrationRepository.Get(productModelID);

			return this.productModelIllustrationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
			ApiProductModelIllustrationRequestModel model)
		{
			CreateResponse<ApiProductModelIllustrationResponseModel> response = new CreateResponse<ApiProductModelIllustrationResponseModel>(await this.productModelIllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productModelIllustrationMapper.MapModelToDTO(default (int), model);
				var record = await this.productModelIllustrationRepository.Create(dto);

				response.SetRecord(this.productModelIllustrationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelIllustrationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				var dto = this.productModelIllustrationMapper.MapModelToDTO(productModelID, model);
				await this.productModelIllustrationRepository.Update(productModelID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelIllustrationRepository.Delete(productModelID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d15adc7ce044ffdf446720d12244545e</Hash>
</Codenesium>*/