using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractInterruptionService : AbstractService
	{
		protected IInterruptionRepository InterruptionRepository { get; private set; }

		protected IApiInterruptionRequestModelValidator InterruptionModelValidator { get; private set; }

		protected IBOLInterruptionMapper BolInterruptionMapper { get; private set; }

		protected IDALInterruptionMapper DalInterruptionMapper { get; private set; }

		private ILogger logger;

		public AbstractInterruptionService(
			ILogger logger,
			IInterruptionRepository interruptionRepository,
			IApiInterruptionRequestModelValidator interruptionModelValidator,
			IBOLInterruptionMapper bolInterruptionMapper,
			IDALInterruptionMapper dalInterruptionMapper)
			: base()
		{
			this.InterruptionRepository = interruptionRepository;
			this.InterruptionModelValidator = interruptionModelValidator;
			this.BolInterruptionMapper = bolInterruptionMapper;
			this.DalInterruptionMapper = dalInterruptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiInterruptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.InterruptionRepository.All(limit, offset);

			return this.BolInterruptionMapper.MapBOToModel(this.DalInterruptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiInterruptionResponseModel> Get(string id)
		{
			var record = await this.InterruptionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolInterruptionMapper.MapBOToModel(this.DalInterruptionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiInterruptionResponseModel>> Create(
			ApiInterruptionRequestModel model)
		{
			CreateResponse<ApiInterruptionResponseModel> response = new CreateResponse<ApiInterruptionResponseModel>(await this.InterruptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolInterruptionMapper.MapModelToBO(default(string), model);
				var record = await this.InterruptionRepository.Create(this.DalInterruptionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolInterruptionMapper.MapBOToModel(this.DalInterruptionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiInterruptionResponseModel>> Update(
			string id,
			ApiInterruptionRequestModel model)
		{
			var validationResult = await this.InterruptionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolInterruptionMapper.MapModelToBO(id, model);
				await this.InterruptionRepository.Update(this.DalInterruptionMapper.MapBOToEF(bo));

				var record = await this.InterruptionRepository.Get(id);

				return new UpdateResponse<ApiInterruptionResponseModel>(this.BolInterruptionMapper.MapBOToModel(this.DalInterruptionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiInterruptionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.InterruptionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.InterruptionRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiInterruptionResponseModel>> ByTenantId(string tenantId)
		{
			List<Interruption> records = await this.InterruptionRepository.ByTenantId(tenantId);

			return this.BolInterruptionMapper.MapBOToModel(this.DalInterruptionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>31a5e331dea48f47e52d1d3c1d5f53c5</Hash>
</Codenesium>*/