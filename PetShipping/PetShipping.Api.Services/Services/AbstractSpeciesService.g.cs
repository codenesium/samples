using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractSpeciesService : AbstractService
	{
		protected ISpeciesRepository SpeciesRepository { get; private set; }

		protected IApiSpeciesRequestModelValidator SpeciesModelValidator { get; private set; }

		protected IBOLSpeciesMapper BolSpeciesMapper { get; private set; }

		protected IDALSpeciesMapper DalSpeciesMapper { get; private set; }

		protected IBOLBreedMapper BolBreedMapper { get; private set; }

		protected IDALBreedMapper DalBreedMapper { get; private set; }

		private ILogger logger;

		public AbstractSpeciesService(
			ILogger logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolSpeciesMapper,
			IDALSpeciesMapper dalSpeciesMapper,
			IBOLBreedMapper bolBreedMapper,
			IDALBreedMapper dalBreedMapper)
			: base()
		{
			this.SpeciesRepository = speciesRepository;
			this.SpeciesModelValidator = speciesModelValidator;
			this.BolSpeciesMapper = bolSpeciesMapper;
			this.DalSpeciesMapper = dalSpeciesMapper;
			this.BolBreedMapper = bolBreedMapper;
			this.DalBreedMapper = dalBreedMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpeciesRepository.All(limit, offset);

			return this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpeciesResponseModel> Get(int id)
		{
			var record = await this.SpeciesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpeciesResponseModel>> Create(
			ApiSpeciesRequestModel model)
		{
			CreateResponse<ApiSpeciesResponseModel> response = new CreateResponse<ApiSpeciesResponseModel>(await this.SpeciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpeciesMapper.MapModelToBO(default(int), model);
				var record = await this.SpeciesRepository.Create(this.DalSpeciesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpeciesResponseModel>> Update(
			int id,
			ApiSpeciesRequestModel model)
		{
			var validationResult = await this.SpeciesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpeciesMapper.MapModelToBO(id, model);
				await this.SpeciesRepository.Update(this.DalSpeciesMapper.MapBOToEF(bo));

				var record = await this.SpeciesRepository.Get(id);

				return new UpdateResponse<ApiSpeciesResponseModel>(this.BolSpeciesMapper.MapBOToModel(this.DalSpeciesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpeciesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SpeciesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SpeciesRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiBreedResponseModel>> Breeds(int speciesId, int limit = int.MaxValue, int offset = 0)
		{
			List<Breed> records = await this.SpeciesRepository.Breeds(speciesId, limit, offset);

			return this.BolBreedMapper.MapBOToModel(this.DalBreedMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5d7a42cd506fbd022d4e8b2051e57e5c</Hash>
</Codenesium>*/