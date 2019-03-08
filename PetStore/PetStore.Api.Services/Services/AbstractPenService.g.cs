using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractPenService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPenRepository PenRepository { get; private set; }

		protected IApiPenServerRequestModelValidator PenModelValidator { get; private set; }

		protected IDALPenMapper DalPenMapper { get; private set; }

		private ILogger logger;

		public AbstractPenService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPenRepository penRepository,
			IApiPenServerRequestModelValidator penModelValidator,
			IDALPenMapper dalPenMapper)
			: base()
		{
			this.PenRepository = penRepository;
			this.PenModelValidator = penModelValidator;
			this.DalPenMapper = dalPenMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPenServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Pen> records = await this.PenRepository.All(limit, offset, query);

			return this.DalPenMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPenServerResponseModel> Get(int id)
		{
			Pen record = await this.PenRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPenMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPenServerResponseModel>> Create(
			ApiPenServerRequestModel model)
		{
			CreateResponse<ApiPenServerResponseModel> response = ValidationResponseFactory<ApiPenServerResponseModel>.CreateResponse(await this.PenModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Pen record = this.DalPenMapper.MapModelToEntity(default(int), model);
				record = await this.PenRepository.Create(record);

				response.SetRecord(this.DalPenMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PenCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPenServerResponseModel>> Update(
			int id,
			ApiPenServerRequestModel model)
		{
			var validationResult = await this.PenModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Pen record = this.DalPenMapper.MapModelToEntity(id, model);
				await this.PenRepository.Update(record);

				record = await this.PenRepository.Get(id);

				ApiPenServerResponseModel apiModel = this.DalPenMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PenUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPenServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPenServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PenModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PenRepository.Delete(id);

				await this.mediator.Publish(new PenDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3670255dd7c3244c7540f2a89530864f</Hash>
</Codenesium>*/