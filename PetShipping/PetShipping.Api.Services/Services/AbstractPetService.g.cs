using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPetService : AbstractService
	{
		private IMediator mediator;

		protected IPetRepository PetRepository { get; private set; }

		protected IApiPetServerRequestModelValidator PetModelValidator { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractPetService(
			ILogger logger,
			IMediator mediator,
			IPetRepository petRepository,
			IApiPetServerRequestModelValidator petModelValidator,
			IDALPetMapper dalPetMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.PetRepository = petRepository;
			this.PetModelValidator = petModelValidator;
			this.DalPetMapper = dalPetMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Pet> records = await this.PetRepository.All(limit, offset, query);

			return this.DalPetMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPetServerResponseModel> Get(int id)
		{
			Pet record = await this.PetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPetMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPetServerResponseModel>> Create(
			ApiPetServerRequestModel model)
		{
			CreateResponse<ApiPetServerResponseModel> response = ValidationResponseFactory<ApiPetServerResponseModel>.CreateResponse(await this.PetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Pet record = this.DalPetMapper.MapModelToEntity(default(int), model);
				record = await this.PetRepository.Create(record);

				response.SetRecord(this.DalPetMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PetCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPetServerResponseModel>> Update(
			int id,
			ApiPetServerRequestModel model)
		{
			var validationResult = await this.PetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Pet record = this.DalPetMapper.MapModelToEntity(id, model);
				await this.PetRepository.Update(record);

				record = await this.PetRepository.Get(id);

				ApiPetServerResponseModel apiModel = this.DalPetMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PetUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPetServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PetModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PetRepository.Delete(id);

				await this.mediator.Publish(new PetDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSaleServerResponseModel>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.PetRepository.SalesByPetId(petId, limit, offset);

			return this.DalSaleMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>35ad1ed75cb3c94094c394505b2df681</Hash>
</Codenesium>*/