using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineService : AbstractService
	{
		protected IPipelineRepository PipelineRepository { get; private set; }

		protected IApiPipelineServerRequestModelValidator PipelineModelValidator { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineService(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineServerRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineRepository = pipelineRepository;
			this.PipelineModelValidator = pipelineModelValidator;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineRepository.All(limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineServerResponseModel> Get(int id)
		{
			var record = await this.PipelineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineServerResponseModel>> Create(
			ApiPipelineServerRequestModel model)
		{
			CreateResponse<ApiPipelineServerResponseModel> response = ValidationResponseFactory<ApiPipelineServerResponseModel>.CreateResponse(await this.PipelineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineRepository.Create(this.DalPipelineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineServerResponseModel>> Update(
			int id,
			ApiPipelineServerRequestModel model)
		{
			var validationResult = await this.PipelineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(id, model);
				await this.PipelineRepository.Update(this.DalPipelineMapper.MapBOToEF(bo));

				var record = await this.PipelineRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineServerResponseModel>.UpdateResponse(this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ab1e2a7f78fec60027d2615cf15adf9d</Hash>
</Codenesium>*/