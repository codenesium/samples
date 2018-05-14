using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AWBuildVersionMapModelToEF(
			int systemInformationID,
			ApiAWBuildVersionModel model,
			AWBuildVersion efAWBuildVersion)
		{
			efAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
		}

		public virtual POCOAWBuildVersion AWBuildVersionMapEFToPOCO(
			AWBuildVersion efAWBuildVersion)
		{
			if (efAWBuildVersion == null)
			{
				return null;
			}

			return new POCOAWBuildVersion(efAWBuildVersion.Database_Version, efAWBuildVersion.ModifiedDate, efAWBuildVersion.SystemInformationID, efAWBuildVersion.VersionDate);
		}

		public virtual void DatabaseLogMapModelToEF(
			int databaseLogID,
			ApiDatabaseLogModel model,
			DatabaseLog efDatabaseLog)
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

		public virtual POCODatabaseLog DatabaseLogMapEFToPOCO(
			DatabaseLog efDatabaseLog)
		{
			if (efDatabaseLog == null)
			{
				return null;
			}

			return new POCODatabaseLog(efDatabaseLog.DatabaseLogID, efDatabaseLog.DatabaseUser, efDatabaseLog.@Event, efDatabaseLog.@Object, efDatabaseLog.PostTime, efDatabaseLog.Schema, efDatabaseLog.TSQL, efDatabaseLog.XmlEvent);
		}

		public virtual void ErrorLogMapModelToEF(
			int errorLogID,
			ApiErrorLogModel model,
			ErrorLog efErrorLog)
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

		public virtual POCOErrorLog ErrorLogMapEFToPOCO(
			ErrorLog efErrorLog)
		{
			if (efErrorLog == null)
			{
				return null;
			}

			return new POCOErrorLog(efErrorLog.ErrorLine, efErrorLog.ErrorLogID, efErrorLog.ErrorMessage, efErrorLog.ErrorNumber, efErrorLog.ErrorProcedure, efErrorLog.ErrorSeverity, efErrorLog.ErrorState, efErrorLog.ErrorTime, efErrorLog.UserName);
		}

		public virtual void DepartmentMapModelToEF(
			short departmentID,
			ApiDepartmentModel model,
			Department efDepartment)
		{
			efDepartment.SetProperties(
				departmentID,
				model.GroupName,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCODepartment DepartmentMapEFToPOCO(
			Department efDepartment)
		{
			if (efDepartment == null)
			{
				return null;
			}

			return new POCODepartment(efDepartment.DepartmentID, efDepartment.GroupName, efDepartment.ModifiedDate, efDepartment.Name);
		}

		public virtual void EmployeeMapModelToEF(
			int businessEntityID,
			ApiEmployeeModel model,
			Employee efEmployee)
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

		public virtual POCOEmployee EmployeeMapEFToPOCO(
			Employee efEmployee)
		{
			if (efEmployee == null)
			{
				return null;
			}

			return new POCOEmployee(efEmployee.BirthDate, efEmployee.BusinessEntityID, efEmployee.CurrentFlag, efEmployee.Gender, efEmployee.HireDate, efEmployee.JobTitle, efEmployee.LoginID, efEmployee.MaritalStatus, efEmployee.ModifiedDate, efEmployee.NationalIDNumber, efEmployee.OrganizationLevel, efEmployee.OrganizationNode, efEmployee.Rowguid, efEmployee.SalariedFlag, efEmployee.SickLeaveHours, efEmployee.VacationHours);
		}

		public virtual void EmployeeDepartmentHistoryMapModelToEF(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryModel model,
			EmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				model.DepartmentID,
				model.EndDate,
				model.ModifiedDate,
				model.ShiftID,
				model.StartDate);
		}

		public virtual POCOEmployeeDepartmentHistory EmployeeDepartmentHistoryMapEFToPOCO(
			EmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			if (efEmployeeDepartmentHistory == null)
			{
				return null;
			}

			return new POCOEmployeeDepartmentHistory(efEmployeeDepartmentHistory.BusinessEntityID, efEmployeeDepartmentHistory.DepartmentID, efEmployeeDepartmentHistory.EndDate, efEmployeeDepartmentHistory.ModifiedDate, efEmployeeDepartmentHistory.ShiftID, efEmployeeDepartmentHistory.StartDate);
		}

		public virtual void EmployeePayHistoryMapModelToEF(
			int businessEntityID,
			ApiEmployeePayHistoryModel model,
			EmployeePayHistory efEmployeePayHistory)
		{
			efEmployeePayHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PayFrequency,
				model.Rate,
				model.RateChangeDate);
		}

		public virtual POCOEmployeePayHistory EmployeePayHistoryMapEFToPOCO(
			EmployeePayHistory efEmployeePayHistory)
		{
			if (efEmployeePayHistory == null)
			{
				return null;
			}

			return new POCOEmployeePayHistory(efEmployeePayHistory.BusinessEntityID, efEmployeePayHistory.ModifiedDate, efEmployeePayHistory.PayFrequency, efEmployeePayHistory.Rate, efEmployeePayHistory.RateChangeDate);
		}

		public virtual void JobCandidateMapModelToEF(
			int jobCandidateID,
			ApiJobCandidateModel model,
			JobCandidate efJobCandidate)
		{
			efJobCandidate.SetProperties(
				jobCandidateID,
				model.BusinessEntityID,
				model.ModifiedDate,
				model.Resume);
		}

		public virtual POCOJobCandidate JobCandidateMapEFToPOCO(
			JobCandidate efJobCandidate)
		{
			if (efJobCandidate == null)
			{
				return null;
			}

			return new POCOJobCandidate(efJobCandidate.BusinessEntityID, efJobCandidate.JobCandidateID, efJobCandidate.ModifiedDate, efJobCandidate.Resume);
		}

		public virtual void ShiftMapModelToEF(
			int shiftID,
			ApiShiftModel model,
			Shift efShift)
		{
			efShift.SetProperties(
				shiftID,
				model.EndTime,
				model.ModifiedDate,
				model.Name,
				model.StartTime);
		}

		public virtual POCOShift ShiftMapEFToPOCO(
			Shift efShift)
		{
			if (efShift == null)
			{
				return null;
			}

			return new POCOShift(efShift.EndTime, efShift.ModifiedDate, efShift.Name, efShift.ShiftID, efShift.StartTime);
		}

		public virtual void AddressMapModelToEF(
			int addressID,
			ApiAddressModel model,
			Address efAddress)
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

		public virtual POCOAddress AddressMapEFToPOCO(
			Address efAddress)
		{
			if (efAddress == null)
			{
				return null;
			}

			return new POCOAddress(efAddress.AddressID, efAddress.AddressLine1, efAddress.AddressLine2, efAddress.City, efAddress.ModifiedDate, efAddress.PostalCode, efAddress.Rowguid, efAddress.SpatialLocation, efAddress.StateProvinceID);
		}

		public virtual void AddressTypeMapModelToEF(
			int addressTypeID,
			ApiAddressTypeModel model,
			AddressType efAddressType)
		{
			efAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual POCOAddressType AddressTypeMapEFToPOCO(
			AddressType efAddressType)
		{
			if (efAddressType == null)
			{
				return null;
			}

			return new POCOAddressType(efAddressType.AddressTypeID, efAddressType.ModifiedDate, efAddressType.Name, efAddressType.Rowguid);
		}

		public virtual void BusinessEntityMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityModel model,
			BusinessEntity efBusinessEntity)
		{
			efBusinessEntity.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual POCOBusinessEntity BusinessEntityMapEFToPOCO(
			BusinessEntity efBusinessEntity)
		{
			if (efBusinessEntity == null)
			{
				return null;
			}

			return new POCOBusinessEntity(efBusinessEntity.BusinessEntityID, efBusinessEntity.ModifiedDate, efBusinessEntity.Rowguid);
		}

		public virtual void BusinessEntityAddressMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityAddressModel model,
			BusinessEntityAddress efBusinessEntityAddress)
		{
			efBusinessEntityAddress.SetProperties(
				businessEntityID,
				model.AddressID,
				model.AddressTypeID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual POCOBusinessEntityAddress BusinessEntityAddressMapEFToPOCO(
			BusinessEntityAddress efBusinessEntityAddress)
		{
			if (efBusinessEntityAddress == null)
			{
				return null;
			}

			return new POCOBusinessEntityAddress(efBusinessEntityAddress.AddressID, efBusinessEntityAddress.AddressTypeID, efBusinessEntityAddress.BusinessEntityID, efBusinessEntityAddress.ModifiedDate, efBusinessEntityAddress.Rowguid);
		}

		public virtual void BusinessEntityContactMapModelToEF(
			int businessEntityID,
			ApiBusinessEntityContactModel model,
			BusinessEntityContact efBusinessEntityContact)
		{
			efBusinessEntityContact.SetProperties(
				businessEntityID,
				model.ContactTypeID,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid);
		}

		public virtual POCOBusinessEntityContact BusinessEntityContactMapEFToPOCO(
			BusinessEntityContact efBusinessEntityContact)
		{
			if (efBusinessEntityContact == null)
			{
				return null;
			}

			return new POCOBusinessEntityContact(efBusinessEntityContact.BusinessEntityID, efBusinessEntityContact.ContactTypeID, efBusinessEntityContact.ModifiedDate, efBusinessEntityContact.PersonID, efBusinessEntityContact.Rowguid);
		}

		public virtual void ContactTypeMapModelToEF(
			int contactTypeID,
			ApiContactTypeModel model,
			ContactType efContactType)
		{
			efContactType.SetProperties(
				contactTypeID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOContactType ContactTypeMapEFToPOCO(
			ContactType efContactType)
		{
			if (efContactType == null)
			{
				return null;
			}

			return new POCOContactType(efContactType.ContactTypeID, efContactType.ModifiedDate, efContactType.Name);
		}

		public virtual void CountryRegionMapModelToEF(
			string countryRegionCode,
			ApiCountryRegionModel model,
			CountryRegion efCountryRegion)
		{
			efCountryRegion.SetProperties(
				countryRegionCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOCountryRegion CountryRegionMapEFToPOCO(
			CountryRegion efCountryRegion)
		{
			if (efCountryRegion == null)
			{
				return null;
			}

			return new POCOCountryRegion(efCountryRegion.CountryRegionCode, efCountryRegion.ModifiedDate, efCountryRegion.Name);
		}

		public virtual void EmailAddressMapModelToEF(
			int businessEntityID,
			ApiEmailAddressModel model,
			EmailAddress efEmailAddress)
		{
			efEmailAddress.SetProperties(
				businessEntityID,
				model.EmailAddress1,
				model.EmailAddressID,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual POCOEmailAddress EmailAddressMapEFToPOCO(
			EmailAddress efEmailAddress)
		{
			if (efEmailAddress == null)
			{
				return null;
			}

			return new POCOEmailAddress(efEmailAddress.BusinessEntityID, efEmailAddress.EmailAddress1, efEmailAddress.EmailAddressID, efEmailAddress.ModifiedDate, efEmailAddress.Rowguid);
		}

		public virtual void PasswordMapModelToEF(
			int businessEntityID,
			ApiPasswordModel model,
			Password efPassword)
		{
			efPassword.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PasswordHash,
				model.PasswordSalt,
				model.Rowguid);
		}

		public virtual POCOPassword PasswordMapEFToPOCO(
			Password efPassword)
		{
			if (efPassword == null)
			{
				return null;
			}

			return new POCOPassword(efPassword.BusinessEntityID, efPassword.ModifiedDate, efPassword.PasswordHash, efPassword.PasswordSalt, efPassword.Rowguid);
		}

		public virtual void PersonMapModelToEF(
			int businessEntityID,
			ApiPersonModel model,
			Person efPerson)
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

		public virtual POCOPerson PersonMapEFToPOCO(
			Person efPerson)
		{
			if (efPerson == null)
			{
				return null;
			}

			return new POCOPerson(efPerson.AdditionalContactInfo, efPerson.BusinessEntityID, efPerson.Demographics, efPerson.EmailPromotion, efPerson.FirstName, efPerson.LastName, efPerson.MiddleName, efPerson.ModifiedDate, efPerson.NameStyle, efPerson.PersonType, efPerson.Rowguid, efPerson.Suffix, efPerson.Title);
		}

		public virtual void PersonPhoneMapModelToEF(
			int businessEntityID,
			ApiPersonPhoneModel model,
			PersonPhone efPersonPhone)
		{
			efPersonPhone.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PhoneNumber,
				model.PhoneNumberTypeID);
		}

		public virtual POCOPersonPhone PersonPhoneMapEFToPOCO(
			PersonPhone efPersonPhone)
		{
			if (efPersonPhone == null)
			{
				return null;
			}

			return new POCOPersonPhone(efPersonPhone.BusinessEntityID, efPersonPhone.ModifiedDate, efPersonPhone.PhoneNumber, efPersonPhone.PhoneNumberTypeID);
		}

		public virtual void PhoneNumberTypeMapModelToEF(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeModel model,
			PhoneNumberType efPhoneNumberType)
		{
			efPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOPhoneNumberType PhoneNumberTypeMapEFToPOCO(
			PhoneNumberType efPhoneNumberType)
		{
			if (efPhoneNumberType == null)
			{
				return null;
			}

			return new POCOPhoneNumberType(efPhoneNumberType.ModifiedDate, efPhoneNumberType.Name, efPhoneNumberType.PhoneNumberTypeID);
		}

		public virtual void StateProvinceMapModelToEF(
			int stateProvinceID,
			ApiStateProvinceModel model,
			StateProvince efStateProvince)
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

		public virtual POCOStateProvince StateProvinceMapEFToPOCO(
			StateProvince efStateProvince)
		{
			if (efStateProvince == null)
			{
				return null;
			}

			return new POCOStateProvince(efStateProvince.CountryRegionCode, efStateProvince.IsOnlyStateProvinceFlag, efStateProvince.ModifiedDate, efStateProvince.Name, efStateProvince.Rowguid, efStateProvince.StateProvinceCode, efStateProvince.StateProvinceID, efStateProvince.TerritoryID);
		}

		public virtual void BillOfMaterialsMapModelToEF(
			int billOfMaterialsID,
			ApiBillOfMaterialsModel model,
			BillOfMaterials efBillOfMaterials)
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

		public virtual POCOBillOfMaterials BillOfMaterialsMapEFToPOCO(
			BillOfMaterials efBillOfMaterials)
		{
			if (efBillOfMaterials == null)
			{
				return null;
			}

			return new POCOBillOfMaterials(efBillOfMaterials.BillOfMaterialsID, efBillOfMaterials.BOMLevel, efBillOfMaterials.ComponentID, efBillOfMaterials.EndDate, efBillOfMaterials.ModifiedDate, efBillOfMaterials.PerAssemblyQty, efBillOfMaterials.ProductAssemblyID, efBillOfMaterials.StartDate, efBillOfMaterials.UnitMeasureCode);
		}

		public virtual void CultureMapModelToEF(
			string cultureID,
			ApiCultureModel model,
			Culture efCulture)
		{
			efCulture.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOCulture CultureMapEFToPOCO(
			Culture efCulture)
		{
			if (efCulture == null)
			{
				return null;
			}

			return new POCOCulture(efCulture.CultureID, efCulture.ModifiedDate, efCulture.Name);
		}

		public virtual void DocumentMapModelToEF(
			Guid documentNode,
			ApiDocumentModel model,
			Document efDocument)
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

		public virtual POCODocument DocumentMapEFToPOCO(
			Document efDocument)
		{
			if (efDocument == null)
			{
				return null;
			}

			return new POCODocument(efDocument.ChangeNumber, efDocument.Document1, efDocument.DocumentLevel, efDocument.DocumentNode, efDocument.DocumentSummary, efDocument.FileExtension, efDocument.FileName, efDocument.FolderFlag, efDocument.ModifiedDate, efDocument.Owner, efDocument.Revision, efDocument.Rowguid, efDocument.Status, efDocument.Title);
		}

		public virtual void IllustrationMapModelToEF(
			int illustrationID,
			ApiIllustrationModel model,
			Illustration efIllustration)
		{
			efIllustration.SetProperties(
				illustrationID,
				model.Diagram,
				model.ModifiedDate);
		}

		public virtual POCOIllustration IllustrationMapEFToPOCO(
			Illustration efIllustration)
		{
			if (efIllustration == null)
			{
				return null;
			}

			return new POCOIllustration(efIllustration.Diagram, efIllustration.IllustrationID, efIllustration.ModifiedDate);
		}

		public virtual void LocationMapModelToEF(
			short locationID,
			ApiLocationModel model,
			Location efLocation)
		{
			efLocation.SetProperties(
				locationID,
				model.Availability,
				model.CostRate,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOLocation LocationMapEFToPOCO(
			Location efLocation)
		{
			if (efLocation == null)
			{
				return null;
			}

			return new POCOLocation(efLocation.Availability, efLocation.CostRate, efLocation.LocationID, efLocation.ModifiedDate, efLocation.Name);
		}

		public virtual void ProductMapModelToEF(
			int productID,
			ApiProductModel model,
			Product efProduct)
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

		public virtual POCOProduct ProductMapEFToPOCO(
			Product efProduct)
		{
			if (efProduct == null)
			{
				return null;
			}

			return new POCOProduct(efProduct.@Class, efProduct.Color, efProduct.DaysToManufacture, efProduct.DiscontinuedDate, efProduct.FinishedGoodsFlag, efProduct.ListPrice, efProduct.MakeFlag, efProduct.ModifiedDate, efProduct.Name, efProduct.ProductID, efProduct.ProductLine, efProduct.ProductModelID, efProduct.ProductNumber, efProduct.ProductSubcategoryID, efProduct.ReorderPoint, efProduct.Rowguid, efProduct.SafetyStockLevel, efProduct.SellEndDate, efProduct.SellStartDate, efProduct.Size, efProduct.SizeUnitMeasureCode, efProduct.StandardCost, efProduct.Style, efProduct.Weight, efProduct.WeightUnitMeasureCode);
		}

		public virtual void ProductCategoryMapModelToEF(
			int productCategoryID,
			ApiProductCategoryModel model,
			ProductCategory efProductCategory)
		{
			efProductCategory.SetProperties(
				productCategoryID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual POCOProductCategory ProductCategoryMapEFToPOCO(
			ProductCategory efProductCategory)
		{
			if (efProductCategory == null)
			{
				return null;
			}

			return new POCOProductCategory(efProductCategory.ModifiedDate, efProductCategory.Name, efProductCategory.ProductCategoryID, efProductCategory.Rowguid);
		}

		public virtual void ProductCostHistoryMapModelToEF(
			int productID,
			ApiProductCostHistoryModel model,
			ProductCostHistory efProductCostHistory)
		{
			efProductCostHistory.SetProperties(
				productID,
				model.EndDate,
				model.ModifiedDate,
				model.StandardCost,
				model.StartDate);
		}

		public virtual POCOProductCostHistory ProductCostHistoryMapEFToPOCO(
			ProductCostHistory efProductCostHistory)
		{
			if (efProductCostHistory == null)
			{
				return null;
			}

			return new POCOProductCostHistory(efProductCostHistory.EndDate, efProductCostHistory.ModifiedDate, efProductCostHistory.ProductID, efProductCostHistory.StandardCost, efProductCostHistory.StartDate);
		}

		public virtual void ProductDescriptionMapModelToEF(
			int productDescriptionID,
			ApiProductDescriptionModel model,
			ProductDescription efProductDescription)
		{
			efProductDescription.SetProperties(
				productDescriptionID,
				model.Description,
				model.ModifiedDate,
				model.Rowguid);
		}

		public virtual POCOProductDescription ProductDescriptionMapEFToPOCO(
			ProductDescription efProductDescription)
		{
			if (efProductDescription == null)
			{
				return null;
			}

			return new POCOProductDescription(efProductDescription.Description, efProductDescription.ModifiedDate, efProductDescription.ProductDescriptionID, efProductDescription.Rowguid);
		}

		public virtual void ProductDocumentMapModelToEF(
			int productID,
			ApiProductDocumentModel model,
			ProductDocument efProductDocument)
		{
			efProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
		}

		public virtual POCOProductDocument ProductDocumentMapEFToPOCO(
			ProductDocument efProductDocument)
		{
			if (efProductDocument == null)
			{
				return null;
			}

			return new POCOProductDocument(efProductDocument.DocumentNode, efProductDocument.ModifiedDate, efProductDocument.ProductID);
		}

		public virtual void ProductInventoryMapModelToEF(
			int productID,
			ApiProductInventoryModel model,
			ProductInventory efProductInventory)
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

		public virtual POCOProductInventory ProductInventoryMapEFToPOCO(
			ProductInventory efProductInventory)
		{
			if (efProductInventory == null)
			{
				return null;
			}

			return new POCOProductInventory(efProductInventory.Bin, efProductInventory.LocationID, efProductInventory.ModifiedDate, efProductInventory.ProductID, efProductInventory.Quantity, efProductInventory.Rowguid, efProductInventory.Shelf);
		}

		public virtual void ProductListPriceHistoryMapModelToEF(
			int productID,
			ApiProductListPriceHistoryModel model,
			ProductListPriceHistory efProductListPriceHistory)
		{
			efProductListPriceHistory.SetProperties(
				productID,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate,
				model.StartDate);
		}

		public virtual POCOProductListPriceHistory ProductListPriceHistoryMapEFToPOCO(
			ProductListPriceHistory efProductListPriceHistory)
		{
			if (efProductListPriceHistory == null)
			{
				return null;
			}

			return new POCOProductListPriceHistory(efProductListPriceHistory.EndDate, efProductListPriceHistory.ListPrice, efProductListPriceHistory.ModifiedDate, efProductListPriceHistory.ProductID, efProductListPriceHistory.StartDate);
		}

		public virtual void ProductModelMapModelToEF(
			int productModelID,
			ApiProductModelModel model,
			ProductModel efProductModel)
		{
			efProductModel.SetProperties(
				productModelID,
				model.CatalogDescription,
				model.Instructions,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
		}

		public virtual POCOProductModel ProductModelMapEFToPOCO(
			ProductModel efProductModel)
		{
			if (efProductModel == null)
			{
				return null;
			}

			return new POCOProductModel(efProductModel.CatalogDescription, efProductModel.Instructions, efProductModel.ModifiedDate, efProductModel.Name, efProductModel.ProductModelID, efProductModel.Rowguid);
		}

		public virtual void ProductModelIllustrationMapModelToEF(
			int productModelID,
			ApiProductModelIllustrationModel model,
			ProductModelIllustration efProductModelIllustration)
		{
			efProductModelIllustration.SetProperties(
				productModelID,
				model.IllustrationID,
				model.ModifiedDate);
		}

		public virtual POCOProductModelIllustration ProductModelIllustrationMapEFToPOCO(
			ProductModelIllustration efProductModelIllustration)
		{
			if (efProductModelIllustration == null)
			{
				return null;
			}

			return new POCOProductModelIllustration(efProductModelIllustration.IllustrationID, efProductModelIllustration.ModifiedDate, efProductModelIllustration.ProductModelID);
		}

		public virtual void ProductModelProductDescriptionCultureMapModelToEF(
			int productModelID,
			ApiProductModelProductDescriptionCultureModel model,
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				model.CultureID,
				model.ModifiedDate,
				model.ProductDescriptionID);
		}

		public virtual POCOProductModelProductDescriptionCulture ProductModelProductDescriptionCultureMapEFToPOCO(
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture)
		{
			if (efProductModelProductDescriptionCulture == null)
			{
				return null;
			}

			return new POCOProductModelProductDescriptionCulture(efProductModelProductDescriptionCulture.CultureID, efProductModelProductDescriptionCulture.ModifiedDate, efProductModelProductDescriptionCulture.ProductDescriptionID, efProductModelProductDescriptionCulture.ProductModelID);
		}

		public virtual void ProductPhotoMapModelToEF(
			int productPhotoID,
			ApiProductPhotoModel model,
			ProductPhoto efProductPhoto)
		{
			efProductPhoto.SetProperties(
				productPhotoID,
				model.LargePhoto,
				model.LargePhotoFileName,
				model.ModifiedDate,
				model.ThumbNailPhoto,
				model.ThumbnailPhotoFileName);
		}

		public virtual POCOProductPhoto ProductPhotoMapEFToPOCO(
			ProductPhoto efProductPhoto)
		{
			if (efProductPhoto == null)
			{
				return null;
			}

			return new POCOProductPhoto(efProductPhoto.LargePhoto, efProductPhoto.LargePhotoFileName, efProductPhoto.ModifiedDate, efProductPhoto.ProductPhotoID, efProductPhoto.ThumbNailPhoto, efProductPhoto.ThumbnailPhotoFileName);
		}

		public virtual void ProductProductPhotoMapModelToEF(
			int productID,
			ApiProductProductPhotoModel model,
			ProductProductPhoto efProductProductPhoto)
		{
			efProductProductPhoto.SetProperties(
				productID,
				model.ModifiedDate,
				model.Primary,
				model.ProductPhotoID);
		}

		public virtual POCOProductProductPhoto ProductProductPhotoMapEFToPOCO(
			ProductProductPhoto efProductProductPhoto)
		{
			if (efProductProductPhoto == null)
			{
				return null;
			}

			return new POCOProductProductPhoto(efProductProductPhoto.ModifiedDate, efProductProductPhoto.Primary, efProductProductPhoto.ProductID, efProductProductPhoto.ProductPhotoID);
		}

		public virtual void ProductReviewMapModelToEF(
			int productReviewID,
			ApiProductReviewModel model,
			ProductReview efProductReview)
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

		public virtual POCOProductReview ProductReviewMapEFToPOCO(
			ProductReview efProductReview)
		{
			if (efProductReview == null)
			{
				return null;
			}

			return new POCOProductReview(efProductReview.Comments, efProductReview.EmailAddress, efProductReview.ModifiedDate, efProductReview.ProductID, efProductReview.ProductReviewID, efProductReview.Rating, efProductReview.ReviewDate, efProductReview.ReviewerName);
		}

		public virtual void ProductSubcategoryMapModelToEF(
			int productSubcategoryID,
			ApiProductSubcategoryModel model,
			ProductSubcategory efProductSubcategory)
		{
			efProductSubcategory.SetProperties(
				productSubcategoryID,
				model.ModifiedDate,
				model.Name,
				model.ProductCategoryID,
				model.Rowguid);
		}

		public virtual POCOProductSubcategory ProductSubcategoryMapEFToPOCO(
			ProductSubcategory efProductSubcategory)
		{
			if (efProductSubcategory == null)
			{
				return null;
			}

			return new POCOProductSubcategory(efProductSubcategory.ModifiedDate, efProductSubcategory.Name, efProductSubcategory.ProductCategoryID, efProductSubcategory.ProductSubcategoryID, efProductSubcategory.Rowguid);
		}

		public virtual void ScrapReasonMapModelToEF(
			short scrapReasonID,
			ApiScrapReasonModel model,
			ScrapReason efScrapReason)
		{
			efScrapReason.SetProperties(
				scrapReasonID,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOScrapReason ScrapReasonMapEFToPOCO(
			ScrapReason efScrapReason)
		{
			if (efScrapReason == null)
			{
				return null;
			}

			return new POCOScrapReason(efScrapReason.ModifiedDate, efScrapReason.Name, efScrapReason.ScrapReasonID);
		}

		public virtual void TransactionHistoryMapModelToEF(
			int transactionID,
			ApiTransactionHistoryModel model,
			TransactionHistory efTransactionHistory)
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

		public virtual POCOTransactionHistory TransactionHistoryMapEFToPOCO(
			TransactionHistory efTransactionHistory)
		{
			if (efTransactionHistory == null)
			{
				return null;
			}

			return new POCOTransactionHistory(efTransactionHistory.ActualCost, efTransactionHistory.ModifiedDate, efTransactionHistory.ProductID, efTransactionHistory.Quantity, efTransactionHistory.ReferenceOrderID, efTransactionHistory.ReferenceOrderLineID, efTransactionHistory.TransactionDate, efTransactionHistory.TransactionID, efTransactionHistory.TransactionType);
		}

		public virtual void TransactionHistoryArchiveMapModelToEF(
			int transactionID,
			ApiTransactionHistoryArchiveModel model,
			TransactionHistoryArchive efTransactionHistoryArchive)
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

		public virtual POCOTransactionHistoryArchive TransactionHistoryArchiveMapEFToPOCO(
			TransactionHistoryArchive efTransactionHistoryArchive)
		{
			if (efTransactionHistoryArchive == null)
			{
				return null;
			}

			return new POCOTransactionHistoryArchive(efTransactionHistoryArchive.ActualCost, efTransactionHistoryArchive.ModifiedDate, efTransactionHistoryArchive.ProductID, efTransactionHistoryArchive.Quantity, efTransactionHistoryArchive.ReferenceOrderID, efTransactionHistoryArchive.ReferenceOrderLineID, efTransactionHistoryArchive.TransactionDate, efTransactionHistoryArchive.TransactionID, efTransactionHistoryArchive.TransactionType);
		}

		public virtual void UnitMeasureMapModelToEF(
			string unitMeasureCode,
			ApiUnitMeasureModel model,
			UnitMeasure efUnitMeasure)
		{
			efUnitMeasure.SetProperties(
				unitMeasureCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOUnitMeasure UnitMeasureMapEFToPOCO(
			UnitMeasure efUnitMeasure)
		{
			if (efUnitMeasure == null)
			{
				return null;
			}

			return new POCOUnitMeasure(efUnitMeasure.ModifiedDate, efUnitMeasure.Name, efUnitMeasure.UnitMeasureCode);
		}

		public virtual void WorkOrderMapModelToEF(
			int workOrderID,
			ApiWorkOrderModel model,
			WorkOrder efWorkOrder)
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

		public virtual POCOWorkOrder WorkOrderMapEFToPOCO(
			WorkOrder efWorkOrder)
		{
			if (efWorkOrder == null)
			{
				return null;
			}

			return new POCOWorkOrder(efWorkOrder.DueDate, efWorkOrder.EndDate, efWorkOrder.ModifiedDate, efWorkOrder.OrderQty, efWorkOrder.ProductID, efWorkOrder.ScrappedQty, efWorkOrder.ScrapReasonID, efWorkOrder.StartDate, efWorkOrder.StockedQty, efWorkOrder.WorkOrderID);
		}

		public virtual void WorkOrderRoutingMapModelToEF(
			int workOrderID,
			ApiWorkOrderRoutingModel model,
			WorkOrderRouting efWorkOrderRouting)
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

		public virtual POCOWorkOrderRouting WorkOrderRoutingMapEFToPOCO(
			WorkOrderRouting efWorkOrderRouting)
		{
			if (efWorkOrderRouting == null)
			{
				return null;
			}

			return new POCOWorkOrderRouting(efWorkOrderRouting.ActualCost, efWorkOrderRouting.ActualEndDate, efWorkOrderRouting.ActualResourceHrs, efWorkOrderRouting.ActualStartDate, efWorkOrderRouting.LocationID, efWorkOrderRouting.ModifiedDate, efWorkOrderRouting.OperationSequence, efWorkOrderRouting.PlannedCost, efWorkOrderRouting.ProductID, efWorkOrderRouting.ScheduledEndDate, efWorkOrderRouting.ScheduledStartDate, efWorkOrderRouting.WorkOrderID);
		}

		public virtual void ProductVendorMapModelToEF(
			int productID,
			ApiProductVendorModel model,
			ProductVendor efProductVendor)
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

		public virtual POCOProductVendor ProductVendorMapEFToPOCO(
			ProductVendor efProductVendor)
		{
			if (efProductVendor == null)
			{
				return null;
			}

			return new POCOProductVendor(efProductVendor.AverageLeadTime, efProductVendor.BusinessEntityID, efProductVendor.LastReceiptCost, efProductVendor.LastReceiptDate, efProductVendor.MaxOrderQty, efProductVendor.MinOrderQty, efProductVendor.ModifiedDate, efProductVendor.OnOrderQty, efProductVendor.ProductID, efProductVendor.StandardPrice, efProductVendor.UnitMeasureCode);
		}

		public virtual void PurchaseOrderDetailMapModelToEF(
			int purchaseOrderID,
			ApiPurchaseOrderDetailModel model,
			PurchaseOrderDetail efPurchaseOrderDetail)
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

		public virtual POCOPurchaseOrderDetail PurchaseOrderDetailMapEFToPOCO(
			PurchaseOrderDetail efPurchaseOrderDetail)
		{
			if (efPurchaseOrderDetail == null)
			{
				return null;
			}

			return new POCOPurchaseOrderDetail(efPurchaseOrderDetail.DueDate, efPurchaseOrderDetail.LineTotal, efPurchaseOrderDetail.ModifiedDate, efPurchaseOrderDetail.OrderQty, efPurchaseOrderDetail.ProductID, efPurchaseOrderDetail.PurchaseOrderDetailID, efPurchaseOrderDetail.PurchaseOrderID, efPurchaseOrderDetail.ReceivedQty, efPurchaseOrderDetail.RejectedQty, efPurchaseOrderDetail.StockedQty, efPurchaseOrderDetail.UnitPrice);
		}

		public virtual void PurchaseOrderHeaderMapModelToEF(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderModel model,
			PurchaseOrderHeader efPurchaseOrderHeader)
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

		public virtual POCOPurchaseOrderHeader PurchaseOrderHeaderMapEFToPOCO(
			PurchaseOrderHeader efPurchaseOrderHeader)
		{
			if (efPurchaseOrderHeader == null)
			{
				return null;
			}

			return new POCOPurchaseOrderHeader(efPurchaseOrderHeader.EmployeeID, efPurchaseOrderHeader.Freight, efPurchaseOrderHeader.ModifiedDate, efPurchaseOrderHeader.OrderDate, efPurchaseOrderHeader.PurchaseOrderID, efPurchaseOrderHeader.RevisionNumber, efPurchaseOrderHeader.ShipDate, efPurchaseOrderHeader.ShipMethodID, efPurchaseOrderHeader.Status, efPurchaseOrderHeader.SubTotal, efPurchaseOrderHeader.TaxAmt, efPurchaseOrderHeader.TotalDue, efPurchaseOrderHeader.VendorID);
		}

		public virtual void ShipMethodMapModelToEF(
			int shipMethodID,
			ApiShipMethodModel model,
			ShipMethod efShipMethod)
		{
			efShipMethod.SetProperties(
				shipMethodID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.ShipBase,
				model.ShipRate);
		}

		public virtual POCOShipMethod ShipMethodMapEFToPOCO(
			ShipMethod efShipMethod)
		{
			if (efShipMethod == null)
			{
				return null;
			}

			return new POCOShipMethod(efShipMethod.ModifiedDate, efShipMethod.Name, efShipMethod.Rowguid, efShipMethod.ShipBase, efShipMethod.ShipMethodID, efShipMethod.ShipRate);
		}

		public virtual void VendorMapModelToEF(
			int businessEntityID,
			ApiVendorModel model,
			Vendor efVendor)
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

		public virtual POCOVendor VendorMapEFToPOCO(
			Vendor efVendor)
		{
			if (efVendor == null)
			{
				return null;
			}

			return new POCOVendor(efVendor.AccountNumber, efVendor.ActiveFlag, efVendor.BusinessEntityID, efVendor.CreditRating, efVendor.ModifiedDate, efVendor.Name, efVendor.PreferredVendorStatus, efVendor.PurchasingWebServiceURL);
		}

		public virtual void CountryRegionCurrencyMapModelToEF(
			string countryRegionCode,
			ApiCountryRegionCurrencyModel model,
			CountryRegionCurrency efCountryRegionCurrency)
		{
			efCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
		}

		public virtual POCOCountryRegionCurrency CountryRegionCurrencyMapEFToPOCO(
			CountryRegionCurrency efCountryRegionCurrency)
		{
			if (efCountryRegionCurrency == null)
			{
				return null;
			}

			return new POCOCountryRegionCurrency(efCountryRegionCurrency.CountryRegionCode, efCountryRegionCurrency.CurrencyCode, efCountryRegionCurrency.ModifiedDate);
		}

		public virtual void CreditCardMapModelToEF(
			int creditCardID,
			ApiCreditCardModel model,
			CreditCard efCreditCard)
		{
			efCreditCard.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
		}

		public virtual POCOCreditCard CreditCardMapEFToPOCO(
			CreditCard efCreditCard)
		{
			if (efCreditCard == null)
			{
				return null;
			}

			return new POCOCreditCard(efCreditCard.CardNumber, efCreditCard.CardType, efCreditCard.CreditCardID, efCreditCard.ExpMonth, efCreditCard.ExpYear, efCreditCard.ModifiedDate);
		}

		public virtual void CurrencyMapModelToEF(
			string currencyCode,
			ApiCurrencyModel model,
			Currency efCurrency)
		{
			efCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
		}

		public virtual POCOCurrency CurrencyMapEFToPOCO(
			Currency efCurrency)
		{
			if (efCurrency == null)
			{
				return null;
			}

			return new POCOCurrency(efCurrency.CurrencyCode, efCurrency.ModifiedDate, efCurrency.Name);
		}

		public virtual void CurrencyRateMapModelToEF(
			int currencyRateID,
			ApiCurrencyRateModel model,
			CurrencyRate efCurrencyRate)
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

		public virtual POCOCurrencyRate CurrencyRateMapEFToPOCO(
			CurrencyRate efCurrencyRate)
		{
			if (efCurrencyRate == null)
			{
				return null;
			}

			return new POCOCurrencyRate(efCurrencyRate.AverageRate, efCurrencyRate.CurrencyRateDate, efCurrencyRate.CurrencyRateID, efCurrencyRate.EndOfDayRate, efCurrencyRate.FromCurrencyCode, efCurrencyRate.ModifiedDate, efCurrencyRate.ToCurrencyCode);
		}

		public virtual void CustomerMapModelToEF(
			int customerID,
			ApiCustomerModel model,
			Customer efCustomer)
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

		public virtual POCOCustomer CustomerMapEFToPOCO(
			Customer efCustomer)
		{
			if (efCustomer == null)
			{
				return null;
			}

			return new POCOCustomer(efCustomer.AccountNumber, efCustomer.CustomerID, efCustomer.ModifiedDate, efCustomer.PersonID, efCustomer.Rowguid, efCustomer.StoreID, efCustomer.TerritoryID);
		}

		public virtual void PersonCreditCardMapModelToEF(
			int businessEntityID,
			ApiPersonCreditCardModel model,
			PersonCreditCard efPersonCreditCard)
		{
			efPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
		}

		public virtual POCOPersonCreditCard PersonCreditCardMapEFToPOCO(
			PersonCreditCard efPersonCreditCard)
		{
			if (efPersonCreditCard == null)
			{
				return null;
			}

			return new POCOPersonCreditCard(efPersonCreditCard.BusinessEntityID, efPersonCreditCard.CreditCardID, efPersonCreditCard.ModifiedDate);
		}

		public virtual void SalesOrderDetailMapModelToEF(
			int salesOrderID,
			ApiSalesOrderDetailModel model,
			SalesOrderDetail efSalesOrderDetail)
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

		public virtual POCOSalesOrderDetail SalesOrderDetailMapEFToPOCO(
			SalesOrderDetail efSalesOrderDetail)
		{
			if (efSalesOrderDetail == null)
			{
				return null;
			}

			return new POCOSalesOrderDetail(efSalesOrderDetail.CarrierTrackingNumber, efSalesOrderDetail.LineTotal, efSalesOrderDetail.ModifiedDate, efSalesOrderDetail.OrderQty, efSalesOrderDetail.ProductID, efSalesOrderDetail.Rowguid, efSalesOrderDetail.SalesOrderDetailID, efSalesOrderDetail.SalesOrderID, efSalesOrderDetail.SpecialOfferID, efSalesOrderDetail.UnitPrice, efSalesOrderDetail.UnitPriceDiscount);
		}

		public virtual void SalesOrderHeaderMapModelToEF(
			int salesOrderID,
			ApiSalesOrderHeaderModel model,
			SalesOrderHeader efSalesOrderHeader)
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

		public virtual POCOSalesOrderHeader SalesOrderHeaderMapEFToPOCO(
			SalesOrderHeader efSalesOrderHeader)
		{
			if (efSalesOrderHeader == null)
			{
				return null;
			}

			return new POCOSalesOrderHeader(efSalesOrderHeader.AccountNumber, efSalesOrderHeader.BillToAddressID, efSalesOrderHeader.Comment, efSalesOrderHeader.CreditCardApprovalCode, efSalesOrderHeader.CreditCardID, efSalesOrderHeader.CurrencyRateID, efSalesOrderHeader.CustomerID, efSalesOrderHeader.DueDate, efSalesOrderHeader.Freight, efSalesOrderHeader.ModifiedDate, efSalesOrderHeader.OnlineOrderFlag, efSalesOrderHeader.OrderDate, efSalesOrderHeader.PurchaseOrderNumber, efSalesOrderHeader.RevisionNumber, efSalesOrderHeader.Rowguid, efSalesOrderHeader.SalesOrderID, efSalesOrderHeader.SalesOrderNumber, efSalesOrderHeader.SalesPersonID, efSalesOrderHeader.ShipDate, efSalesOrderHeader.ShipMethodID, efSalesOrderHeader.ShipToAddressID, efSalesOrderHeader.Status, efSalesOrderHeader.SubTotal, efSalesOrderHeader.TaxAmt, efSalesOrderHeader.TerritoryID, efSalesOrderHeader.TotalDue);
		}

		public virtual void SalesOrderHeaderSalesReasonMapModelToEF(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonModel model,
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason)
		{
			efSalesOrderHeaderSalesReason.SetProperties(
				salesOrderID,
				model.ModifiedDate,
				model.SalesReasonID);
		}

		public virtual POCOSalesOrderHeaderSalesReason SalesOrderHeaderSalesReasonMapEFToPOCO(
			SalesOrderHeaderSalesReason efSalesOrderHeaderSalesReason)
		{
			if (efSalesOrderHeaderSalesReason == null)
			{
				return null;
			}

			return new POCOSalesOrderHeaderSalesReason(efSalesOrderHeaderSalesReason.ModifiedDate, efSalesOrderHeaderSalesReason.SalesOrderID, efSalesOrderHeaderSalesReason.SalesReasonID);
		}

		public virtual void SalesPersonMapModelToEF(
			int businessEntityID,
			ApiSalesPersonModel model,
			SalesPerson efSalesPerson)
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

		public virtual POCOSalesPerson SalesPersonMapEFToPOCO(
			SalesPerson efSalesPerson)
		{
			if (efSalesPerson == null)
			{
				return null;
			}

			return new POCOSalesPerson(efSalesPerson.Bonus, efSalesPerson.BusinessEntityID, efSalesPerson.CommissionPct, efSalesPerson.ModifiedDate, efSalesPerson.Rowguid, efSalesPerson.SalesLastYear, efSalesPerson.SalesQuota, efSalesPerson.SalesYTD, efSalesPerson.TerritoryID);
		}

		public virtual void SalesPersonQuotaHistoryMapModelToEF(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryModel model,
			SalesPersonQuotaHistory efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.QuotaDate,
				model.Rowguid,
				model.SalesQuota);
		}

		public virtual POCOSalesPersonQuotaHistory SalesPersonQuotaHistoryMapEFToPOCO(
			SalesPersonQuotaHistory efSalesPersonQuotaHistory)
		{
			if (efSalesPersonQuotaHistory == null)
			{
				return null;
			}

			return new POCOSalesPersonQuotaHistory(efSalesPersonQuotaHistory.BusinessEntityID, efSalesPersonQuotaHistory.ModifiedDate, efSalesPersonQuotaHistory.QuotaDate, efSalesPersonQuotaHistory.Rowguid, efSalesPersonQuotaHistory.SalesQuota);
		}

		public virtual void SalesReasonMapModelToEF(
			int salesReasonID,
			ApiSalesReasonModel model,
			SalesReason efSalesReason)
		{
			efSalesReason.SetProperties(
				salesReasonID,
				model.ModifiedDate,
				model.Name,
				model.ReasonType);
		}

		public virtual POCOSalesReason SalesReasonMapEFToPOCO(
			SalesReason efSalesReason)
		{
			if (efSalesReason == null)
			{
				return null;
			}

			return new POCOSalesReason(efSalesReason.ModifiedDate, efSalesReason.Name, efSalesReason.ReasonType, efSalesReason.SalesReasonID);
		}

		public virtual void SalesTaxRateMapModelToEF(
			int salesTaxRateID,
			ApiSalesTaxRateModel model,
			SalesTaxRate efSalesTaxRate)
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

		public virtual POCOSalesTaxRate SalesTaxRateMapEFToPOCO(
			SalesTaxRate efSalesTaxRate)
		{
			if (efSalesTaxRate == null)
			{
				return null;
			}

			return new POCOSalesTaxRate(efSalesTaxRate.ModifiedDate, efSalesTaxRate.Name, efSalesTaxRate.Rowguid, efSalesTaxRate.SalesTaxRateID, efSalesTaxRate.StateProvinceID, efSalesTaxRate.TaxRate, efSalesTaxRate.TaxType);
		}

		public virtual void SalesTerritoryMapModelToEF(
			int territoryID,
			ApiSalesTerritoryModel model,
			SalesTerritory efSalesTerritory)
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

		public virtual POCOSalesTerritory SalesTerritoryMapEFToPOCO(
			SalesTerritory efSalesTerritory)
		{
			if (efSalesTerritory == null)
			{
				return null;
			}

			return new POCOSalesTerritory(efSalesTerritory.CostLastYear, efSalesTerritory.CostYTD, efSalesTerritory.CountryRegionCode, efSalesTerritory.@Group, efSalesTerritory.ModifiedDate, efSalesTerritory.Name, efSalesTerritory.Rowguid, efSalesTerritory.SalesLastYear, efSalesTerritory.SalesYTD, efSalesTerritory.TerritoryID);
		}

		public virtual void SalesTerritoryHistoryMapModelToEF(
			int businessEntityID,
			ApiSalesTerritoryHistoryModel model,
			SalesTerritoryHistory efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.SetProperties(
				businessEntityID,
				model.EndDate,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.TerritoryID);
		}

		public virtual POCOSalesTerritoryHistory SalesTerritoryHistoryMapEFToPOCO(
			SalesTerritoryHistory efSalesTerritoryHistory)
		{
			if (efSalesTerritoryHistory == null)
			{
				return null;
			}

			return new POCOSalesTerritoryHistory(efSalesTerritoryHistory.BusinessEntityID, efSalesTerritoryHistory.EndDate, efSalesTerritoryHistory.ModifiedDate, efSalesTerritoryHistory.Rowguid, efSalesTerritoryHistory.StartDate, efSalesTerritoryHistory.TerritoryID);
		}

		public virtual void ShoppingCartItemMapModelToEF(
			int shoppingCartItemID,
			ApiShoppingCartItemModel model,
			ShoppingCartItem efShoppingCartItem)
		{
			efShoppingCartItem.SetProperties(
				shoppingCartItemID,
				model.DateCreated,
				model.ModifiedDate,
				model.ProductID,
				model.Quantity,
				model.ShoppingCartID);
		}

		public virtual POCOShoppingCartItem ShoppingCartItemMapEFToPOCO(
			ShoppingCartItem efShoppingCartItem)
		{
			if (efShoppingCartItem == null)
			{
				return null;
			}

			return new POCOShoppingCartItem(efShoppingCartItem.DateCreated, efShoppingCartItem.ModifiedDate, efShoppingCartItem.ProductID, efShoppingCartItem.Quantity, efShoppingCartItem.ShoppingCartID, efShoppingCartItem.ShoppingCartItemID);
		}

		public virtual void SpecialOfferMapModelToEF(
			int specialOfferID,
			ApiSpecialOfferModel model,
			SpecialOffer efSpecialOffer)
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

		public virtual POCOSpecialOffer SpecialOfferMapEFToPOCO(
			SpecialOffer efSpecialOffer)
		{
			if (efSpecialOffer == null)
			{
				return null;
			}

			return new POCOSpecialOffer(efSpecialOffer.Category, efSpecialOffer.Description, efSpecialOffer.DiscountPct, efSpecialOffer.EndDate, efSpecialOffer.MaxQty, efSpecialOffer.MinQty, efSpecialOffer.ModifiedDate, efSpecialOffer.Rowguid, efSpecialOffer.SpecialOfferID, efSpecialOffer.StartDate, efSpecialOffer.Type);
		}

		public virtual void SpecialOfferProductMapModelToEF(
			int specialOfferID,
			ApiSpecialOfferProductModel model,
			SpecialOfferProduct efSpecialOfferProduct)
		{
			efSpecialOfferProduct.SetProperties(
				specialOfferID,
				model.ModifiedDate,
				model.ProductID,
				model.Rowguid);
		}

		public virtual POCOSpecialOfferProduct SpecialOfferProductMapEFToPOCO(
			SpecialOfferProduct efSpecialOfferProduct)
		{
			if (efSpecialOfferProduct == null)
			{
				return null;
			}

			return new POCOSpecialOfferProduct(efSpecialOfferProduct.ModifiedDate, efSpecialOfferProduct.ProductID, efSpecialOfferProduct.Rowguid, efSpecialOfferProduct.SpecialOfferID);
		}

		public virtual void StoreMapModelToEF(
			int businessEntityID,
			ApiStoreModel model,
			Store efStore)
		{
			efStore.SetProperties(
				businessEntityID,
				model.Demographics,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
		}

		public virtual POCOStore StoreMapEFToPOCO(
			Store efStore)
		{
			if (efStore == null)
			{
				return null;
			}

			return new POCOStore(efStore.BusinessEntityID, efStore.Demographics, efStore.ModifiedDate, efStore.Name, efStore.Rowguid, efStore.SalesPersonID);
		}
	}
}

/*<Codenesium>
    <Hash>18181d79af448b9e446f3b034bbfb7fa</Hash>
</Codenesium>*/