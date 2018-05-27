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
	public abstract class AbstractBOProductDescription: AbstractBOManager
	{
		private IProductDescriptionRepository productDescriptionRepository;
		private IApiProductDescriptionRequestModelValidator productDescriptionModelValidator;
		private IBOLProductDescriptionMapper productDescriptionMapper;
		private ILogger logger;

		public AbstractBOProductDescription(
			ILogger logger,
			IProductDescriptionRepository productDescriptionRepository,
			IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
			IBOLProductDescriptionMapper productDescriptionMapper)
			: base()

		{
			this.productDescriptionRepository = productDescriptionRepository;
			this.productDescriptionModelValidator = productDescriptionModelValidator;
			this.productDescriptionMapper = productDescriptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductDescriptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productDescriptionRepository.All(skip, take, orderClause);

			return this.productDescriptionMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID)
		{
			var record = await productDescriptionRepository.Get(productDescriptionID);

			return this.productDescriptionMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
			ApiProductDescriptionRequestModel model)
		{
			CreateResponse<ApiProductDescriptionResponseModel> response = new CreateResponse<ApiProductDescriptionResponseModel>(await this.productDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productDescriptionMapper.MapModelToDTO(default (int), model);
				var record = await this.productDescriptionRepository.Create(dto);

				response.SetRecord(this.productDescriptionMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productDescriptionID,
			ApiProductDescriptionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model));

			if (response.Success)
			{
				var dto = this.productDescriptionMapper.MapModelToDTO(productDescriptionID, model);
				await this.productDescriptionRepository.Update(productDescriptionID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productDescriptionID)
		{
			ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));

			if (response.Success)
			{
				await this.productDescriptionRepository.Delete(productDescriptionID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9ca94283c629c5771149fbfa8fada882</Hash>
</Codenesium>*/