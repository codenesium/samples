using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBreedService: AbstractService
	{
		private IBreedRepository breedRepository;
		private IApiBreedRequestModelValidator breedModelValidator;
		private IBOLBreedMapper BOLBreedMapper;
		private IDALBreedMapper DALBreedMapper;
		private ILogger logger;

		public AbstractBreedService(
			ILogger logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
			IBOLBreedMapper bolbreedMapper,
			IDALBreedMapper dalbreedMapper)
			: base()

		{
			this.breedRepository = breedRepository;
			this.breedModelValidator = breedModelValidator;
			this.BOLBreedMapper = bolbreedMapper;
			this.DALBreedMapper = dalbreedMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBreedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.breedRepository.All(skip, take, orderClause);

			return this.BOLBreedMapper.MapBOToModel(this.DALBreedMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBreedResponseModel> Get(int id)
		{
			var record = await breedRepository.Get(id);

			return this.BOLBreedMapper.MapBOToModel(this.DALBreedMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBreedResponseModel>> Create(
			ApiBreedRequestModel model)
		{
			CreateResponse<ApiBreedResponseModel> response = new CreateResponse<ApiBreedResponseModel>(await this.breedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBreedMapper.MapModelToBO(default (int), model);
				var record = await this.breedRepository.Create(this.DALBreedMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBreedMapper.MapBOToModel(this.DALBreedMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiBreedRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLBreedMapper.MapModelToBO(id, model);
				await this.breedRepository.Update(this.DALBreedMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.breedRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>834a6a0a571b472e0d64f6cae9297889</Hash>
</Codenesium>*/