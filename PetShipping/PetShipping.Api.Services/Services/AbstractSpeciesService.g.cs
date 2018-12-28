using MediatR;
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
		private IMediator mediator;

		protected ISpeciesRepository SpeciesRepository { get; private set; }

		protected IApiSpeciesServerRequestModelValidator SpeciesModelValidator { get; private set; }

		protected IBOLSpeciesMapper BolSpeciesMapper { get; private set; }

		protected IDALSpeciesMapper DalSpeciesMapper { get; private set; }

		protected IBOLBreedMapper BolBreedMapper { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		private ILogger logger;

		public AbstractSpeciesService(
			ILogger logger,
			IMediator mediator,
			ISpeciesRepository speciesRepository,
			IApiSpeciesServerRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolSpeciesMapper,
			IDALSpeciesMapper dalSpeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper)
			: base()
		{
			this.SpeciesRepository = speciesRepository;
			this.SpeciesModelValidator = speciesModelValidator;
			this.BolSpeciesMapper = bolSpeciesMapper;
			this.DalSpeciesMapper = dalSpeciesMapper;
			this.BolBreedMapper = bolBreedMapper;
			this.DalBreedMapper = dalBreedMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpeciesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpeciesRepository.All(limit, offset);

			return this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpeciesServerResponseModel> Get(int id)
		{
			var record = await this.SpeciesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpeciesServerResponseModel>> Create(
			ApiSpeciesServerRequestModel model)
		{
			CreateResponse<ApiSpeciesServerResponseModel> response = ValidationResponseFactory<ApiSpeciesServerResponseModel>.CreateResponse(await this.SpeciesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSpeciesMapper.MapModelToBO(default(int), model);
				var record = await this.SpeciesRepository.Create(this.DalSpeciesMapper.MapBOToEF(bo));

				var businessObject = this.DalSpeciesMapper.MapEFToBO(record);
				response.SetRecord(this.BolSpeciesMapper.MapBOToModel(businessObject));
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
				var bo = this.BolSpeciesMapper.MapModelToBO(id, model);
				await this.SpeciesRepository.Update(this.DalSpeciesMapper.MapBOToEF(bo));

				var record = await this.SpeciesRepository.Get(id);

				var businessObject = this.DalSpeciesMapper.MapEFToBO(record);
				var apiModel = this.BolSpeciesMapper.MapBOToModel(businessObject);
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

			return this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a3c8cf800cf82e4e4eb86dfc7f09623f</Hash>
</Codenesium>*/