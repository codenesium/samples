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
	public abstract class AbstractHandlerPipelineStepService : AbstractService
	{
		protected IHandlerPipelineStepRepository HandlerPipelineStepRepository { get; private set; }

		protected IApiHandlerPipelineStepRequestModelValidator HandlerPipelineStepModelValidator { get; private set; }

		protected IBOLHandlerPipelineStepMapper BolHandlerPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerPipelineStepService(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
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

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.HandlerPipelineStepRepository.All(limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
			ApiHandlerPipelineStepRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepResponseModel> response = new CreateResponse<ApiHandlerPipelineStepResponseModel>(await this.HandlerPipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(default(int), model);
				var record = await this.HandlerPipelineStepRepository.Create(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				response.SetRecord(this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerPipelineStepResponseModel>> Update(
			int id,
			ApiHandlerPipelineStepRequestModel model)
		{
			var validationResult = await this.HandlerPipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(id, model);
				await this.HandlerPipelineStepRepository.Update(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				var record = await this.HandlerPipelineStepRepository.Get(id);

				return new UpdateResponse<ApiHandlerPipelineStepResponseModel>(this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiHandlerPipelineStepResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.HandlerPipelineStepModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.HandlerPipelineStepRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1955338e2234c96076ec725fe6e635c0</Hash>
</Codenesium>*/