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
		private IBOLPersonPhoneMapper bolPersonPhoneMapper;
		private IDALPersonPhoneMapper dalPersonPhoneMapper;
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
			this.bolPersonPhoneMapper = bolpersonPhoneMapper;
			this.dalPersonPhoneMapper = dalpersonPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personPhoneRepository.All(skip, take, orderClause);

			return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonPhoneResponseModel> Get(int businessEntityID)
		{
			var record = await personPhoneRepository.Get(businessEntityID);

			return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model)
		{
			CreateResponse<ApiPersonPhoneResponseModel> response = new CreateResponse<ApiPersonPhoneResponseModel>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPersonPhoneMapper.MapModelToBO(default (int), model);
				var record = await this.personPhoneRepository.Create(this.dalPersonPhoneMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(record)));
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
				var bo = this.bolPersonPhoneMapper.MapModelToBO(businessEntityID, model);
				await this.personPhoneRepository.Update(this.dalPersonPhoneMapper.MapBOToEF(bo));
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

			return this.bolPersonPhoneMapper.MapBOToModel(this.dalPersonPhoneMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4dbb67ea9522997542c91f54b1ca067a</Hash>
</Codenesium>*/