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
	public abstract class AbstractPetService: AbstractService
	{
		private IPetRepository petRepository;
		private IApiPetRequestModelValidator petModelValidator;
		private IBOLPetMapper BOLPetMapper;
		private IDALPetMapper DALPetMapper;
		private ILogger logger;

		public AbstractPetService(
			ILogger logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper bolpetMapper,
			IDALPetMapper dalpetMapper)
			: base()

		{
			this.petRepository = petRepository;
			this.petModelValidator = petModelValidator;
			this.BOLPetMapper = bolpetMapper;
			this.DALPetMapper = dalpetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.petRepository.All(skip, take, orderClause);

			return this.BOLPetMapper.MapBOToModel(this.DALPetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPetResponseModel> Get(int id)
		{
			var record = await petRepository.Get(id);

			return this.BOLPetMapper.MapBOToModel(this.DALPetMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPetResponseModel>> Create(
			ApiPetRequestModel model)
		{
			CreateResponse<ApiPetResponseModel> response = new CreateResponse<ApiPetResponseModel>(await this.petModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPetMapper.MapModelToBO(default (int), model);
				var record = await this.petRepository.Create(this.DALPetMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPetMapper.MapBOToModel(this.DALPetMapper.MapEFToBO(record)));
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
				var bo = this.BOLPetMapper.MapModelToBO(id, model);
				await this.petRepository.Update(this.DALPetMapper.MapBOToEF(bo));
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
    <Hash>8639a7b538e1121303b13991bd17a8dc</Hash>
</Codenesium>*/