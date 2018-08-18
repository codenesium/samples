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
	public abstract class AbstractPenService : AbstractService
	{
		protected IPenRepository PenRepository { get; private set; }

		protected IApiPenRequestModelValidator PenModelValidator { get; private set; }

		protected IBOLPenMapper BolPenMapper { get; private set; }

		protected IDALPenMapper DalPenMapper { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		private ILogger logger;

		public AbstractPenService(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
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

		public virtual async Task<List<ApiPenResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PenRepository.All(limit, offset);

			return this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPenResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model)
		{
			CreateResponse<ApiPenResponseModel> response = new CreateResponse<ApiPenResponseModel>(await this.PenModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPenMapper.MapModelToBO(default(int), model);
				var record = await this.PenRepository.Create(this.DalPenMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPenResponseModel>> Update(
			int id,
			ApiPenRequestModel model)
		{
			var validationResult = await this.PenModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPenMapper.MapModelToBO(id, model);
				await this.PenRepository.Update(this.DalPenMapper.MapBOToEF(bo));

				var record = await this.PenRepository.Get(id);

				return new UpdateResponse<ApiPenResponseModel>(this.BolPenMapper.MapBOToModel(this.DalPenMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPenResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PenModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PenRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPetResponseModel>> Pets(int penId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pet> records = await this.PenRepository.Pets(penId, limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a74c7085af4d664f33b443f91345f44f</Hash>
</Codenesium>*/