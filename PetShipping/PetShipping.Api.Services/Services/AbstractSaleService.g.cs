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

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractSaleService: AbstractService
	{
		private ISaleRepository saleRepository;
		private IApiSaleRequestModelValidator saleModelValidator;
		private IBOLSaleMapper BOLSaleMapper;
		private IDALSaleMapper DALSaleMapper;
		private ILogger logger;

		public AbstractSaleService(
			ILogger logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolsaleMapper,
			IDALSaleMapper dalsaleMapper)
			: base()

		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.BOLSaleMapper = bolsaleMapper;
			this.DALSaleMapper = dalsaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.saleRepository.All(skip, take, orderClause);

			return this.BOLSaleMapper.MapBOToModel(this.DALSaleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleResponseModel> Get(int id)
		{
			var record = await saleRepository.Get(id);

			return this.BOLSaleMapper.MapBOToModel(this.DALSaleMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model)
		{
			CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSaleMapper.MapModelToBO(default (int), model);
				var record = await this.saleRepository.Create(this.DALSaleMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSaleMapper.MapBOToModel(this.DALSaleMapper.MapEFToBO(record)));
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
				var bo = this.BOLSaleMapper.MapModelToBO(id, model);
				await this.saleRepository.Update(this.DALSaleMapper.MapBOToEF(bo));
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
    <Hash>f7b5b23498ac07c600654a34087a04e0</Hash>
</Codenesium>*/