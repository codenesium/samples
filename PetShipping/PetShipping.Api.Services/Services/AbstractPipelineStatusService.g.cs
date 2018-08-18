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
	public abstract class AbstractPipelineStatusService : AbstractService
	{
		protected IPipelineStatusRepository PipelineStatusRepository { get; private set; }

		protected IApiPipelineStatusRequestModelValidator PipelineStatusModelValidator { get; private set; }

		protected IBOLPipelineStatusMapper BolPipelineStatusMapper { get; private set; }

		protected IDALPipelineStatusMapper DalPipelineStatusMapper { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStatusService(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper bolPipelineStatusMapper,
			IDALPipelineStatusMapper dalPipelineStatusMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineStatusRepository = pipelineStatusRepository;
			this.PipelineStatusModelValidator = pipelineStatusModelValidator;
			this.BolPipelineStatusMapper = bolPipelineStatusMapper;
			this.DalPipelineStatusMapper = dalPipelineStatusMapper;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStatusRepository.All(limit, offset);

			return this.BolPipelineStatusMapper.MapBOToModel(this.DalPipelineStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStatusResponseModel> Get(int id)
		{
			var record = await this.PipelineStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStatusMapper.MapBOToModel(this.DalPipelineStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStatusResponseModel> response = new CreateResponse<ApiPipelineStatusResponseModel>(await this.PipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStatusMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStatusRepository.Create(this.DalPipelineStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStatusMapper.MapBOToModel(this.DalPipelineStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatusResponseModel>> Update(
			int id,
			ApiPipelineStatusRequestModel model)
		{
			var validationResult = await this.PipelineStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStatusMapper.MapModelToBO(id, model);
				await this.PipelineStatusRepository.Update(this.DalPipelineStatusMapper.MapBOToEF(bo));

				var record = await this.PipelineStatusRepository.Get(id);

				return new UpdateResponse<ApiPipelineStatusResponseModel>(this.BolPipelineStatusMapper.MapBOToModel(this.DalPipelineStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pipeline> records = await this.PipelineStatusRepository.Pipelines(pipelineStatusId, limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ec550e126afb02029007e5da7c15ac73</Hash>
</Codenesium>*/