using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPersonPhoneService: AbstractService
	{
		private IPersonPhoneRepository personPhoneRepository;
		private IApiPersonPhoneRequestModelValidator personPhoneModelValidator;
		private IBOLPersonPhoneMapper BOLPersonPhoneMapper;
		private IDALPersonPhoneMapper DALPersonPhoneMapper;
		private ILogger logger;

		public AbstractPersonPhoneService(
			ILogger logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper bolpersonPhoneMapper,
			IDALPersonPhoneMapper dalpersonPhoneMapper)
			: base()

		{
			this.personPhoneRepository = personPhoneRepository;
			this.personPhoneModelValidator = personPhoneModelValidator;
			this.BOLPersonPhoneMapper = bolpersonPhoneMapper;
			this.DALPersonPhoneMapper = dalpersonPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personPhoneRepository.All(skip, take, orderClause);

			return this.BOLPersonPhoneMapper.MapBOToModel(this.DALPersonPhoneMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonPhoneResponseModel> Get(int businessEntityID)
		{
			var record = await personPhoneRepository.Get(businessEntityID);

			return this.BOLPersonPhoneMapper.MapBOToModel(this.DALPersonPhoneMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model)
		{
			CreateResponse<ApiPersonPhoneResponseModel> response = new CreateResponse<ApiPersonPhoneResponseModel>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPersonPhoneMapper.MapModelToBO(default (int), model);
				var record = await this.personPhoneRepository.Create(this.DALPersonPhoneMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPersonPhoneMapper.MapBOToModel(this.DALPersonPhoneMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonPhoneRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLPersonPhoneMapper.MapModelToBO(businessEntityID, model);
				await this.personPhoneRepository.Update(this.DALPersonPhoneMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.personPhoneRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiPersonPhoneResponseModel>> GetPhoneNumber(string phoneNumber)
		{
			List<PersonPhone> records = await this.personPhoneRepository.GetPhoneNumber(phoneNumber);

			return this.BOLPersonPhoneMapper.MapBOToModel(this.DALPersonPhoneMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d88b0596f347c6f1ae0f5a58d50fe109</Hash>
</Codenesium>*/