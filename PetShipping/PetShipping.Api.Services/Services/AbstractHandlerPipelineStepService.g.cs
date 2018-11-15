using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractHandlerPipelineStepService : AbstractService
	{
		protected IHandlerPipelineStepRepository HandlerPipelineStepRepository { get; private set; }

		protected IApiHandlerPipelineStepServerRequestModelValidator HandlerPipelineStepModelValidator { get; private set; }

		protected IBOLHandlerPipelineStepMapper BolHandlerPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerPipelineStepService(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepServerRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base()
		{
			this.HandlerPipelineStepRepository = handlerPipelineStepRepository;
			this.HandlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.BolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerPipelineStepServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.HandlerPipelineStepRepository.All(limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerPipelineStepServerResponseModel> Get(int id)
		{
			var record = await this.HandlerPipelineStepRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepServerResponseModel>> Create(
			ApiHandlerPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.CreateResponse(await this.HandlerPipelineStepModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(default(int), model);
				var record = await this.HandlerPipelineStepRepository.Create(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				response.SetRecord(this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>> Update(
			int id,
			ApiHandlerPipelineStepServerRequestModel model)
		{
			var validationResult = await this.HandlerPipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(id, model);
				await this.HandlerPipelineStepRepository.Update(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				var record = await this.HandlerPipelineStepRepository.Get(id);

				return ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.UpdateResponse(this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.HandlerPipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.HandlerPipelineStepRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5024e91c526aa86fe8672a20f2f56920</Hash>
</Codenesium>*/