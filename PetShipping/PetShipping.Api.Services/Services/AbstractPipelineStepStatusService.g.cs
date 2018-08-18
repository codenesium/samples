using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepStatusService : AbstractService
	{
		protected IPipelineStepStatusRepository PipelineStepStatusRepository { get; private set; }

		protected IApiPipelineStepStatusRequestModelValidator PipelineStepStatusModelValidator { get; private set; }

		protected IBOLPipelineStepStatusMapper BolPipelineStepStatusMapper { get; private set; }

		protected IDALPipelineStepStatusMapper DalPipelineStepStatusMapper { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStatusService(
			ILogger logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
			IBOLPipelineStepStatusMapper bolPipelineStepStatusMapper,
			IDALPipelineStepStatusMapper dalPipelineStepStatusMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base()
		{
			this.PipelineStepStatusRepository = pipelineStepStatusRepository;
			this.PipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.BolPipelineStepStatusMapper = bolPipelineStepStatusMapper;
			this.DalPipelineStepStatusMapper = dalPipelineStepStatusMapper;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepStatusRepository.All(limit, offset);

			return this.BolPipelineStepStatusMapper.MapBOToModel(this.DalPipelineStepStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> Get(int id)
		{
			var record = await this.PipelineStepStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepStatusMapper.MapBOToModel(this.DalPipelineStepStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
			ApiPipelineStepStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatusResponseModel> response = new CreateResponse<ApiPipelineStepStatusResponseModel>(await this.PipelineStepStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStepStatusMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepStatusRepository.Create(this.DalPipelineStepStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepStatusMapper.MapBOToModel(this.DalPipelineStepStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStatusResponseModel>> Update(
			int id,
			ApiPipelineStepStatusRequestModel model)
		{
			var validationResult = await this.PipelineStepStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepStatusMapper.MapModelToBO(id, model);
				await this.PipelineStepStatusRepository.Update(this.DalPipelineStepStatusMapper.MapBOToEF(bo));

				var record = await this.PipelineStepStatusRepository.Get(id);

				return new UpdateResponse<ApiPipelineStepStatusResponseModel>(this.BolPipelineStepStatusMapper.MapBOToModel(this.DalPipelineStepStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStepStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStepStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStepStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.PipelineStepStatusRepository.PipelineSteps(pipelineStepStatusId, limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>82dbb4a2c84541fcc2283fba853fac51</Hash>
</Codenesium>*/