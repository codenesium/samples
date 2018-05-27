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
	public abstract class AbstractBOPet: AbstractBOManager
	{
		private IPetRepository petRepository;
		private IApiPetRequestModelValidator petModelValidator;
		private IBOLPetMapper petMapper;
		private ILogger logger;

		public AbstractBOPet(
			ILogger logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper petMapper)
			: base()

		{
			this.petRepository = petRepository;
			this.petModelValidator = petModelValidator;
			this.petMapper = petMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.petRepository.All(skip, take, orderClause);

			return this.petMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPetResponseModel> Get(int id)
		{
			var record = await petRepository.Get(id);

			return this.petMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPetResponseModel>> Create(
			ApiPetRequestModel model)
		{
			CreateResponse<ApiPetResponseModel> response = new CreateResponse<ApiPetResponseModel>(await this.petModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.petMapper.MapModelToDTO(default (int), model);
				var record = await this.petRepository.Create(dto);

				response.SetRecord(this.petMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPetRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.petMapper.MapModelToDTO(id, model);
				await this.petRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.petRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1e9e743fe33a0cff53bb5cbcba62cd0d</Hash>
</Codenesium>*/