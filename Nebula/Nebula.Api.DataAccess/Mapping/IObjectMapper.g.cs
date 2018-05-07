using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void ChainMapModelToEF(
			int id,
			ChainModel model,
			EFChain efChain);

		POCOChain ChainMapEFToPOCO(
			EFChain efChain);

		void ChainStatusMapModelToEF(
			int id,
			ChainStatusModel model,
			EFChainStatus efChainStatus);

		POCOChainStatus ChainStatusMapEFToPOCO(
			EFChainStatus efChainStatus);

		void ClaspMapModelToEF(
			int id,
			ClaspModel model,
			EFClasp efClasp);

		POCOClasp ClaspMapEFToPOCO(
			EFClasp efClasp);

		void LinkMapModelToEF(
			int id,
			LinkModel model,
			EFLink efLink);

		POCOLink LinkMapEFToPOCO(
			EFLink efLink);

		void LinkLogMapModelToEF(
			int id,
			LinkLogModel model,
			EFLinkLog efLinkLog);

		POCOLinkLog LinkLogMapEFToPOCO(
			EFLinkLog efLinkLog);

		void LinkStatusMapModelToEF(
			int id,
			LinkStatusModel model,
			EFLinkStatus efLinkStatus);

		POCOLinkStatus LinkStatusMapEFToPOCO(
			EFLinkStatus efLinkStatus);

		void MachineMapModelToEF(
			int id,
			MachineModel model,
			EFMachine efMachine);

		POCOMachine MachineMapEFToPOCO(
			EFMachine efMachine);

		void MachineRefTeamMapModelToEF(
			int id,
			MachineRefTeamModel model,
			EFMachineRefTeam efMachineRefTeam);

		POCOMachineRefTeam MachineRefTeamMapEFToPOCO(
			EFMachineRefTeam efMachineRefTeam);

		void OrganizationMapModelToEF(
			int id,
			OrganizationModel model,
			EFOrganization efOrganization);

		POCOOrganization OrganizationMapEFToPOCO(
			EFOrganization efOrganization);

		void TeamMapModelToEF(
			int id,
			TeamModel model,
			EFTeam efTeam);

		POCOTeam TeamMapEFToPOCO(
			EFTeam efTeam);

		void VersionInfoMapModelToEF(
			long version,
			VersionInfoModel model,
			EFVersionInfo efVersionInfo);

		POCOVersionInfo VersionInfoMapEFToPOCO(
			EFVersionInfo efVersionInfo);
	}
}

/*<Codenesium>
    <Hash>26a30599edb044651d49beff60d8b150</Hash>
</Codenesium>*/