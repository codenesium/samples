using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractCompositePrimaryKeyService : AbstractService
	{
		private IMediator mediator;

		protected ICompositePrimaryKeyRepository CompositePrimaryKeyRepository { get; private set; }

		protected IApiCompositePrimaryKeyServerRequestModelValidator CompositePrimaryKeyModelValidator { get; private set; }

		protected IBOLCompositePrimaryKeyMapper BolCompositePrimaryKeyMapper { get; private set; }

		protected IDALCompositePrimaryKeyMapper DalCompositePrimaryKeyMapper { get; private set; }

		private ILogger logger;

		public AbstractCompositePrimaryKeyService(
			ILogger logger,
			IMediator mediator,
			ICompositePrimaryKeyRepository compositePrimaryKeyRepository,
			IApiCompositePrimaryKeyServerRequestModelValidator compositePrimaryKeyModelValidator,
			IBOLCompositePrimaryKeyMapper bolCompositePrimaryKeyMapper,
			IDALCompositePrimaryKeyMapper dalCompositePrimaryKeyMapper)
			: base()
		{
			this.CompositePrimaryKeyRepository = compositePrimaryKeyRepository;
			this.CompositePrimaryKeyModelValidator = compositePrimaryKeyModelValidator;
			this.BolCompositePrimaryKeyMapper = bolCompositePrimaryKeyMapper;
			this.DalCompositePrimaryKeyMapper = dalCompositePrimaryKeyMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCompositePrimaryKeyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CompositePrimaryKeyRepository.All(limit, offset);

			return this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCompositePrimaryKeyServerResponseModel> Get(int id)
		{
			var record = await this.CompositePrimaryKeyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCompositePrimaryKeyMapper.MapBOToModel(this.DalCompositePrimaryKeyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCompositePrimaryKeyServerResponseModel>> Create(
			ApiCompositePrimaryKeyServerRequestModel model)
		{
			CreateResponse<ApiCompositePrimaryKeyServerResponseModel> response = ValidationResponseFactory<ApiCompositePrimaryKeyServerResponseModel>.CreateResponse(await this.CompositePrimaryKeyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCompositePrimaryKeyMapper.MapModelToBO(default(int), model);
				var record = await this.CompositePrimaryKeyRepository.Create(this.DalCompositePrimaryKeyMapper.MapBOToEF(bo));

				var businessObject = this.DalCompositePrimaryKeyMapper.MapEFToBO(record);
				response.SetRecord(this.BolCompositePrimaryKeyMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new CompositePrimaryKeyCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCompositePrimaryKeyServerResponseModel>> Update(
			int id,
			ApiCompositePrimaryKeyServerRequestModel model)
		{
			var validationResult = await this.CompositePrimaryKeyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCompositePrimaryKeyMapper.MapModelToBO(id, model);
				await this.CompositePrimaryKeyRepository.Update(this.DalCompositePrimaryKeyMapper.MapBOToEF(bo));

				var record = await this.CompositePrimaryKeyRepository.Get(id);

				var businessObject = this.DalCompositePrimaryKeyMapper.MapEFToBO(record);
				var apiModel = this.BolCompositePrimaryKeyMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new CompositePrimaryKeyUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCompositePrimaryKeyServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCompositePrimaryKeyServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CompositePrimaryKeyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CompositePrimaryKeyRepository.Delete(id);

				await this.mediator.Publish(new CompositePrimaryKeyDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>92f92287f3616fc7723bdeeb7da153b0</Hash>
</Codenesium>*/