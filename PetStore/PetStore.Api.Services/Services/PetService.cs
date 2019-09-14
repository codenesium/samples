using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class PetService : AbstractService, IPetService
	{
		private MediatR.IMediator mediator;

		protected IPetRepository PetRepository { get; private set; }

		protected IApiPetServerRequestModelValidator PetModelValidator { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public PetService(
			ILogger<IPetService> logger,
			MediatR.IMediator mediator,
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
    <Hash>1ba3ccd76f1fa06563bcc9123b00736c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/