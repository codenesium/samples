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
	public abstract class AbstractBOAirline: AbstractBOManager
	{
		private IAirlineRepository airlineRepository;
		private IApiAirlineRequestModelValidator airlineModelValidator;
		private IBOLAirlineMapper airlineMapper;
		private ILogger logger;

		public AbstractBOAirline(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IApiAirlineRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper airlineMapper)
			: base()

		{
			this.airlineRepository = airlineRepository;
			this.airlineModelValidator = airlineModelValidator;
			this.airlineMapper = airlineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAirlineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.airlineRepository.All(skip, take, orderClause);

			return this.airlineMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAirlineResponseModel> Get(int id)
		{
			var record = await airlineRepository.Get(id);

			return this.airlineMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAirlineResponseModel>> Create(
			ApiAirlineRequestModel model)
		{
			CreateResponse<ApiAirlineResponseModel> response = new CreateResponse<ApiAirlineResponseModel>(await this.airlineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.airlineMapper.MapModelToDTO(default (int), model);
				var record = await this.airlineRepository.Create(dto);

				response.SetRecord(this.airlineMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiAirlineRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.airlineMapper.MapModelToDTO(id, model);
				await this.airlineRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.airlineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>76fe103715be92589f7cba1dbd4590d1</Hash>
</Codenesium>*/