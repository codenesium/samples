using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBreedService : AbstractService
	{
		private IMediator mediator;

		protected IBreedRepository BreedRepository { get; private set; }

		protected IApiBreedServerRequestModelValidator BreedModelValidator { get; private set; }

		protected IBOLBreedMapper BolBreedMapper { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		private ILogger logger;

		public AbstractBreedService(
			ILogger logger,
			IMediator mediator,
			IBreedRepository breedRepository,
			IApiBreedServerRequestModelValidator breedModelValidator,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base()
		{
			this.BreedRepository = breedRepository;
			this.BreedModelValidator = breedModelValidator;
			this.BolBreedMapper = bolBreedMapper;
			this.DalBreedMapper = dalBreedMapper;
			this.BolPetMapper = bolPetMapper;
			this.DalPetMapper = dalPetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBreedServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BreedRepository.All(limit, offset);

			return this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBreedServerResponseModel> Get(int id)
		{
			var record = await this.BreedRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBreedServerResponseModel>> Create(
			ApiBreedServerRequestModel model)
		{
			CreateResponse<ApiBreedServerResponseModel> response = ValidationResponseFactory<ApiBreedServerResponseModel>.CreateResponse(await this.BreedModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolBreedMapper.MapModelToBO(default(int), model);
				var record = await this.BreedRepository.Create(this.DalBreedMapper.MapBOToEF(bo));

				var businessObject = this.DalBreedMapper.MapEFToBO(record);
				response.SetRecord(this.BolBreedMapper.MapBOToModel(businessObject));
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
				var bo = this.BolBreedMapper.MapModelToBO(id, model);
				await this.BreedRepository.Update(this.DalBreedMapper.MapBOToEF(bo));

				var record = await this.BreedRepository.Get(id);

				var businessObject = this.DalBreedMapper.MapEFToBO(record);
				var apiModel = this.BolBreedMapper.MapBOToModel(businessObject);
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

		public async virtual Task<List<ApiPetServerResponseModel>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.BreedRepository.PetsByBreedId(breedId, limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e46555a2104450a1f13ef1295a3af626</Hash>
</Codenesium>*/