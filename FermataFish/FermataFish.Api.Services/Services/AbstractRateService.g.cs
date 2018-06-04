using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractRateService: AbstractService
	{
		private IRateRepository rateRepository;
		private IApiRateRequestModelValidator rateModelValidator;
		private IBOLRateMapper BOLRateMapper;
		private IDALRateMapper DALRateMapper;
		private ILogger logger;

		public AbstractRateService(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateRequestModelValidator rateModelValidator,
			IBOLRateMapper bolrateMapper,
			IDALRateMapper dalrateMapper)
			: base()

		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
			this.BOLRateMapper = bolrateMapper;
			this.DALRateMapper = dalrateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.rateRepository.All(skip, take, orderClause);

			return this.BOLRateMapper.MapBOToModel(this.DALRateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRateResponseModel> Get(int id)
		{
			var record = await rateRepository.Get(id);

			return this.BOLRateMapper.MapBOToModel(this.DALRateMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiRateResponseModel>> Create(
			ApiRateRequestModel model)
		{
			CreateResponse<ApiRateResponseModel> response = new CreateResponse<ApiRateResponseModel>(await this.rateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLRateMapper.MapModelToBO(default (int), model);
				var record = await this.rateRepository.Create(this.DALRateMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLRateMapper.MapBOToModel(this.DALRateMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiRateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLRateMapper.MapModelToBO(id, model);
				await this.rateRepository.Update(this.DALRateMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.rateRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a297e705d3b81cc95fb1c7cab0e0a34a</Hash>
</Codenesium>*/