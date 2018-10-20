using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiVEventRequestModelValidator : AbstractValidator<ApiVEventRequestModel>
	{
		private int existingRecordId;

		private IVEventRepository vEventRepository;

		public AbstractApiVEventRequestModelValidator(IVEventRepository vEventRepository)
		{
			this.vEventRepository = vEventRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVEventRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActualEndDateRules()
		{
		}

		public virtual void ActualStartDateRules()
		{
		}

		public virtual void BillAmountRules()
		{
		}

		public virtual void EventStatusIdRules()
		{
		}

		public virtual void ScheduledEndDateRules()
		{
		}

		public virtual void ScheduledStartDateRules()
		{
		}

		public virtual void IsDeletedRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3f752263b031402feff7c413749e2682</Hash>
</Codenesium>*/