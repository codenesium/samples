using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AWBuildVersionMapModelToEF(
			int systemInformationID,
			AWBuildVersionModel model,
			EFAWBuildVersion efAWBuildVersion)
		{
			efAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
		}

		public virtual void AWBuildVersionMapEFToPOCO(
			EFAWBuildVersion efAWBuildVersion,
			ApiResponse response)
		{
			if (efAWBuildVersion == null)
			{
				return;
			}

			response.AddAWBuildVersion(new POCOAWBuildVersion(efAWBuildVersion.Database_Version, efAWBuildVersion.ModifiedDate, efAWBuildVersion.SystemInformationID, efAWBuildVersion.VersionDate));
		}

		public virtual void DatabaseLogMapModelToEF(
			int databaseLogID,
			DatabaseLogModel model,
			EFDatabaseLog efDatabaseLog)
		{
			efDatabaseLog.SetProperties(
				databaseLogID,
				model.DatabaseUser,
				model.@Event,
				model.@Object,
				model.PostTime,
				model.Schema,
				model.TSQL,
				model.XmlEvent);
		}

		public virtual void DatabaseLogMapEFToPOCO(
			EFDatabaseLog efDatabaseLog,
			ApiResponse response)
		{
			if (efDatabaseLog == null)
			{
				return;
			}

			response.AddDatabaseLog(new POCODatabaseLog(efDatabaseLog.DatabaseLogID, efDatabaseLog.DatabaseUser, efDatabaseLog.@Event, efDatabaseLog.@Object, efDatabaseLog.PostTime, efDatabaseLog.Schema, efDatabaseLog.TSQL, efDatabaseLog.XmlEvent));
		}

		public virtual void ErrorLogMapModelToEF(
			int errorLogID,
			ErrorLogModel model,
			EFErrorLog efErrorLog)
		{
			efErrorLog.SetProperties(
				errorLogID,
				model.ErrorLine,
				model.ErrorMessage,
				model.ErrorNumber,
				model.ErrorProcedure,
				model.ErrorSeverity,
				model.ErrorState,
				model.ErrorTime,
				model.UserName);
		}

		public virtual void ErrorLogMapEFToPOCO(
			EFErrorLog efErrorLog,
			ApiResponse response)
		{
			if (efErrorLog == null)
			{
				return;
			}

			response.AddErrorLog(new POCOErrorLog(efErrorLog.ErrorLine, efErrorLog.ErrorLogID, efErrorLog.ErrorMessage, efErrorLog.ErrorNumber, efErrorLog.ErrorProcedure, efErrorLog.ErrorSeverity, efErrorLog.ErrorState, efErrorLog.ErrorTime, efErrorLog.UserName));
		}

		public virtual void DepartmentMapModelToEF(
			short departmentID,
			DepartmentModel model,
			EFDepartment efDepartment)
		{
			efDepartment.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void DepartmentMapEFToPOCO(
			EFDepartment efDepartment,
			ApiResponse response)
		{
			if (efDepartment == null)
			{
				return;
			}

			response.AddDepartment(new POCODepartment(efDepartment.DepartmentID, efDepartment.GroupName, efDepartment.ModifiedDate, efDepartment.Name));
		}

		public virtual void EmployeeMapModelToEF(
			int businessEntityID,
			EmployeeModel model,
			EFEmployee efEmployee)
		{
			efEmployee.SetProperties(
				businessEntityID,
				model.BirthDate,
				model.CurrentFlag,
				model.Gender,
				model.HireDate,
				model.JobTitle,
				model.LoginID,
				model.MaritalStatus,
				model.ModifiedDate,
				model.NationalIDNumber,
				model.OrganizationLevel,
				model.OrganizationNode,
				model.Rowguid,
				model.SalariedFlag,
				model.SickLeaveHours,
				model.VacationHours);
		}

		public virtual void EmployeeMapEFToPOCO(
			EFEmployee efEmployee,
			ApiResponse response)
		{
			if (efEmployee == null)
			{
				return;
			}

			response.AddEmployee(new POCOEmployee(efEmployee.BirthDate, efEmployee.BusinessEntityID, efEmployee.CurrentFlag, efEmployee.Gender, efEmployee.HireDate, efEmployee.JobTitle, efEmployee.LoginID, efEmployee.MaritalStatus, efEmployee.ModifiedDate, efEmployee.NationalIDNumber, efEmployee.OrganizationLevel, efEmployee.OrganizationNode, efEmployee.Rowguid, efEmployee.SalariedFlag, efEmployee.SickLeaveHours, efEmployee.VacationHours));
		}

		public virtual void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model,
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				model.DepartmentID,
				model.EndDate,
				model.ModifiedDate,
				model.ShiftID,
				model.StartDate);
		}

		public virtual void EmployeeDepartmentHistoryMapEFToPOCO(
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,
			ApiResponse response)
		{
			if (efEmployeeDepartmentHistory == null)
			{
				return;
			}

			response.AddEmployeeDepartmentHistory(new POCOEmployeeDepartmentHistory(efEmployeeDepartmentHistory.BusinessEntityID, efEmployeeDepartmentHistory.DepartmentID, efEmployeeDepartmentHistory.EndDate, efEmployeeDepartmentHistory.ModifiedDate, efEmployeeDepartmentHistory.ShiftID, efEmployeeDepartmentHistory.StartDate));

			this.EmployeeMapEFToPOCO(efEmployeeDepartmentHistory.Employee, response);

			this.DepartmentMapEFToPOCO(efEmployeeDepartmentHistory.Department, response);

			this.ShiftMapEFToPOCO(efEmployeeDepartmentHistory.Shift, response);
		}

		public virtual void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			EmployeePayHistoryModel model,
			EFEmployeePayHistory efEmployeePayHistory)
		{
			efEmployeePayHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PayFrequency,
				model.Rate,
				model.RateChangeDate);
		}

		public virtual void EmployeePayHistoryMapEFToPOCO(
			EFEmployeePayHistory efEmployeePayHistory,
			ApiResponse response)
		{
			if (efEmployeePayHistory == null)
			{
				return;
			}

			response.AddEmployeePayHistory(new POCOEmployeePayHistory(efEmployeePayHistory.BusinessEntityID, efEmployeePayHistory.ModifiedDate, efEmployeePayHistory.PayFrequency, efEmployeePayHistory.Rate, efEmployeePayHistory.RateChangeDate));

			this.EmployeeMapEFToPOCO(efEmployeePayHistory.Employee, response);
		}

		public virtual void JobCandidateMapModelToEF(
			int jobCandidateID,
			JobCandidateModel model,
			EFJobCandidate efJobCandidate)
		{
			efJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
		}

		public virtual void JobCandidateMapEFToPOCO(
			EFJobCandidate efJobCandidate,
			ApiResponse response)
		{
			if (efJobCandidate == null)
			{
				return;
			}

			response.AddJobCandidate(new POCOJobCandidate(efJobCandidate.BusinessEntityID, efJobCandidate.JobCandidateID, efJobCandidate.ModifiedDate, efJobCandidate.Resume));

			this.EmployeeMapEFToPOCO(efJobCandidate.Employee, response);
		}

		public virtual void ShiftMapModelToEF(
			int shiftID,
			ShiftModel model,
			EFShift efShift)
		{
			efShift.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
		}

		public virtual void ShiftMapEFToPOCO(
			EFShift efShift,
			ApiResponse response)
		{
			if (efShift == null)
			{
				return;
			}

			response.AddShift(new POCOShift(efShift.EndTime, efShift.ModifiedDate, efShift.Name, efShift.ShiftID, efShift.StartTime));
		}

		public virtual void AddressMapModelToEF(
			int addressID,
			AddressModel model,
			EFAddress efAddress)
		{
			efAddress.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.ModifiedDate,
				model.PostalCode,
				model.Rowguid,
				model.SpatialLocation,
				model.StateProvinceID);
		}

		public virtual void AddressMapEFToPOCO(
			EFAddress efAddress,
			ApiResponse response)
		{
			if (efAddress == null)
			{
				return;
			}

			response.AddAddress(new POCOAddress(efAddress.AddressID, efAddress.AddressLine1, efAddress.AddressLine2, efAddress.City, efAddress.ModifiedDate, efAddress.PostalCode, efAddress.Rowguid, efAddress.SpatialLocation, efAddress.StateProvinceID));

			this.StateProvinceMapEFToPOCO(efAddress.StateProvince, response);
		}

		public virtual void AddressTypeMapModelToEF(
			int addressTypeID,
			AddressTypeModel model,
			EFAddressType efAddressType)
		{
			efAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual void AddressTypeMapEFToPOCO(
			EFAddressType efAddressType,
			ApiResponse response)
		{
			if (efAddressType == null)
			{
				return;
			}

			response.AddAddressType(new POCOAddressType(efAddressType.AddressTypeID, efAddressType.ModifiedDate, efAddressType.Name, efAddressType.Rowguid));
		}

		public virtual void BusinessEntityMapModelToEF(
			int businessEntityID,
			BusinessEntityModel model,
			EFBusinessEntity efBusinessEntity)
		{
			efBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual void BusinessEntityMapEFToPOCO(
			EFBusinessEntity efBusinessEntity,
			ApiResponse response)
		{
			if (efBusinessEntity == null)
			{
				return;
			}

			response.AddBusinessEntity(new POCOBusinessEntity(efBusinessEntity.BusinessEntityID, efBusinessEntity.ModifiedDate, efBusinessEntity.Rowguid));
		}

		public virtual void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			BusinessEntityAddressModel model,
			EFBusinessEntityAddress efBusinessEntityAddress)
		{
			efBusinessEntityAddress.SetProperties(
				businessEntityID,
				model.AddressID,
				model.AddressTypeID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual void BusinessEntityAddressMapEFToPOCO(
			EFBusinessEntityAddress efBusinessEntityAddress,
			ApiResponse response)
		{
			if (efBusinessEntityAddress == null)
			{
				return;
			}

			response.AddBusinessEntityAddress(new POCOBusinessEntityAddress(efBusinessEntityAddress.AddressID, efBusinessEntityAddress.AddressTypeID, efBusinessEntityAddress.BusinessEntityID, efBusinessEntityAddress.ModifiedDate, efBusinessEntityAddress.Rowguid));

			this.AddressMapEFToPOCO(efBusinessEntityAddress.Address, response);

			this.AddressTypeMapEFToPOCO(efBusinessEntityAddress.AddressType, response);

			this.BusinessEntityMapEFToPOCO(efBusinessEntityAddress.BusinessEntity, response);
		}

		public virtual void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			BusinessEntityContactModel model,
			EFBusinessEntityContact efBusinessEntityContact)
		{
			efBusinessEntityContact.SetProperties(
				businessEntityID,
				model.ContactTypeID,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid);
		}

		public virtual void BusinessEntityContactMapEFToPOCO(
			EFBusinessEntityContact efBusinessEntityContact,
			ApiResponse response)
		{
			if (efBusinessEntityContact == null)
			{
				return;
			}

			response.AddBusinessEntityContact(new POCOBusinessEntityContact(efBusinessEntityContact.BusinessEntityID, efBusinessEntityContact.ContactTypeID, efBusinessEntityContact.ModifiedDate, efBusinessEntityContact.PersonID, efBusinessEntityContact.Rowguid));

			this.BusinessEntityMapEFToPOCO(efBusinessEntityContact.BusinessEntity, response);

			this.ContactTypeMapEFToPOCO(efBusinessEntityContact.ContactType, response);

			this.PersonMapEFToPOCO(efBusinessEntityContact.Person, response);
		}

		public virtual void ContactTypeMapModelToEF(
			int contactTypeID,
			ContactTypeModel model,
			EFContactType efContactType)
		{
			efContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void ContactTypeMapEFToPOCO(
			EFContactType efContactType,
			ApiResponse response)
		{
			if (efContactType == null)
			{
				return;
			}

			response.AddContactType(new POCOContactType(efContactType.ContactTypeID, efContactType.ModifiedDate, efContactType.Name));
		}

		public virtual void CountryRegionMapModelToEF(
			string countryRegionCode,
			CountryRegionModel model,
			EFCountryRegion efCountryRegion)
		{
			efCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void CountryRegionMapEFToPOCO(
			EFCountryRegion efCountryRegion,
			ApiResponse response)
		{
			if (efCountryRegion == null)
			{
				return;
			}

			response.AddCountryRegion(new POCOCountryRegion(efCountryRegion.CountryRegionCode, efCountryRegion.ModifiedDate, efCountryRegion.Name));
		}

		public virtual void EmailAddressMapModelToEF(
			int businessEntityID,
			EmailAddressModel model,
			EFEmailAddress efEmailAddress)
		{
			efEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddress1,
				model.EmailAddressID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual void EmailAddressMapEFToPOCO(
			EFEmailAddress efEmailAddress,
			ApiResponse response)
		{
			if (efEmailAddress == null)
			{
				return;
			}

			response.AddEmailAddress(new POCOEmailAddress(efEmailAddress.BusinessEntityID, efEmailAddress.EmailAddress1, efEmailAddress.EmailAddressID, efEmailAddress.ModifiedDate, efEmailAddress.Rowguid));

			this.PersonMapEFToPOCO(efEmailAddress.Person, response);
		}

		public virtual void PasswordMapModelToEF(
			int businessEntityID,
			PasswordModel model,
			EFPassword efPassword)
		{
			efPassword.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
		}

		public virtual void PasswordMapEFToPOCO(
			EFPassword efPassword,
			ApiResponse response)
		{
			if (efPassword == null)
			{
				return;
			}

			response.AddPassword(new POCOPassword(efPassword.BusinessEntityID, efPassword.ModifiedDate, efPassword.PasswordHash, efPassword.PasswordSalt, efPassword.Rowguid));

			this.PersonMapEFToPOCO(efPassword.Person, response);
		}

		public virtual void PersonMapModelToEF(
			int businessEntityID,
			PersonModel model,
			EFPerson efPerson)
		{
			efPerson.SetProperties(
				businessEntityID,
				model.AdditionalContactInfo,
				model.Demographics,
				model.EmailPromotion,
				model.FirstName,
				model.LastName,
				model.MiddleName,
				model.ModifiedDate,
				model.NameStyle,
				model.PersonType,
				model.Rowguid,
				model.Suffix,
				model.Title);
		}

		public virtual void PersonMapEFToPOCO(
			EFPerson efPerson,
			ApiResponse response)
		{
			if (efPerson == null)
			{
				return;
			}

			response.AddPerson(new POCOPerson(efPerson.AdditionalContactInfo, efPerson.BusinessEntityID, efPerson.Demographics, efPerson.EmailPromotion, efPerson.FirstName, efPerson.LastName, efPerson.MiddleName, efPerson.ModifiedDate, efPerson.NameStyle, efPerson.PersonType, efPerson.Rowguid, efPerson.Suffix, efPerson.Title));

			this.BusinessEntityMapEFToPOCO(efPerson.BusinessEntity, response);
		}

		public virtual void PersonPhoneMapModelToEF(
			int businessEntityID,
			PersonPhoneModel model,
			EFPersonPhone efPersonPhone)
		{
			efPersonPhone.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PhoneNumber,
				model.PhoneNumberTypeID);
		}

		public virtual void PersonPhoneMapEFToPOCO(
			EFPersonPhone efPersonPhone,
			ApiResponse response)
		{
			if (efPersonPhone == null)
			{
				return;
			}

			response.AddPersonPhone(new POCOPersonPhone(efPersonPhone.BusinessEntityID, efPersonPhone.ModifiedDate, efPersonPhone.PhoneNumber, efPersonPhone.PhoneNumberTypeID));

			this.PersonMapEFToPOCO(efPersonPhone.Person, response);

			this.PhoneNumberTypeMapEFToPOCO(efPersonPhone.PhoneNumberType, response);
		}

		public virtual void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model,
			EFPhoneNumberType efPhoneNumberType)
		{
			efPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void PhoneNumberTypeMapEFToPOCO(
			EFPhoneNumberType efPhoneNumberType,
			ApiResponse response)
		{
			if (efPhoneNumberType == null)
			{
				return;
			}

			response.AddPhoneNumberType(new POCOPhoneNumberType(efPhoneNumberType.ModifiedDate, efPhoneNumberType.Name, efPhoneNumberType.PhoneNumberTypeID));
		}

		public virtual void StateProvinceMapModelToEF(
			int stateProvinceID,
			StateProvinceModel model,
			EFStateProvince efStateProvince)
		{
			efStateProvince.SetProperties(
				stateProvinceID,
				model.CountryRegionCode,
				model.IsOnlyStateProvinceFlag,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceCode,
				model.TerritoryID);
		}

		public virtual void StateProvinceMapEFToPOCO(
			EFStateProvince efStateProvince,
			ApiResponse response)
		{
			if (efStateProvince == null)
			{
				return;
			}

			response.AddStateProvince(new POCOStateProvince(efStateProvince.CountryRegionCode, efStateProvince.IsOnlyStateProvinceFlag, efStateProvince.ModifiedDate, efStateProvince.Name, efStateProvince.Rowguid, efStateProvince.StateProvinceCode, efStateProvince.StateProvinceID, efStateProvince.TerritoryID));

			this.CountryRegionMapEFToPOCO(efStateProvince.CountryRegion, response);
		}

		public virtual void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			BillOfMaterialsModel model,
			EFBillOfMaterials efBillOfMaterials)
		{
			efBillOfMaterials.SetProperties(
				billOfMaterialsID,
				model.BOMLevel,
				model.ComponentID,
				model.EndDate,
				model.ModifiedDate,
				model.PerAssemblyQty,
				model.ProductAssemblyID,
				model.StartDate,
				model.UnitMeasureCode);
		}

		public virtual void BillOfMaterialsMapEFToPOCO(
			EFBillOfMaterials efBillOfMaterials,
			ApiResponse response)
		{
			if (efBillOfMaterials == null)
			{
				return;
			}

			response.AddBillOfMaterials(new POCOBillOfMaterials(efBillOfMaterials.BillOfMaterialsID, efBillOfMaterials.BOMLevel, efBillOfMaterials.ComponentID, efBillOfMaterials.EndDate, efBillOfMaterials.ModifiedDate, efBillOfMaterials.PerAssemblyQty, efBillOfMaterials.ProductAssemblyID, efBillOfMaterials.StartDate, efBillOfMaterials.UnitMeasureCode));

			this.ProductMapEFToPOCO(efBillOfMaterials.Product, response);

			this.ProductMapEFToPOCO(efBillOfMaterials.Product1, response);

			this.UnitMeasureMapEFToPOCO(efBillOfMaterials.UnitMeasure, response);
		}

		public virtual void CultureMapModelToEF(
			string cultureID,
			CultureModel model,
			EFCulture efCulture)
		{
			efCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void CultureMapEFToPOCO(
			EFCulture efCulture,
			ApiResponse response)
		{
			if (efCulture == null)
			{
				return;
			}

			response.AddCulture(new POCOCulture(efCulture.CultureID, efCulture.ModifiedDate, efCulture.Name));
		}

		public virtual void DocumentMapModelToEF(
			Guid documentNode,
			DocumentModel model,
			EFDocument efDocument)
		{
			efDocument.SetProperties(
				documentNode,
				model.ChangeNumber,
				model.Document1,
				model.DocumentLevel,
				model.DocumentSummary,
				model.FileExtension,
				model.FileName,
				model.FolderFlag,
				model.ModifiedDate,
				model.Owner,
				model.Revision,
				model.Rowguid,
				model.Status,
				model.Title);
		}

		public virtual void DocumentMapEFToPOCO(
			EFDocument efDocument,
			ApiResponse response)
		{
			if (efDocument == null)
			{
				return;
			}

			response.AddDocument(new POCODocument(efDocument.ChangeNumber, efDocument.Document1, efDocument.DocumentLevel, efDocument.DocumentNode, efDocument.DocumentSummary, efDocument.FileExtension, efDocument.FileName, efDocument.FolderFlag, efDocument.ModifiedDate, efDocument.Owner, efDocument.Revision, efDocument.Rowguid, efDocument.Status, efDocument.Title));
		}

		public virtual void IllustrationMapModelToEF(
			int illustrationID,
			IllustrationModel model,
			EFIllustration efIllustration)
		{
			efIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
		}

		public virtual void IllustrationMapEFToPOCO(
			EFIllustration efIllustration,
			ApiResponse response)
		{
			if (efIllustration == null)
			{
				return;
			}

			response.AddIllustration(new POCOIllustration(efIllustration.Diagram, efIllustration.IllustrationID, efIllustration.ModifiedDate));
		}

		public virtual void LocationMapModelToEF(
			short locationID,
			LocationModel model,
			EFLocation efLocation)
		{
			efLocation.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void LocationMapEFToPOCO(
			EFLocation efLocation,
			ApiResponse response)
		{
			if (efLocation == null)
			{
				return;
			}

			response.AddLocation(new POCOLocation(efLocation.Availability, efLocation.CostRate, efLocation.LocationID, efLocation.ModifiedDate, efLocation.Name));
		}

		public virtual void ProductMapModelToEF(
			int productID,
			ProductModel model,
			EFProduct efProduct)
		{
			efProduct.SetProperties(
				productID,
				model.@Class,
				model.Color,
				model.DaysToManufacture,
				model.DiscontinuedDate,
				model.FinishedGoodsFlag,
				model.ListPrice,
				model.MakeFlag,
				model.ModifiedDate,
				model.Name,
				model.ProductLine,
				model.ProductModelID,
				model.ProductNumber,
				model.ProductSubcategoryID,
				model.ReorderPoint,
				model.Rowguid,
				model.SafetyStockLevel,
				model.SellEndDate,
				model.SellStartDate,
				model.Size,
				model.SizeUnitMeasureCode,
				model.StandardCost,
				model.Style,
				model.Weight,
				model.WeightUnitMeasureCode);
		}

		public virtual void ProductMapEFToPOCO(
			EFProduct efProduct,
			ApiResponse response)
		{
			if (efProduct == null)
			{
				return;
			}

			response.AddProduct(new POCOProduct(efProduct.@Class, efProduct.Color, efProduct.DaysToManufacture, efProduct.DiscontinuedDate, efProduct.FinishedGoodsFlag, efProduct.ListPrice, efProduct.MakeFlag, efProduct.ModifiedDate, efProduct.Name, efProduct.ProductID, efProduct.ProductLine, efProduct.ProductModelID, efProduct.ProductNumber, efProduct.ProductSubcategoryID, efProduct.ReorderPoint, efProduct.Rowguid, efProduct.SafetyStockLevel, efProduct.SellEndDate, efProduct.SellStartDate, efProduct.Size, efProduct.SizeUnitMeasureCode, efProduct.StandardCost, efProduct.Style, efProduct.Weight, efProduct.WeightUnitMeasureCode));

			this.ProductModelMapEFToPOCO(efProduct.ProductModel, response);

			this.ProductSubcategoryMapEFToPOCO(efProduct.ProductSubcategory, response);

			this.UnitMeasureMapEFToPOCO(efProduct.UnitMeasure, response);

			this.UnitMeasureMapEFToPOCO(efProduct.UnitMeasure1, response);
		}

		public virtual void ProductCategoryMapModelToEF(
			int productCategoryID,
			ProductCategoryModel model,
			EFProductCategory efProductCategory)
		{
			efProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual void ProductCategoryMapEFToPOCO(
			EFProductCategory efProductCategory,
			ApiResponse response)
		{
			if (efProductCategory == null)
			{
				return;
			}

			response.AddProductCategory(new POCOProductCategory(efProductCategory.ModifiedDate, efProductCategory.Name, efProductCategory.ProductCategoryID, efProductCategory.Rowguid));
		}

		public virtual void ProductCostHistoryMapModelToEF(
			int productID,
			ProductCostHistoryModel model,
			EFProductCostHistory efProductCostHistory)
		{
			efProductCostHistory.SetProperties(
				productID,
				model.EndDate,
				model.ModifiedDate,
				model.StandardCost,
				model.StartDate);
		}

		public virtual void ProductCostHistoryMapEFToPOCO(
			EFProductCostHistory efProductCostHistory,
			ApiResponse response)
		{
			if (efProductCostHistory == null)
			{
				return;
			}

			response.AddProductCostHistory(new POCOProductCostHistory(efProductCostHistory.EndDate, efProductCostHistory.ModifiedDate, efProductCostHistory.ProductID, efProductCostHistory.StandardCost, efProductCostHistory.StartDate));

			this.ProductMapEFToPOCO(efProductCostHistory.Product, response);
		}

		public virtual void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ProductDescriptionModel model,
			EFProductDescription efProductDescription)
		{
			efProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual void ProductDescriptionMapEFToPOCO(
			EFProductDescription efProductDescription,
			ApiResponse response)
		{
			if (efProductDescription == null)
			{
				return;
			}

			response.AddProductDescription(new POCOProductDescription(efProductDescription.Description, efProductDescription.ModifiedDate, efProductDescription.ProductDescriptionID, efProductDescription.Rowguid));
		}

		public virtual void ProductDocumentMapModelToEF(
			int productID,
			ProductDocumentModel model,
			EFProductDocument efProductDocument)
		{
			efProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
		}

		public virtual void ProductDocumentMapEFToPOCO(
			EFProductDocument efProductDocument,
			ApiResponse response)
		{
			if (efProductDocument == null)
			{
				return;
			}

			response.AddProductDocument(new POCOProductDocument(efProductDocument.DocumentNode, efProductDocument.ModifiedDate, efProductDocument.ProductID));

			this.DocumentMapEFToPOCO(efProductDocument.Document, response);

			this.ProductMapEFToPOCO(efProductDocument.Product, response);
		}

		public virtual void ProductInventoryMapModelToEF(
			int productID,
			ProductInventoryModel model,
			EFProductInventory efProductInventory)
		{
			efProductInventory.SetProperties(
				productID,
				model.Bin,
				model.LocationID,
				model.ModifiedDate,
				model.Quantity,
				model.Rowguid,
				model.Shelf);
		}

		public virtual void ProductInventoryMapEFToPOCO(
			EFProductInventory efProductInventory,
			ApiResponse response)
		{
			if (efProductInventory == null)
			{
				return;
			}

			response.AddProductInventory(new POCOProductInventory(efProductInventory.Bin, efProductInventory.LocationID, efProductInventory.ModifiedDate, efProductInventory.ProductID, efProductInventory.Quantity, efProductInventory.Rowguid, efProductInventory.Shelf));

			this.LocationMapEFToPOCO(efProductInventory.Location, response);

			this.ProductMapEFToPOCO(efProductInventory.Product, response);
		}

		public virtual void ProductListPriceHistoryMapModelToEF(
			int productID,
			ProductListPriceHistoryModel model,
			EFProductListPriceHistory efProductListPriceHistory)
		{
			efProductListPriceHistory.SetProperties(
				productID,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate,
				model.StartDate);
		}

		public virtual void ProductListPriceHistoryMapEFToPOCO(
			EFProductListPriceHistory efProductListPriceHistory,
			ApiResponse response)
		{
			if (efProductListPriceHistory == null)
			{
				return;
			}

			response.AddProductListPriceHistory(new POCOProductListPriceHistory(efProductListPriceHistory.EndDate, efProductListPriceHistory.ListPrice, efProductListPriceHistory.ModifiedDate, efProductListPriceHistory.ProductID, efProductListPriceHistory.StartDate));

			this.ProductMapEFToPOCO(efProductListPriceHistory.Product, response);
		}

		public virtual void ProductModelMapModelToEF(
			int productModelID,
			ProductModelModel model,
			EFProductModel efProductModel)
		{
			efProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instructions,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual void ProductModelMapEFToPOCO(
			EFProductModel efProductModel,
			ApiResponse response)
		{
			if (efProductModel == null)
			{
				return;
			}

			response.AddProductModel(new POCOProductModel(efProductModel.CatalogDescription, efProductModel.Instructions, efProductModel.ModifiedDate, efProductModel.Name, efProductModel.ProductModelID, efProductModel.Rowguid));
		}

		public virtual void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ProductModelIllustrationModel model,
			EFProductModelIllustration efProductModelIllustration)
		{
			efProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
		}

		public virtual void ProductModelIllustrationMapEFToPOCO(
			EFProductModelIllustration efProductModelIllustration,
			ApiResponse response)
		{
			if (efProductModelIllustration == null)
			{
				return;
			}

			response.AddProductModelIllustration(new POCOProductModelIllustration(efProductModelIllustration.IllustrationID, efProductModelIllustration.ModifiedDate, efProductModelIllustration.ProductModelID));

			this.IllustrationMapEFToPOCO(efProductModelIllustration.Illustration, response);

			this.ProductModelMapEFToPOCO(efProductModelIllustration.ProductModel, response);
		}

		public virtual void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ProductModelProductDescriptionCultureModel model,
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.CultureID,
				model.ModifiedDate,
				model.ProductDescriptionID);
		}

		public virtual void ProductModelProductDescriptionCultureMapEFToPOCO(
			EFProductModelProductDescriptionCulture efProductModelProductDescriptionCulture,
			ApiResponse response)
		{
			if (efProductModelProductDescriptionCulture == null)
			{
				return;
			}

			response.AddProductModelProductDescriptionCulture(new POCOProductModelProductDescriptionCulture(efProductModelProductDescriptionCulture.CultureID, efProductModelProductDescriptionCulture.ModifiedDate, efProductModelProductDescriptionCulture.ProductDescriptionID, efProductModelProductDescriptionCulture.ProductModelID));

			this.CultureMapEFToPOCO(efProductModelProductDescriptionCulture.Culture, response);

			this.ProductDescriptionMapEFToPOCO(efProductModelProductDescriptionCulture.ProductDescription, response);

			this.ProductModelMapEFToPOCO(efProductModelProductDescriptionCulture.ProductModel, response);
		}

		public virtual void ProductPhotoMapModelToEF(
			int productPhotoID,
			ProductPhotoModel model,
			EFProductPhoto efProductPhoto)
		{
			efProductPhoto.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
		}

		public virtual void ProductPhotoMapEFToPOCO(
			EFProductPhoto efProductPhoto,
			ApiResponse response)
		{
			if (efProductPhoto == null)
			{
				return;
			}

			response.AddProductPhoto(new POCOProductPhoto(efProductPhoto.LargePhoto, efProductPhoto.LargePhotoFileName, efProductPhoto.ModifiedDate, efProductPhoto.ProductPhotoID, efProductPhoto.ThumbNailPhoto, efProductPhoto.ThumbnailPhotoFileName));
		}

		public virtual void ProductProductPhotoMapModelToEF(
			int productID,
			ProductProductPhotoModel model,
			EFProductProductPhoto efProductProductPhoto)
		{
			efProductProductPhoto.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
		}

		public virtual void ProductProductPhotoMapEFToPOCO(
			EFProductProductPhoto efProductProductPhoto,
			ApiResponse response)
		{
			if (efProductProductPhoto == null)
			{
				return;
			}

			response.AddProductProductPhoto(new POCOProductProductPhoto(efProductProductPhoto.ModifiedDate, efProductProductPhoto.Primary, efProductProductPhoto.ProductID, efProductProductPhoto.ProductPhotoID));

			this.ProductMapEFToPOCO(efProductProductPhoto.Product, response);

			this.ProductPhotoMapEFToPOCO(efProductProductPhoto.ProductPhoto, response);
		}

		public virtual void ProductReviewMapModelToEF(
			int productReviewID,
			ProductReviewModel model,
			EFProductReview efProductReview)
		{
			efProductReview.SetProperties(
				productReviewID,
				model.Comments,
				model.EmailAddress,
				model.ModifiedDate,
				model.ProductID,
				model.Rating,
				model.ReviewDate,
				model.ReviewerName);
		}

		public virtual void ProductReviewMapEFToPOCO(
			EFProductReview efProductReview,
			ApiResponse response)
		{
			if (efProductReview == null)
			{
				return;
			}

			response.AddProductReview(new POCOProductReview(efProductReview.Comments, efProductReview.EmailAddress, efProductReview.ModifiedDate, efProductReview.ProductID, efProductReview.ProductReviewID, efProductReview.Rating, efProductReview.ReviewDate, efProductReview.ReviewerName));

			this.ProductMapEFToPOCO(efProductReview.Product, response);
		}

		public virtual void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ProductSubcategoryModel model,
			EFProductSubcategory efProductSubcategory)
		{
			efProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
		}

		public virtual void ProductSubcategoryMapEFToPOCO(
			EFProductSubcategory efProductSubcategory,
			ApiResponse response)
		{
			if (efProductSubcategory == null)
			{
				return;
			}

			response.AddProductSubcategory(new POCOProductSubcategory(efProductSubcategory.ModifiedDate, efProductSubcategory.Name, efProductSubcategory.ProductCategoryID, efProductSubcategory.ProductSubcategoryID, efProductSubcategory.Rowguid));

			this.ProductCategoryMapEFToPOCO(efProductSubcategory.ProductCategory, response);
		}

		public virtual void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ScrapReasonModel model,
			EFScrapReason efScrapReason)
		{
			efScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void ScrapReasonMapEFToPOCO(
			EFScrapReason efScrapReason,
			ApiResponse response)
		{
			if (efScrapReason == null)
			{
				return;
			}

			response.AddScrapReason(new POCOScrapReason(efScrapReason.ModifiedDate, efScrapReason.Name, efScrapReason.ScrapReasonID));
		}

		public virtual void TransactionHistoryMapModelToEF(
			int transactionID,
			TransactionHistoryModel model,
			EFTransactionHistory efTransactionHistory)
		{
			efTransactionHistory.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
		}

		public virtual void TransactionHistoryMapEFToPOCO(
			EFTransactionHistory efTransactionHistory,
			ApiResponse response)
		{
			if (efTransactionHistory == null)
			{
				return;
			}

			response.AddTransactionHistory(new POCOTransactionHistory(efTransactionHistory.ActualCost, efTransactionHistory.ModifiedDate, efTransactionHistory.ProductID, efTransactionHistory.Quantity, efTransactionHistory.ReferenceOrderID, efTransactionHistory.ReferenceOrderLineID, efTransactionHistory.TransactionDate, efTransactionHistory.TransactionID, efTransactionHistory.TransactionType));

			this.ProductMapEFToPOCO(efTransactionHistory.Product, response);
		}

		public virtual void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			TransactionHistoryArchiveModel model,
			EFTransactionHistoryArchive efTransactionHistoryArchive)
		{
			efTransactionHistoryArchive.SetProperties(
				transactionID,
				model.ActualCost,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ReferenceOrderID,
				model.ReferenceOrderLineID,
				model.TransactionDate,
				model.TransactionType);
		}

		public virtual void TransactionHistoryArchiveMapEFToPOCO(
			EFTransactionHistoryArchive efTransactionHistoryArchive,
			ApiResponse response)
		{
			if (efTransactionHistoryArchive == null)
			{
				return;
			}

			response.AddTransactionHistoryArchive(new POCOTransactionHistoryArchive(efTransactionHistoryArchive.ActualCost, efTransactionHistoryArchive.ModifiedDate, efTransactionHistoryArchive.ProductID, efTransactionHistoryArchive.Quantity, efTransactionHistoryArchive.ReferenceOrderID, efTransactionHistoryArchive.ReferenceOrderLineID, efTransactionHistoryArchive.TransactionDate, efTransactionHistoryArchive.TransactionID, efTransactionHistoryArchive.TransactionType));
		}

		public virtual void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			UnitMeasureModel model,
			EFUnitMeasure efUnitMeasure)
		{
			efUnitMeasure.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void UnitMeasureMapEFToPOCO(
			EFUnitMeasure efUnitMeasure,
			ApiResponse response)
		{
			if (efUnitMeasure == null)
			{
				return;
			}

			response.AddUnitMeasure(new POCOUnitMeasure(efUnitMeasure.ModifiedDate, efUnitMeasure.Name, efUnitMeasure.UnitMeasureCode));
		}

		public virtual void WorkOrderMapModelToEF(
			int workOrderID,
			WorkOrderModel model,
			EFWorkOrder efWorkOrder)
		{
			efWorkOrder.SetProperties(
				workOrderID,
				model.DueDate,
				model.EndDate,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.ScrappedQty,
				model.ScrapReasonID,
				model.StartDate,
				model.StockedQty);
		}

		public virtual void WorkOrderMapEFToPOCO(
			EFWorkOrder efWorkOrder,
			ApiResponse response)
		{
			if (efWorkOrder == null)
			{
				return;
			}

			response.AddWorkOrder(new POCOWorkOrder(efWorkOrder.DueDate, efWorkOrder.EndDate, efWorkOrder.ModifiedDate, efWorkOrder.OrderQty, efWorkOrder.ProductID, efWorkOrder.ScrappedQty, efWorkOrder.ScrapReasonID, efWorkOrder.StartDate, efWorkOrder.StockedQty, efWorkOrder.WorkOrderID));

			this.ProductMapEFToPOCO(efWorkOrder.Product, response);

			this.ScrapReasonMapEFToPOCO(efWorkOrder.ScrapReason, response);
		}

		public virtual void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			WorkOrderRoutingModel model,
			EFWorkOrderRouting efWorkOrderRouting)
		{
			efWorkOrderRouting.SetProperties(
				workOrderID,
				model.ActualCost,
				model.ActualEndDate,
				model.ActualResourceHrs,
				model.ActualStartDate,
				model.LocationID,
				model.ModifiedDate,
				model.OperationSequence,
				model.PlannedCost,
				model.ProductID,
				model.ScheduledEndDate,
				model.ScheduledStartDate);
		}

		public virtual void WorkOrderRoutingMapEFToPOCO(
			EFWorkOrderRouting efWorkOrderRouting,
			ApiResponse response)
		{
			if (efWorkOrderRouting == null)
			{
				return;
			}

			response.AddWorkOrderRouting(new POCOWorkOrderRouting(efWorkOrderRouting.ActualCost, efWorkOrderRouting.ActualEndDate, efWorkOrderRouting.ActualResourceHrs, efWorkOrderRouting.ActualStartDate, efWorkOrderRouting.LocationID, efWorkOrderRouting.ModifiedDate, efWorkOrderRouting.OperationSequence, efWorkOrderRouting.PlannedCost, efWorkOrderRouting.ProductID, efWorkOrderRouting.ScheduledEndDate, efWorkOrderRouting.ScheduledStartDate, efWorkOrderRouting.WorkOrderID));

			this.LocationMapEFToPOCO(efWorkOrderRouting.Location, response);

			this.WorkOrderMapEFToPOCO(efWorkOrderRouting.WorkOrder, response);
		}

		public virtual void ProductVendorMapModelToEF(
			int productID,
			ProductVendorModel model,
			EFProductVendor efProductVendor)
		{
			efProductVendor.SetProperties(
				productID,
				model.AverageLeadTime,
				model.BusinessEntityID,
				model.LastReceiptCost,
				model.LastReceiptDate,
				model.MaxOrderQty,
				model.MinOrderQty,
				model.ModifiedDate,
				model.OnOrderQty,
				model.StandardPrice,
				model.UnitMeasureCode);
		}

		public virtual void ProductVendorMapEFToPOCO(
			EFProductVendor efProductVendor,
			ApiResponse response)
		{
			if (efProductVendor == null)
			{
				return;
			}

			response.AddProductVendor(new POCOProductVendor(efProductVendor.AverageLeadTime, efProductVendor.BusinessEntityID, efProductVendor.LastReceiptCost, efProductVendor.LastReceiptDate, efProductVendor.MaxOrderQty, efProductVendor.MinOrderQty, efProductVendor.ModifiedDate, efProductVendor.OnOrderQty, efProductVendor.ProductID, efProductVendor.StandardPrice, efProductVendor.UnitMeasureCode));

			this.VendorMapEFToPOCO(efProductVendor.Vendor, response);
		}

		public virtual void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderDetailModel model,
			EFPurchaseOrderDetail efPurchaseOrderDetail)
		{
			efPurchaseOrderDetail.SetProperties(
				purchaseOrderID,
				model.DueDate,
				model.LineTotal,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.PurchaseOrderDetailID,
				model.ReceivedQty,
				model.RejectedQty,
				model.StockedQty,
				model.UnitPrice);
		}

		public virtual void PurchaseOrderDetailMapEFToPOCO(
			EFPurchaseOrderDetail efPurchaseOrderDetail,
			ApiResponse response)
		{
			if (efPurchaseOrderDetail == null)
			{
				return;
			}

			response.AddPurchaseOrderDetail(new POCOPurchaseOrderDetail(efPurchaseOrderDetail.DueDate, efPurchaseOrderDetail.LineTotal, efPurchaseOrderDetail.ModifiedDate, efPurchaseOrderDetail.OrderQty, efPurchaseOrderDetail.ProductID, efPurchaseOrderDetail.PurchaseOrderDetailID, efPurchaseOrderDetail.PurchaseOrderID, efPurchaseOrderDetail.ReceivedQty, efPurchaseOrderDetail.RejectedQty, efPurchaseOrderDetail.StockedQty, efPurchaseOrderDetail.UnitPrice));

			this.PurchaseOrderHeaderMapEFToPOCO(efPurchaseOrderDetail.PurchaseOrderHeader, response);
		}

		public virtual void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			PurchaseOrderHeaderModel model,
			EFPurchaseOrderHeader efPurchaseOrderHeader)
		{
			efPurchaseOrderHeader.SetProperties(
				purchaseOrderID,
				model.EmployeeID,
				model.Freight,
				model.ModifiedDate,
				model.OrderDate,
				model.RevisionNumber,
				model.ShipDate,
				model.ShipMethodID,
				model.Status,
				model.SubTotal,
				model.TaxAmt,
				model.TotalDue,
				model.VendorID);
		}

		public virtual void PurchaseOrderHeaderMapEFToPOCO(
			EFPurchaseOrderHeader efPurchaseOrderHeader,
			ApiResponse response)
		{
			if (efPurchaseOrderHeader == null)
			{
				return;
			}

			response.AddPurchaseOrderHeader(new POCOPurchaseOrderHeader(efPurchaseOrderHeader.EmployeeID, efPurchaseOrderHeader.Freight, efPurchaseOrderHeader.ModifiedDate, efPurchaseOrderHeader.OrderDate, efPurchaseOrderHeader.PurchaseOrderID, efPurchaseOrderHeader.RevisionNumber, efPurchaseOrderHeader.ShipDate, efPurchaseOrderHeader.ShipMethodID, efPurchaseOrderHeader.Status, efPurchaseOrderHeader.SubTotal, efPurchaseOrderHeader.TaxAmt, efPurchaseOrderHeader.TotalDue, efPurchaseOrderHeader.VendorID));

			this.ShipMethodMapEFToPOCO(efPurchaseOrderHeader.ShipMethod, response);

			this.VendorMapEFToPOCO(efPurchaseOrderHeader.Vendor, response);
		}

		public virtual void ShipMethodMapModelToEF(
			int shipMethodID,
			ShipMethodModel model,
			EFShipMethod efShipMethod)
		{
			efShipMethod.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
		}

		public virtual void ShipMethodMapEFToPOCO(
			EFShipMethod efShipMethod,
			ApiResponse response)
		{
			if (efShipMethod == null)
			{
				return;
			}

			response.AddShipMethod(new POCOShipMethod(efShipMethod.ModifiedDate, efShipMethod.Name, efShipMethod.Rowguid, efShipMethod.ShipBase, efShipMethod.ShipMethodID, efShipMethod.ShipRate));
		}

		public virtual void VendorMapModelToEF(
			int businessEntityID,
			VendorModel model,
			EFVendor efVendor)
		{
			efVendor.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.ActiveFlag,
				model.CreditRating,
				model.ModifiedDate,
				model.Name,
				model.PreferredVendorStatus,
				model.PurchasingWebServiceURL);
		}

		public virtual void VendorMapEFToPOCO(
			EFVendor efVendor,
			ApiResponse response)
		{
			if (efVendor == null)
			{
				return;
			}

			response.AddVendor(new POCOVendor(efVendor.AccountNumber, efVendor.ActiveFlag, efVendor.BusinessEntityID, efVendor.CreditRating, efVendor.ModifiedDate, efVendor.Name, efVendor.PreferredVendorStatus, efVendor.PurchasingWebServiceURL));
		}

		public virtual void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			CountryRegionCurrencyModel model,
			EFCountryRegionCurrency efCountryRegionCurrency)
		{
			efCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
		}

		public virtual void CountryRegionCurrencyMapEFToPOCO(
			EFCountryRegionCurrency efCountryRegionCurrency,
			ApiResponse response)
		{
			if (efCountryRegionCurrency == null)
			{
				return;
			}

			response.AddCountryRegionCurrency(new POCOCountryRegionCurrency(efCountryRegionCurrency.CountryRegionCode, efCountryRegionCurrency.CurrencyCode, efCountryRegionCurrency.ModifiedDate));

			this.CurrencyMapEFToPOCO(efCountryRegionCurrency.Currency, response);
		}

		public virtual void CreditCardMapModelToEF(
			int creditCardID,
			CreditCardModel model,
			EFCreditCard efCreditCard)
		{
			efCreditCard.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
		}

		public virtual void CreditCardMapEFToPOCO(
			EFCreditCard efCreditCard,
			ApiResponse response)
		{
			if (efCreditCard == null)
			{
				return;
			}

			response.AddCreditCard(new POCOCreditCard(efCreditCard.CardNumber, efCreditCard.CardType, efCreditCard.CreditCardID, efCreditCard.ExpMonth, efCreditCard.ExpYear, efCreditCard.ModifiedDate));
		}

		public virtual void CurrencyMapModelToEF(
			string currencyCode,
			CurrencyModel model,
			EFCurrency efCurrency)
		{
			efCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual void CurrencyMapEFToPOCO(
			EFCurrency efCurrency,
			ApiResponse response)
		{
			if (efCurrency == null)
			{
				return;
			}

			response.AddCurrency(new POCOCurrency(efCurrency.CurrencyCode, efCurrency.ModifiedDate, efCurrency.Name));
		}

		public virtual void CurrencyRateMapModelToEF(
			int currencyRateID,
			CurrencyRateModel model,
			EFCurrencyRate efCurrencyRate)
		{
			efCurrencyRate.SetProperties(
				currencyRateID,
				model.AverageRate,
				model.CurrencyRateDate,
				model.EndOfDayRate,
				model.FromCurrencyCode,
				model.ModifiedDate,
				model.ToCurrencyCode);
		}

		public virtual void CurrencyRateMapEFToPOCO(
			EFCurrencyRate efCurrencyRate,
			ApiResponse response)
		{
			if (efCurrencyRate == null)
			{
				return;
			}

			response.AddCurrencyRate(new POCOCurrencyRate(efCurrencyRate.AverageRate, efCurrencyRate.CurrencyRateDate, efCurrencyRate.CurrencyRateID, efCurrencyRate.EndOfDayRate, efCurrencyRate.FromCurrencyCode, efCurrencyRate.ModifiedDate, efCurrencyRate.ToCurrencyCode));

			this.CurrencyMapEFToPOCO(efCurrencyRate.Currency, response);

			this.CurrencyMapEFToPOCO(efCurrencyRate.Currency1, response);
		}

		public virtual void CustomerMapModelToEF(
			int customerID,
			CustomerModel model,
			EFCustomer efCustomer)
		{
			efCustomer.SetProperties(
				customerID,
				model.AccountNumber,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid,
				model.StoreID,
				model.TerritoryID);
		}

		public virtual void CustomerMapEFToPOCO(
			EFCustomer efCustomer,
			ApiResponse response)
		{
			if (efCustomer == null)
			{
				return;
			}

			response.AddCustomer(new POCOCustomer(efCustomer.AccountNumber, efCustomer.CustomerID, efCustomer.ModifiedDate, efCustomer.PersonID, efCustomer.Rowguid, efCustomer.StoreID, efCustomer.TerritoryID));

			this.StoreMapEFToPOCO(efCustomer.Store, response);

			this.SalesTerritoryMapEFToPOCO(efCustomer.SalesTerritory, response);
		}

		public virtual void PersonCreditCardMapModelToEF(
			int businessEntityID,
			PersonCreditCardModel model,
			EFPersonCreditCard efPersonCreditCard)
		{
			efPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
		}

		public virtual void PersonCreditCardMapEFToPOCO(
			EFPersonCreditCard efPersonCreditCard,
			ApiResponse response)
		{
			if (efPersonCreditCard == null)
			{
				return;
			}

			response.AddPersonCreditCard(new POCOPersonCreditCard(efPersonCreditCard.BusinessEntityID, efPersonCreditCard.CreditCardID, efPersonCreditCard.ModifiedDate));

			this.CreditCardMapEFToPOCO(efPersonCreditCard.CreditCard, response);
		}

		public virtual void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			SalesOrderDetailModel model,
			EFSalesOrderDetail efSalesOrderDetail)
		{
			efSalesOrderDetail.SetProperties(
				salesOrderID,
				model.CarrierTrackingNumber,
				model.LineTotal,
				model.ModifiedDate,
				model.OrderQty,
				model.ProductID,
				model.Rowguid,
				model.SalesOrderDetailID,
				model.SpecialOfferID,
				model.UnitPrice,
				model.UnitPriceDiscount);
		}

		public virtual void SalesOrderDetailMapEFToPOCO(
			EFSalesOrderDetail efSalesOrderDetail,
			ApiResponse response)
		{
			if (efSalesOrderDetail == null)
			{
				return;
			}

			response.AddSalesOrderDetail(new POCOSalesOrderDetail(efSalesOrderDetail.CarrierTrackingNumber, efSalesOrderDetail.LineTotal, efSalesOrderDetail.ModifiedDate, efSalesOrderDetail.OrderQty, efSalesOrderDetail.ProductID, efSalesOrderDetail.Rowguid, efSalesOrderDetail.SalesOrderDetailID, efSalesOrderDetail.SalesOrderID, efSalesOrderDetail.SpecialOfferID, efSalesOrderDetail.UnitPrice, efSalesOrderDetail.UnitPriceDiscount));

			this.SpecialOfferProductMapEFToPOCO(efSalesOrderDetail.SpecialOfferProduct, response);

			this.SalesOrderHeaderMapEFToPOCO(efSalesOrderDetail.SalesOrderHeader, response);

			this.SpecialOfferProductMapEFToPOCO(efSalesOrderDetail.SpecialOfferProduct1, response);
		}

		public virtual void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderModel model,
			EFSalesOrderHeader efSalesOrderHeader)
		{
			efSalesOrderHeader.SetProperties(
				salesOrderID,
				model.AccountNumber,
				model.BillToAddressID,
				model.Comment,
				model.CreditCardApprovalCode,
				model.CreditCardID,
				model.CurrencyRateID,
				model.CustomerID,
				model.DueDate,
				model.Freight,
				model.ModifiedDate,
				model.OnlineOrderFlag,
				model.OrderDate,
				model.PurchaseOrderNumber,
				model.RevisionNumber,
				model.Rowguid,
				model.SalesOrderNumber,
				model.SalesPersonID,
				model.ShipDate,
				model.ShipMethodID,
				model.ShipToAddressID,
				model.Status,
				model.SubTotal,
				model.TaxAmt,
				model.TerritoryID,
				model.TotalDue);
		}

		public virtual void SalesOrderHeaderMapEFToPOCO(
			EFSalesOrderHeader efSalesOrderHeader,
			ApiResponse response)
		{
			if (efSalesOrderHeader == null)
			{
				return;
			}

			response.AddSalesOrderHeader(new POCOSalesOrderHeader(efSalesOrderHeader.AccountNumber, efSalesOrderHeader.BillToAddressID, efSalesOrderHeader.Comment, efSalesOrderHeader.CreditCardApprovalCode, efSalesOrderHeader.CreditCardID, efSalesOrderHeader.CurrencyRateID, efSalesOrderHeader.CustomerID, efSalesOrderHeader.DueDate, efSalesOrderHeader.Freight, efSalesOrderHeader.ModifiedDate, efSalesOrderHeader.OnlineOrderFlag, efSalesOrderHeader.OrderDate, efSalesOrderHeader.PurchaseOrderNumber, efSalesOrderHeader.RevisionNumber, efSalesOrderHeader.Rowguid, efSalesOrderHeader.SalesOrderID, efSalesOrderHeader.SalesOrderNumber, efSalesOrderHeader.SalesPersonID, efSalesOrderHeader.ShipDate, efSalesOrderHeader.ShipMethodID, efSalesOrderHeader.ShipToAddressID, efSalesOrderHeader.Status, efSalesOrderHeader.SubTotal, efSalesOrderHeader.TaxAmt, efSalesOrderHeader.TerritoryID, efSalesOrderHeader.TotalDue));

			this.CreditCardMapEFToPOCO(efSalesOrderHeader.CreditCard, response);

			this.CurrencyRateMapEFToPOCO(efSalesOrderHeader.CurrencyRate, response);

			this.CustomerMapEFToPOCO(efSalesOrderHeader.Customer, response);

			this.SalesPersonMapEFToPOCO(efSalesOrderHeader.SalesPerson, response);

			this.SalesTerritoryMapEFToPOCO(efSalesOrderHeader.SalesTerritory, response);
		}

		public virtual void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model,
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason)
		{
			efSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				model.ModifiedDate,
				model.SalesReasonID);
		}

		public virtual void SalesOrderHeaderSalesReasonMapEFToPOCO(
			EFSalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason,
			ApiResponse response)
		{
			if (efSalesOrderHeaderSalesReason == null)
			{
				return;
			}

			response.AddSalesOrderHeaderSalesReason(new POCOSalesOrderHeaderSalesReason(efSalesOrderHeaderSalesReason.ModifiedDate, efSalesOrderHeaderSalesReason.SalesOrderID, efSalesOrderHeaderSalesReason.SalesReasonID));

			this.SalesOrderHeaderMapEFToPOCO(efSalesOrderHeaderSalesReason.SalesOrderHeader, response);

			this.SalesReasonMapEFToPOCO(efSalesOrderHeaderSalesReason.SalesReason, response);
		}

		public virtual void SalesPersonMapModelToEF(
			int businessEntityID,
			SalesPersonModel model,
			EFSalesPerson efSalesPerson)
		{
			efSalesPerson.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
		}

		public virtual void SalesPersonMapEFToPOCO(
			EFSalesPerson efSalesPerson,
			ApiResponse response)
		{
			if (efSalesPerson == null)
			{
				return;
			}

			response.AddSalesPerson(new POCOSalesPerson(efSalesPerson.Bonus, efSalesPerson.BusinessEntityID, efSalesPerson.CommissionPct, efSalesPerson.ModifiedDate, efSalesPerson.Rowguid, efSalesPerson.SalesLastYear, efSalesPerson.SalesQuota, efSalesPerson.SalesYTD, efSalesPerson.TerritoryID));

			this.SalesTerritoryMapEFToPOCO(efSalesPerson.SalesTerritory, response);
		}

		public virtual void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model,
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.QuotaDate,
				model.Rowguid,
				model.SalesQuota);
		}

		public virtual void SalesPersonQuotaHistoryMapEFToPOCO(
			EFSalesPersonQuotaHistory efSalesPersonQuotaHistory,
			ApiResponse response)
		{
			if (efSalesPersonQuotaHistory == null)
			{
				return;
			}

			response.AddSalesPersonQuotaHistory(new POCOSalesPersonQuotaHistory(efSalesPersonQuotaHistory.BusinessEntityID, efSalesPersonQuotaHistory.ModifiedDate, efSalesPersonQuotaHistory.QuotaDate, efSalesPersonQuotaHistory.Rowguid, efSalesPersonQuotaHistory.SalesQuota));

			this.SalesPersonMapEFToPOCO(efSalesPersonQuotaHistory.SalesPerson, response);
		}

		public virtual void SalesReasonMapModelToEF(
			int salesReasonID,
			SalesReasonModel model,
			EFSalesReason efSalesReason)
		{
			efSalesReason.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
		}

		public virtual void SalesReasonMapEFToPOCO(
			EFSalesReason efSalesReason,
			ApiResponse response)
		{
			if (efSalesReason == null)
			{
				return;
			}

			response.AddSalesReason(new POCOSalesReason(efSalesReason.ModifiedDate, efSalesReason.Name, efSalesReason.ReasonType, efSalesReason.SalesReasonID));
		}

		public virtual void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			SalesTaxRateModel model,
			EFSalesTaxRate efSalesTaxRate)
		{
			efSalesTaxRate.SetProperties(
				salesTaxRateID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceID,
				model.TaxRate,
				model.TaxType);
		}

		public virtual void SalesTaxRateMapEFToPOCO(
			EFSalesTaxRate efSalesTaxRate,
			ApiResponse response)
		{
			if (efSalesTaxRate == null)
			{
				return;
			}

			response.AddSalesTaxRate(new POCOSalesTaxRate(efSalesTaxRate.ModifiedDate, efSalesTaxRate.Name, efSalesTaxRate.Rowguid, efSalesTaxRate.SalesTaxRateID, efSalesTaxRate.StateProvinceID, efSalesTaxRate.TaxRate, efSalesTaxRate.TaxType));
		}

		public virtual void SalesTerritoryMapModelToEF(
			int territoryID,
			SalesTerritoryModel model,
			EFSalesTerritory efSalesTerritory)
		{
			efSalesTerritory.SetProperties(
				territoryID,
				model.CostLastYear,
				model.CostYTD,
				model.CountryRegionCode,
				model.@Group,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesYTD);
		}

		public virtual void SalesTerritoryMapEFToPOCO(
			EFSalesTerritory efSalesTerritory,
			ApiResponse response)
		{
			if (efSalesTerritory == null)
			{
				return;
			}

			response.AddSalesTerritory(new POCOSalesTerritory(efSalesTerritory.CostLastYear, efSalesTerritory.CostYTD, efSalesTerritory.CountryRegionCode, efSalesTerritory.@Group, efSalesTerritory.ModifiedDate, efSalesTerritory.Name, efSalesTerritory.Rowguid, efSalesTerritory.SalesLastYear, efSalesTerritory.SalesYTD, efSalesTerritory.TerritoryID));
		}

		public virtual void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			SalesTerritoryHistoryModel model,
			EFSalesTerritoryHistory efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.SetProperties(
				businessEntityID,
				model.EndDate,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.TerritoryID);
		}

		public virtual void SalesTerritoryHistoryMapEFToPOCO(
			EFSalesTerritoryHistory efSalesTerritoryHistory,
			ApiResponse response)
		{
			if (efSalesTerritoryHistory == null)
			{
				return;
			}

			response.AddSalesTerritoryHistory(new POCOSalesTerritoryHistory(efSalesTerritoryHistory.BusinessEntityID, efSalesTerritoryHistory.EndDate, efSalesTerritoryHistory.ModifiedDate, efSalesTerritoryHistory.Rowguid, efSalesTerritoryHistory.StartDate, efSalesTerritoryHistory.TerritoryID));

			this.SalesPersonMapEFToPOCO(efSalesTerritoryHistory.SalesPerson, response);

			this.SalesTerritoryMapEFToPOCO(efSalesTerritoryHistory.SalesTerritory, response);
		}

		public virtual void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ShoppingCartItemModel model,
			EFShoppingCartItem efShoppingCartItem)
		{
			efShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
		}

		public virtual void ShoppingCartItemMapEFToPOCO(
			EFShoppingCartItem efShoppingCartItem,
			ApiResponse response)
		{
			if (efShoppingCartItem == null)
			{
				return;
			}

			response.AddShoppingCartItem(new POCOShoppingCartItem(efShoppingCartItem.DateCreated, efShoppingCartItem.ModifiedDate, efShoppingCartItem.ProductID, efShoppingCartItem.Quantity, efShoppingCartItem.ShoppingCartID, efShoppingCartItem.ShoppingCartItemID));
		}

		public virtual void SpecialOfferMapModelToEF(
			int specialOfferID,
			SpecialOfferModel model,
			EFSpecialOffer efSpecialOffer)
		{
			efSpecialOffer.SetProperties(
				specialOfferID,
				model.Category,
				model.Description,
				model.DiscountPct,
				model.EndDate,
				model.MaxQty,
				model.MinQty,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.Type);
		}

		public virtual void SpecialOfferMapEFToPOCO(
			EFSpecialOffer efSpecialOffer,
			ApiResponse response)
		{
			if (efSpecialOffer == null)
			{
				return;
			}

			response.AddSpecialOffer(new POCOSpecialOffer(efSpecialOffer.Category, efSpecialOffer.Description, efSpecialOffer.DiscountPct, efSpecialOffer.EndDate, efSpecialOffer.MaxQty, efSpecialOffer.MinQty, efSpecialOffer.ModifiedDate, efSpecialOffer.Rowguid, efSpecialOffer.SpecialOfferID, efSpecialOffer.StartDate, efSpecialOffer.Type));
		}

		public virtual void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			SpecialOfferProductModel model,
			EFSpecialOfferProduct efSpecialOfferProduct)
		{
			efSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ModifiedDate,
				model.ProductID,
				model.Rowguid);
		}

		public virtual void SpecialOfferProductMapEFToPOCO(
			EFSpecialOfferProduct efSpecialOfferProduct,
			ApiResponse response)
		{
			if (efSpecialOfferProduct == null)
			{
				return;
			}

			response.AddSpecialOfferProduct(new POCOSpecialOfferProduct(efSpecialOfferProduct.ModifiedDate, efSpecialOfferProduct.ProductID, efSpecialOfferProduct.Rowguid, efSpecialOfferProduct.SpecialOfferID));

			this.SpecialOfferMapEFToPOCO(efSpecialOfferProduct.SpecialOffer, response);
		}

		public virtual void StoreMapModelToEF(
			int businessEntityID,
			StoreModel model,
			EFStore efStore)
		{
			efStore.SetProperties(
				businessEntityID,
				model.Demographics,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
		}

		public virtual void StoreMapEFToPOCO(
			EFStore efStore,
			ApiResponse response)
		{
			if (efStore == null)
			{
				return;
			}

			response.AddStore(new POCOStore(efStore.BusinessEntityID, efStore.Demographics, efStore.ModifiedDate, efStore.Name, efStore.Rowguid, efStore.SalesPersonID));

			this.SalesPersonMapEFToPOCO(efStore.SalesPerson, response);
		}
	}
}

/*<Codenesium>
    <Hash>0bdac39995ba681c7df7a78e2ed57c1f</Hash>
</Codenesium>*/