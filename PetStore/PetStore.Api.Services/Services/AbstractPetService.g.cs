using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractPetService : AbstractService
	{
		protected IPetRepository PetRepository { get; private set; }

		protected IApiPetServerRequestModelValidator PetModelValidator { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractPetService(
			ILogger logger,
			IPetRepository petRepository,
			IApiPetServerRequestModelValidator petModelValidator,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.PetRepository = petRepository;
			this.PetModelValidator = petModelValidator;
			this.BolPetMapper = bolPetMapper;
			this.DalPetMapper = dalPetMapper;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PetRepository.All(limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPetServerResponseModel> Get(int id)
		{
			var record = await this.PetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPetServerResponseModel>> Create(
			ApiPetServerRequestModel model)
		{
			CreateResponse<ApiPetServerResponseModel> response = ValidationResponseFactory<ApiPetServerResponseModel>.CreateResponse(await this.PetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPetMapper.MapModelToBO(default(int), model);
				var record = await this.PetRepository.Create(this.DalPetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record)));
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
				var bo = this.BolPetMapper.MapModelToBO(id, model);
				await this.PetRepository.Update(this.DalPetMapper.MapBOToEF(bo));

				var record = await this.PetRepository.Get(id);

				return ValidationResponseFactory<ApiPetServerResponseModel>.UpdateResponse(this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiSaleServerResponseModel>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.PetRepository.SalesByPetId(petId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b3b2f171dd8e6eaa7bc9c788658cd4b7</Hash>
</Codenesium>*/