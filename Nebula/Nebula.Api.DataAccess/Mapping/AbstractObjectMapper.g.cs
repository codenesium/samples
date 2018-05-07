using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void ChainMapModelToEF(
			int id,
			ChainModel model,
			EFChain efChain)
		{
			efChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
		}

		public virtual POCOChain ChainMapEFToPOCO(
			EFChain efChain)
		{
			if (efChain == null)
			{
				return null;
			}

			return new POCOChain(efChain.ChainStatusId, efChain.ExternalId, efChain.Id, efChain.Name, efChain.TeamId);
		}

		public virtual void ChainStatusMapModelToEF(
			int id,
			ChainStatusModel model,
			EFChainStatus efChainStatus)
		{
			efChainStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOChainStatus ChainStatusMapEFToPOCO(
			EFChainStatus efChainStatus)
		{
			if (efChainStatus == null)
			{
				return null;
			}

			return new POCOChainStatus(efChainStatus.Id, efChainStatus.Name);
		}

		public virtual void ClaspMapModelToEF(
			int id,
			ClaspModel model,
			EFClasp efClasp)
		{
			efClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
		}

		public virtual POCOClasp ClaspMapEFToPOCO(
			EFClasp efClasp)
		{
			if (efClasp == null)
			{
				return null;
			}

			return new POCOClasp(efClasp.Id, efClasp.NextChainId, efClasp.PreviousChainId);
		}

		public virtual void LinkMapModelToEF(
			int id,
			LinkModel model,
			EFLink efLink)
		{
			efLink.SetProperties(
				id,
				model.AssignedMachineId,
				model.ChainId,
				model.DateCompleted,
				model.DateStarted,
				model.DynamicParameters,
				model.ExternalId,
				model.LinkStatusId,
				model.Name,
				model.Order,
				model.Response,
				model.StaticParameters,
				model.TimeoutInSeconds);
		}

		public virtual POCOLink LinkMapEFToPOCO(
			EFLink efLink)
		{
			if (efLink == null)
			{
				return null;
			}

			return new POCOLink(efLink.AssignedMachineId, efLink.ChainId, efLink.DateCompleted, efLink.DateStarted, efLink.DynamicParameters, efLink.ExternalId, efLink.Id, efLink.LinkStatusId, efLink.Name, efLink.Order, efLink.Response, efLink.StaticParameters, efLink.TimeoutInSeconds);
		}

		public virtual void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			EFLinkLog efLinkLog)
		{
			efLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
		}

		public virtual POCOLinkLog LinkLogMapEFToPOCO(
			EFLinkLog efLinkLog)
		{
			if (efLinkLog == null)
			{
				return null;
			}

			return new POCOLinkLog(efLinkLog.DateEntered, efLinkLog.Id, efLinkLog.LinkId, efLinkLog.Log);
		}

		public virtual void LinkStatusMapModelToEF(
			int id,
			LinkStatusModel model,
			EFLinkStatus efLinkStatus)
		{
			efLinkStatus.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOLinkStatus LinkStatusMapEFToPOCO(
			EFLinkStatus efLinkStatus)
		{
			if (efLinkStatus == null)
			{
				return null;
			}

			return new POCOLinkStatus(efLinkStatus.Id, efLinkStatus.Name);
		}

		public virtual void MachineMapModelToEF(
			int id,
			MachineModel model,
			EFMachine efMachine)
		{
			efMachine.SetProperties(
				id,
				model.Description,
				model.JwtKey,
				model.LastIpAddress,
				model.MachineGuid,
				model.Name);
		}

		public virtual POCOMachine MachineMapEFToPOCO(
			EFMachine efMachine)
		{
			if (efMachine == null)
			{
				return null;
			}

			return new POCOMachine(efMachine.Description, efMachine.Id, efMachine.JwtKey, efMachine.LastIpAddress, efMachine.MachineGuid, efMachine.Name);
		}

		public virtual void MachineRefTeamMapModelToEF(
			int id,
			MachineRefTeamModel model,
			EFMachineRefTeam efMachineRefTeam)
		{
			efMachineRefTeam.SetProperties(
				id,
				model.MachineId,
				model.TeamId);
		}

		public virtual POCOMachineRefTeam MachineRefTeamMapEFToPOCO(
			EFMachineRefTeam efMachineRefTeam)
		{
			if (efMachineRefTeam == null)
			{
				return null;
			}

			return new POCOMachineRefTeam(efMachineRefTeam.Id, efMachineRefTeam.MachineId, efMachineRefTeam.TeamId);
		}

		public virtual void OrganizationMapModelToEF(
			int id,
			OrganizationModel model,
			EFOrganization efOrganization)
		{
			efOrganization.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOOrganization OrganizationMapEFToPOCO(
			EFOrganization efOrganization)
		{
			if (efOrganization == null)
			{
				return null;
			}

			return new POCOOrganization(efOrganization.Id, efOrganization.Name);
		}

		public virtual void TeamMapModelToEF(
			int id,
			TeamModel model,
			EFTeam efTeam)
		{
			efTeam.SetProperties(
				id,
				model.Name,
				model.OrganizationId);
		}

		public virtual POCOTeam TeamMapEFToPOCO(
			EFTeam efTeam)
		{
			if (efTeam == null)
			{
				return null;
			}

			return new POCOTeam(efTeam.Id, efTeam.Name, efTeam.OrganizationId);
		}

		public virtual void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo)
		{
			efVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
		}

		public virtual POCOVersionInfo VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo)
		{
			if (efVersionInfo == null)
			{
				return null;
			}

			return new POCOVersionInfo(efVersionInfo.AppliedOn, efVersionInfo.Description, efVersionInfo.Version);
		}
	}
}

/*<Codenesium>
    <Hash>6bc61e9ac22402813e25e2de20b5f771</Hash>
</Codenesium>*/