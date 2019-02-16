using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepNoteMapper
	{
		public virtual PipelineStepNote MapModelToEntity(
			int id,
			ApiPipelineStepNoteServerRequestModel model
			)
		{
			PipelineStepNote item = new PipelineStepNote();
			item.SetProperties(
				id,
				model.EmployeeId,
				model.Note,
				model.PipelineStepId);
			return item;
		}

		public virtual ApiPipelineStepNoteServerResponseModel MapEntityToModel(
			PipelineStepNote item)
		{
			var model = new ApiPipelineStepNoteServerResponseModel();

			model.SetProperties(item.Id,
			                    item.EmployeeId,
			                    item.Note,
			                    item.PipelineStepId);
			if (item.EmployeeIdNavigation != null)
			{
				var employeeIdModel = new ApiEmployeeServerResponseModel();
				employeeIdModel.SetProperties(
					item.Id,
					item.EmployeeIdNavigation.FirstName,
					item.EmployeeIdNavigation.IsSalesPerson,
					item.EmployeeIdNavigation.IsShipper,
					item.EmployeeIdNavigation.LastName);

				model.SetEmployeeIdNavigation(employeeIdModel);
			}

			if (item.PipelineStepIdNavigation != null)
			{
				var pipelineStepIdModel = new ApiPipelineStepServerResponseModel();
				pipelineStepIdModel.SetProperties(
					item.Id,
					item.PipelineStepIdNavigation.Name,
					item.PipelineStepIdNavigation.PipelineStepStatusId,
					item.PipelineStepIdNavigation.ShipperId);

				model.SetPipelineStepIdNavigation(pipelineStepIdModel);
			}

			return model;
		}

		public virtual List<ApiPipelineStepNoteServerResponseModel> MapEntityToModel(
			List<PipelineStepNote> items)
		{
			List<ApiPipelineStepNoteServerResponseModel> response = new List<ApiPipelineStepNoteServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>667825ab4dc492f3ad4af279810581bd</Hash>
</Codenesium>*/