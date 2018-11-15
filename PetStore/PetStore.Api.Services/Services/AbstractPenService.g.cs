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
		protected IPenRepository PenRepository { get; private set; }

		protected IApiPenServerRequestModelValidator PenModelValidator { get; private set; }

		protected IBOLPenMapper BolPenMapper { get; private set; }

		protected IDALPenMapper DalPenMapper { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		private ILogger logger;

		public AbstractPenService(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenServerRequestModelValidator penModelValidator,
			IBOLPenMapper bolPenMapper,
			IDALPenMapper dalPenMapper,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper)
			: base()
		{
			this.PenRepository = penRepository;
			this.PenModelValidator = penModelValidator;
			this.BolPenMapper = bolPenMapper;
			this.DalPenMapper = dalPenMapper;
			this.BolPetMapper = bolPetMapper;
			this.DalPetMapper = dalPetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPenServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PenRepository.All(limit, offset);

			return this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPenServerResponseModel> Get(int id)
		{
			var record = await this.PenRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPenServerResponseModel>> Create(
			ApiPenServerRequestModel model)
		{
			CreateResponse<ApiPenServerResponseModel> response = ValidationResponseFactory<ApiPenServerResponseModel>.CreateResponse(await this.PenModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPenMapper.MapModelToBO(default(int), model);
				var record = await this.PenRepository.Create(this.DalPenMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(record)));
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
				var bo = this.BolPenMapper.MapModelToBO(id, model);
				await this.PenRepository.Update(this.DalPenMapper.MapBOToEF(bo));

				var record = await this.PenRepository.Get(id);

				return ValidationResponseFactory<ApiPenServerResponseModel>.UpdateResponse(this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiPetServerResponseModel>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.PenRepository.PetsByPenId(penId, limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e592ed61101471177ff26d6234c89ebc</Hash>
</Codenesium>*/