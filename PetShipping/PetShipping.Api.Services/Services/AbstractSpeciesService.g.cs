using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractSpeciesService: AbstractService
	{
		private ISpeciesRepository speciesRepository;
		private IApiSpeciesRequestModelValidator speciesModelValidator;
		private IBOLSpeciesMapper BOLSpeciesMapper;
		private IDALSpeciesMapper DALSpeciesMapper;
		private ILogger logger;

		public AbstractSpeciesService(
			ILogger logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper bolspeciesMapper,
			IDALSpeciesMapper dalspeciesMapper)
			: base()

		{
			this.speciesRepository = speciesRepository;
			this.speciesModelValidator = speciesModelValidator;
			this.BOLSpeciesMapper = bolspeciesMapper;
			this.DALSpeciesMapper = dalspeciesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.speciesRepository.All(skip, take, orderClause);

			return this.BOLSpeciesMapper.MapBOToModel(this.DALSpeciesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpeciesResponseModel> Get(int id)
		{
			var record = await speciesRepository.Get(id);

			return this.BOLSpeciesMapper.MapBOToModel(this.DALSpeciesMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpeciesResponseModel>> Create(
			ApiSpeciesRequestModel model)
		{
			CreateResponse<ApiSpeciesResponseModel> response = new CreateResponse<ApiSpeciesResponseModel>(await this.speciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSpeciesMapper.MapModelToBO(default (int), model);
				var record = await this.speciesRepository.Create(this.DALSpeciesMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSpeciesMapper.MapBOToModel(this.DALSpeciesMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpeciesRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLSpeciesMapper.MapModelToBO(id, model);
				await this.speciesRepository.Update(this.DALSpeciesMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.speciesRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>59390a2dfd7787e56de8eddcd821dadb</Hash>
</Codenesium>*/