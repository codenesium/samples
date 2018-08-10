using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBreedService : AbstractService
	{
		protected IBreedRepository BreedRepository { get; private set; }

		protected IApiBreedRequestModelValidator BreedModelValidator { get; private set; }

		protected IBOLBreedMapper BolBreedMapper { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		private ILogger logger;

		public AbstractBreedService(
			ILogger logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
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
		}

		public virtual async Task<List<ApiBreedResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BreedRepository.All(limit, offset);

			return this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBreedResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiBreedResponseModel>> Create(
			ApiBreedRequestModel model)
		{
			CreateResponse<ApiBreedResponseModel> response = new CreateResponse<ApiBreedResponseModel>(await this.BreedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBreedMapper.MapModelToBO(default(int), model);
				var record = await this.BreedRepository.Create(this.DalBreedMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBreedResponseModel>> Update(
			int id,
			ApiBreedRequestModel model)
		{
			var validationResult = await this.BreedModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBreedMapper.MapModelToBO(id, model);
				await this.BreedRepository.Update(this.DalBreedMapper.MapBOToEF(bo));

				var record = await this.BreedRepository.Get(id);

				return new UpdateResponse<ApiBreedResponseModel>(this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBreedResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.BreedModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.BreedRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPetResponseModel>> Pets(int breedId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.BreedRepository.Pets(breedId, limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6d1eb373b08956ff3eb63456d5a7ded1</Hash>
</Codenesium>*/