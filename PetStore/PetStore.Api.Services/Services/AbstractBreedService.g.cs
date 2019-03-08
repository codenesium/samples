using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBreedService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IBreedRepository BreedRepository { get; private set; }

		protected IApiBreedServerRequestModelValidator BreedModelValidator { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		private ILogger logger;

		public AbstractBreedService(
			ILogger logger,
			MediatR.IMediator mediator,
			IBreedRepository breedRepository,
			IApiBreedServerRequestModelValidator breedModelValidator,
			IDALBreedMapper dalBreedMapper,
			IDALPetMapper dalPetMapper)
			: base()
		{
			this.BreedRepository = breedRepository;
			this.BreedModelValidator = breedModelValidator;
			this.DalBreedMapper = dalBreedMapper;
			this.DalPetMapper = dalPetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBreedServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Breed> records = await this.BreedRepository.All(limit, offset, query);

			return this.DalBreedMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiBreedServerResponseModel> Get(int id)
		{
			Breed record = await this.BreedRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBreedMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBreedServerResponseModel>> Create(
			ApiBreedServerRequestModel model)
		{
			CreateResponse<ApiBreedServerResponseModel> response = ValidationResponseFactory<ApiBreedServerResponseModel>.CreateResponse(await this.BreedModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Breed record = this.DalBreedMapper.MapModelToEntity(default(int), model);
				record = await this.BreedRepository.Create(record);

				response.SetRecord(this.DalBreedMapper.MapEntityToModel(record));
				await this.mediator.Publish(new BreedCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBreedServerResponseModel>> Update(
			int id,
			ApiBreedServerRequestModel model)
		{
			var validationResult = await this.BreedModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Breed record = this.DalBreedMapper.MapModelToEntity(id, model);
				await this.BreedRepository.Update(record);

				record = await this.BreedRepository.Get(id);

				ApiBreedServerResponseModel apiModel = this.DalBreedMapper.MapEntityToModel(record);
				await this.mediator.Publish(new BreedUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBreedServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiBreedServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BreedModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.BreedRepository.Delete(id);

				await this.mediator.Publish(new BreedDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBreedServerResponseModel>> BySpeciesId(int speciesId, int limit = 0, int offset = int.MaxValue)
		{
			List<Breed> records = await this.BreedRepository.BySpeciesId(speciesId, limit, offset);

			return this.DalBreedMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPetServerResponseModel>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.BreedRepository.PetsByBreedId(breedId, limit, offset);

			return this.DalPetMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>b8d67452d939e8ff1a83fd9a2c342ac1</Hash>
</Codenesium>*/