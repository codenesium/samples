using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractSpeciesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISpeciesRepository SpeciesRepository { get; private set; }

		protected IApiSpeciesServerRequestModelValidator SpeciesModelValidator { get; private set; }

		protected IDALSpeciesMapper DalSpeciesMapper { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		private ILogger logger;

		public AbstractSpeciesService(
			ILogger logger,
			MediatR.IMediator mediator,
			ISpeciesRepository speciesRepository,
			IApiSpeciesServerRequestModelValidator speciesModelValidator,
			IDALSpeciesMapper dalSpeciesMapper,
			IDALBreedMapper dalBreedMapper)
			: base()
		{
			this.SpeciesRepository = speciesRepository;
			this.SpeciesModelValidator = speciesModelValidator;
			this.DalSpeciesMapper = dalSpeciesMapper;
			this.DalBreedMapper = dalBreedMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpeciesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Species> records = await this.SpeciesRepository.All(limit, offset, query);

			return this.DalSpeciesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSpeciesServerResponseModel> Get(int id)
		{
			Species record = await this.SpeciesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpeciesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpeciesServerResponseModel>> Create(
			ApiSpeciesServerRequestModel model)
		{
			CreateResponse<ApiSpeciesServerResponseModel> response = ValidationResponseFactory<ApiSpeciesServerResponseModel>.CreateResponse(await this.SpeciesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Species record = this.DalSpeciesMapper.MapModelToEntity(default(int), model);
				record = await this.SpeciesRepository.Create(record);

				response.SetRecord(this.DalSpeciesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SpeciesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpeciesServerResponseModel>> Update(
			int id,
			ApiSpeciesServerRequestModel model)
		{
			var validationResult = await this.SpeciesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Species record = this.DalSpeciesMapper.MapModelToEntity(id, model);
				await this.SpeciesRepository.Update(record);

				record = await this.SpeciesRepository.Get(id);

				ApiSpeciesServerResponseModel apiModel = this.DalSpeciesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SpeciesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSpeciesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSpeciesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpeciesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SpeciesRepository.Delete(id);

				await this.mediator.Publish(new SpeciesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBreedServerResponseModel>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0)
		{
			List<Breed> records = await this.SpeciesRepository.BreedsBySpeciesId(speciesId, limit, offset);

			return this.DalBreedMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>3089aa31c90d76b97d16e9db0d86b754</Hash>
</Codenesium>*/