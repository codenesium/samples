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

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOSpecies: AbstractBOManager
	{
		private ISpeciesRepository speciesRepository;
		private IApiSpeciesRequestModelValidator speciesModelValidator;
		private IBOLSpeciesMapper speciesMapper;
		private ILogger logger;

		public AbstractBOSpecies(
			ILogger logger,
			ISpeciesRepository speciesRepository,
			IApiSpeciesRequestModelValidator speciesModelValidator,
			IBOLSpeciesMapper speciesMapper)
			: base()

		{
			this.speciesRepository = speciesRepository;
			this.speciesModelValidator = speciesModelValidator;
			this.speciesMapper = speciesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpeciesResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.speciesRepository.All(skip, take, orderClause);

			return this.speciesMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpeciesResponseModel> Get(int id)
		{
			var record = await speciesRepository.Get(id);

			return this.speciesMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpeciesResponseModel>> Create(
			ApiSpeciesRequestModel model)
		{
			CreateResponse<ApiSpeciesResponseModel> response = new CreateResponse<ApiSpeciesResponseModel>(await this.speciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.speciesMapper.MapModelToDTO(default (int), model);
				var record = await this.speciesRepository.Create(dto);

				response.SetRecord(this.speciesMapper.MapDTOToModel(record));
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
				var dto = this.speciesMapper.MapModelToDTO(id, model);
				await this.speciesRepository.Update(id, dto);
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
    <Hash>195183b277eb0fea46af782ba63f42f1</Hash>
</Codenesium>*/