using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOSale: AbstractBOManager
	{
		private ISaleRepository saleRepository;
		private IApiSaleRequestModelValidator saleModelValidator;
		private IBOLSaleMapper saleMapper;
		private ILogger logger;

		public AbstractBOSale(
			ILogger logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper saleMapper)
			: base()

		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.saleMapper = saleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.saleRepository.All(skip, take, orderClause);

			return this.saleMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSaleResponseModel> Get(int id)
		{
			var record = await saleRepository.Get(id);

			return this.saleMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model)
		{
			CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.saleMapper.MapModelToDTO(default (int), model);
				var record = await this.saleRepository.Create(dto);

				response.SetRecord(this.saleMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSaleRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.saleMapper.MapModelToDTO(id, model);
				await this.saleRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.saleRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d0479450a19d0163ed4ad22950cdd5dd</Hash>
</Codenesium>*/