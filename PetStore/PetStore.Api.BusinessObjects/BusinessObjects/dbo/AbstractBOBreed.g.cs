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

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOBreed: AbstractBOManager
	{
		private IBreedRepository breedRepository;
		private IApiBreedRequestModelValidator breedModelValidator;
		private IBOLBreedMapper breedMapper;
		private ILogger logger;

		public AbstractBOBreed(
			ILogger logger,
			IBreedRepository breedRepository,
			IApiBreedRequestModelValidator breedModelValidator,
			IBOLBreedMapper breedMapper)
			: base()

		{
			this.breedRepository = breedRepository;
			this.breedModelValidator = breedModelValidator;
			this.breedMapper = breedMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBreedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.breedRepository.All(skip, take, orderClause);

			return this.breedMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBreedResponseModel> Get(int id)
		{
			var record = await breedRepository.Get(id);

			return this.breedMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBreedResponseModel>> Create(
			ApiBreedRequestModel model)
		{
			CreateResponse<ApiBreedResponseModel> response = new CreateResponse<ApiBreedResponseModel>(await this.breedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.breedMapper.MapModelToDTO(default (int), model);
				var record = await this.breedRepository.Create(dto);

				response.SetRecord(this.breedMapper.MapDTOToModel(record));
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
				var dto = this.breedMapper.MapModelToDTO(id, model);
				await this.breedRepository.Update(id, dto);
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
    <Hash>0ca80f6de0a70f6884a01c0e16f278d4</Hash>
</Codenesium>*/