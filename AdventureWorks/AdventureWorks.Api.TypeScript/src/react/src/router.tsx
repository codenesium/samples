import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedAWBuildVersionCreateComponent } from './components/aWBuildVersion/aWBuildVersionCreateForm';
import { WrappedAWBuildVersionDetailComponent } from './components/aWBuildVersion/aWBuildVersionDetailForm';
import { WrappedAWBuildVersionEditComponent } from './components/aWBuildVersion/aWBuildVersionEditForm';
import { WrappedAWBuildVersionSearchComponent } from './components/aWBuildVersion/aWBuildVersionSearchForm';					
import { WrappedDatabaseLogCreateComponent } from './components/databaseLog/databaseLogCreateForm';
import { WrappedDatabaseLogDetailComponent } from './components/databaseLog/databaseLogDetailForm';
import { WrappedDatabaseLogEditComponent } from './components/databaseLog/databaseLogEditForm';
import { WrappedDatabaseLogSearchComponent } from './components/databaseLog/databaseLogSearchForm';					
import { WrappedErrorLogCreateComponent } from './components/errorLog/errorLogCreateForm';
import { WrappedErrorLogDetailComponent } from './components/errorLog/errorLogDetailForm';
import { WrappedErrorLogEditComponent } from './components/errorLog/errorLogEditForm';
import { WrappedErrorLogSearchComponent } from './components/errorLog/errorLogSearchForm';					
import { WrappedDepartmentCreateComponent } from './components/department/departmentCreateForm';
import { WrappedDepartmentDetailComponent } from './components/department/departmentDetailForm';
import { WrappedDepartmentEditComponent } from './components/department/departmentEditForm';
import { WrappedDepartmentSearchComponent } from './components/department/departmentSearchForm';					
import { WrappedEmployeeCreateComponent } from './components/employee/employeeCreateForm';
import { WrappedEmployeeDetailComponent } from './components/employee/employeeDetailForm';
import { WrappedEmployeeEditComponent } from './components/employee/employeeEditForm';
import { WrappedEmployeeSearchComponent } from './components/employee/employeeSearchForm';					
import { WrappedJobCandidateCreateComponent } from './components/jobCandidate/jobCandidateCreateForm';
import { WrappedJobCandidateDetailComponent } from './components/jobCandidate/jobCandidateDetailForm';
import { WrappedJobCandidateEditComponent } from './components/jobCandidate/jobCandidateEditForm';
import { WrappedJobCandidateSearchComponent } from './components/jobCandidate/jobCandidateSearchForm';					
import { WrappedShiftCreateComponent } from './components/shift/shiftCreateForm';
import { WrappedShiftDetailComponent } from './components/shift/shiftDetailForm';
import { WrappedShiftEditComponent } from './components/shift/shiftEditForm';
import { WrappedShiftSearchComponent } from './components/shift/shiftSearchForm';					
import { WrappedAddressCreateComponent } from './components/address/addressCreateForm';
import { WrappedAddressDetailComponent } from './components/address/addressDetailForm';
import { WrappedAddressEditComponent } from './components/address/addressEditForm';
import { WrappedAddressSearchComponent } from './components/address/addressSearchForm';					
import { WrappedAddressTypeCreateComponent } from './components/addressType/addressTypeCreateForm';
import { WrappedAddressTypeDetailComponent } from './components/addressType/addressTypeDetailForm';
import { WrappedAddressTypeEditComponent } from './components/addressType/addressTypeEditForm';
import { WrappedAddressTypeSearchComponent } from './components/addressType/addressTypeSearchForm';					
import { WrappedBusinessEntityCreateComponent } from './components/businessEntity/businessEntityCreateForm';
import { WrappedBusinessEntityDetailComponent } from './components/businessEntity/businessEntityDetailForm';
import { WrappedBusinessEntityEditComponent } from './components/businessEntity/businessEntityEditForm';
import { WrappedBusinessEntitySearchComponent } from './components/businessEntity/businessEntitySearchForm';					
import { WrappedContactTypeCreateComponent } from './components/contactType/contactTypeCreateForm';
import { WrappedContactTypeDetailComponent } from './components/contactType/contactTypeDetailForm';
import { WrappedContactTypeEditComponent } from './components/contactType/contactTypeEditForm';
import { WrappedContactTypeSearchComponent } from './components/contactType/contactTypeSearchForm';					
import { WrappedCountryRegionCreateComponent } from './components/countryRegion/countryRegionCreateForm';
import { WrappedCountryRegionDetailComponent } from './components/countryRegion/countryRegionDetailForm';
import { WrappedCountryRegionEditComponent } from './components/countryRegion/countryRegionEditForm';
import { WrappedCountryRegionSearchComponent } from './components/countryRegion/countryRegionSearchForm';					
import { WrappedPasswordCreateComponent } from './components/password/passwordCreateForm';
import { WrappedPasswordDetailComponent } from './components/password/passwordDetailForm';
import { WrappedPasswordEditComponent } from './components/password/passwordEditForm';
import { WrappedPasswordSearchComponent } from './components/password/passwordSearchForm';					
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';					
import { WrappedPhoneNumberTypeCreateComponent } from './components/phoneNumberType/phoneNumberTypeCreateForm';
import { WrappedPhoneNumberTypeDetailComponent } from './components/phoneNumberType/phoneNumberTypeDetailForm';
import { WrappedPhoneNumberTypeEditComponent } from './components/phoneNumberType/phoneNumberTypeEditForm';
import { WrappedPhoneNumberTypeSearchComponent } from './components/phoneNumberType/phoneNumberTypeSearchForm';					
import { WrappedStateProvinceCreateComponent } from './components/stateProvince/stateProvinceCreateForm';
import { WrappedStateProvinceDetailComponent } from './components/stateProvince/stateProvinceDetailForm';
import { WrappedStateProvinceEditComponent } from './components/stateProvince/stateProvinceEditForm';
import { WrappedStateProvinceSearchComponent } from './components/stateProvince/stateProvinceSearchForm';					
import { WrappedBillOfMaterialCreateComponent } from './components/billOfMaterial/billOfMaterialCreateForm';
import { WrappedBillOfMaterialDetailComponent } from './components/billOfMaterial/billOfMaterialDetailForm';
import { WrappedBillOfMaterialEditComponent } from './components/billOfMaterial/billOfMaterialEditForm';
import { WrappedBillOfMaterialSearchComponent } from './components/billOfMaterial/billOfMaterialSearchForm';					
import { WrappedCultureCreateComponent } from './components/culture/cultureCreateForm';
import { WrappedCultureDetailComponent } from './components/culture/cultureDetailForm';
import { WrappedCultureEditComponent } from './components/culture/cultureEditForm';
import { WrappedCultureSearchComponent } from './components/culture/cultureSearchForm';					
import { WrappedDocumentCreateComponent } from './components/document/documentCreateForm';
import { WrappedDocumentDetailComponent } from './components/document/documentDetailForm';
import { WrappedDocumentEditComponent } from './components/document/documentEditForm';
import { WrappedDocumentSearchComponent } from './components/document/documentSearchForm';					
import { WrappedIllustrationCreateComponent } from './components/illustration/illustrationCreateForm';
import { WrappedIllustrationDetailComponent } from './components/illustration/illustrationDetailForm';
import { WrappedIllustrationEditComponent } from './components/illustration/illustrationEditForm';
import { WrappedIllustrationSearchComponent } from './components/illustration/illustrationSearchForm';					
import { WrappedLocationCreateComponent } from './components/location/locationCreateForm';
import { WrappedLocationDetailComponent } from './components/location/locationDetailForm';
import { WrappedLocationEditComponent } from './components/location/locationEditForm';
import { WrappedLocationSearchComponent } from './components/location/locationSearchForm';					
import { WrappedProductCreateComponent } from './components/product/productCreateForm';
import { WrappedProductDetailComponent } from './components/product/productDetailForm';
import { WrappedProductEditComponent } from './components/product/productEditForm';
import { WrappedProductSearchComponent } from './components/product/productSearchForm';					
import { WrappedProductCategoryCreateComponent } from './components/productCategory/productCategoryCreateForm';
import { WrappedProductCategoryDetailComponent } from './components/productCategory/productCategoryDetailForm';
import { WrappedProductCategoryEditComponent } from './components/productCategory/productCategoryEditForm';
import { WrappedProductCategorySearchComponent } from './components/productCategory/productCategorySearchForm';					
import { WrappedProductDescriptionCreateComponent } from './components/productDescription/productDescriptionCreateForm';
import { WrappedProductDescriptionDetailComponent } from './components/productDescription/productDescriptionDetailForm';
import { WrappedProductDescriptionEditComponent } from './components/productDescription/productDescriptionEditForm';
import { WrappedProductDescriptionSearchComponent } from './components/productDescription/productDescriptionSearchForm';					
import { WrappedProductModelCreateComponent } from './components/productModel/productModelCreateForm';
import { WrappedProductModelDetailComponent } from './components/productModel/productModelDetailForm';
import { WrappedProductModelEditComponent } from './components/productModel/productModelEditForm';
import { WrappedProductModelSearchComponent } from './components/productModel/productModelSearchForm';					
import { WrappedProductPhotoCreateComponent } from './components/productPhoto/productPhotoCreateForm';
import { WrappedProductPhotoDetailComponent } from './components/productPhoto/productPhotoDetailForm';
import { WrappedProductPhotoEditComponent } from './components/productPhoto/productPhotoEditForm';
import { WrappedProductPhotoSearchComponent } from './components/productPhoto/productPhotoSearchForm';					
import { WrappedProductReviewCreateComponent } from './components/productReview/productReviewCreateForm';
import { WrappedProductReviewDetailComponent } from './components/productReview/productReviewDetailForm';
import { WrappedProductReviewEditComponent } from './components/productReview/productReviewEditForm';
import { WrappedProductReviewSearchComponent } from './components/productReview/productReviewSearchForm';					
import { WrappedProductSubcategoryCreateComponent } from './components/productSubcategory/productSubcategoryCreateForm';
import { WrappedProductSubcategoryDetailComponent } from './components/productSubcategory/productSubcategoryDetailForm';
import { WrappedProductSubcategoryEditComponent } from './components/productSubcategory/productSubcategoryEditForm';
import { WrappedProductSubcategorySearchComponent } from './components/productSubcategory/productSubcategorySearchForm';					
import { WrappedScrapReasonCreateComponent } from './components/scrapReason/scrapReasonCreateForm';
import { WrappedScrapReasonDetailComponent } from './components/scrapReason/scrapReasonDetailForm';
import { WrappedScrapReasonEditComponent } from './components/scrapReason/scrapReasonEditForm';
import { WrappedScrapReasonSearchComponent } from './components/scrapReason/scrapReasonSearchForm';					
import { WrappedTransactionHistoryCreateComponent } from './components/transactionHistory/transactionHistoryCreateForm';
import { WrappedTransactionHistoryDetailComponent } from './components/transactionHistory/transactionHistoryDetailForm';
import { WrappedTransactionHistoryEditComponent } from './components/transactionHistory/transactionHistoryEditForm';
import { WrappedTransactionHistorySearchComponent } from './components/transactionHistory/transactionHistorySearchForm';					
import { WrappedTransactionHistoryArchiveCreateComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveCreateForm';
import { WrappedTransactionHistoryArchiveDetailComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveDetailForm';
import { WrappedTransactionHistoryArchiveEditComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveEditForm';
import { WrappedTransactionHistoryArchiveSearchComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveSearchForm';					
import { WrappedUnitMeasureCreateComponent } from './components/unitMeasure/unitMeasureCreateForm';
import { WrappedUnitMeasureDetailComponent } from './components/unitMeasure/unitMeasureDetailForm';
import { WrappedUnitMeasureEditComponent } from './components/unitMeasure/unitMeasureEditForm';
import { WrappedUnitMeasureSearchComponent } from './components/unitMeasure/unitMeasureSearchForm';					
import { WrappedWorkOrderCreateComponent } from './components/workOrder/workOrderCreateForm';
import { WrappedWorkOrderDetailComponent } from './components/workOrder/workOrderDetailForm';
import { WrappedWorkOrderEditComponent } from './components/workOrder/workOrderEditForm';
import { WrappedWorkOrderSearchComponent } from './components/workOrder/workOrderSearchForm';					
import { WrappedPurchaseOrderHeaderCreateComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderCreateForm';
import { WrappedPurchaseOrderHeaderDetailComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderDetailForm';
import { WrappedPurchaseOrderHeaderEditComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderEditForm';
import { WrappedPurchaseOrderHeaderSearchComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderSearchForm';					
import { WrappedShipMethodCreateComponent } from './components/shipMethod/shipMethodCreateForm';
import { WrappedShipMethodDetailComponent } from './components/shipMethod/shipMethodDetailForm';
import { WrappedShipMethodEditComponent } from './components/shipMethod/shipMethodEditForm';
import { WrappedShipMethodSearchComponent } from './components/shipMethod/shipMethodSearchForm';					
import { WrappedVendorCreateComponent } from './components/vendor/vendorCreateForm';
import { WrappedVendorDetailComponent } from './components/vendor/vendorDetailForm';
import { WrappedVendorEditComponent } from './components/vendor/vendorEditForm';
import { WrappedVendorSearchComponent } from './components/vendor/vendorSearchForm';					
import { WrappedCreditCardCreateComponent } from './components/creditCard/creditCardCreateForm';
import { WrappedCreditCardDetailComponent } from './components/creditCard/creditCardDetailForm';
import { WrappedCreditCardEditComponent } from './components/creditCard/creditCardEditForm';
import { WrappedCreditCardSearchComponent } from './components/creditCard/creditCardSearchForm';					
import { WrappedCurrencyCreateComponent } from './components/currency/currencyCreateForm';
import { WrappedCurrencyDetailComponent } from './components/currency/currencyDetailForm';
import { WrappedCurrencyEditComponent } from './components/currency/currencyEditForm';
import { WrappedCurrencySearchComponent } from './components/currency/currencySearchForm';					
import { WrappedCurrencyRateCreateComponent } from './components/currencyRate/currencyRateCreateForm';
import { WrappedCurrencyRateDetailComponent } from './components/currencyRate/currencyRateDetailForm';
import { WrappedCurrencyRateEditComponent } from './components/currencyRate/currencyRateEditForm';
import { WrappedCurrencyRateSearchComponent } from './components/currencyRate/currencyRateSearchForm';					
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';					
import { WrappedSalesOrderHeaderCreateComponent } from './components/salesOrderHeader/salesOrderHeaderCreateForm';
import { WrappedSalesOrderHeaderDetailComponent } from './components/salesOrderHeader/salesOrderHeaderDetailForm';
import { WrappedSalesOrderHeaderEditComponent } from './components/salesOrderHeader/salesOrderHeaderEditForm';
import { WrappedSalesOrderHeaderSearchComponent } from './components/salesOrderHeader/salesOrderHeaderSearchForm';					
import { WrappedSalesPersonCreateComponent } from './components/salesPerson/salesPersonCreateForm';
import { WrappedSalesPersonDetailComponent } from './components/salesPerson/salesPersonDetailForm';
import { WrappedSalesPersonEditComponent } from './components/salesPerson/salesPersonEditForm';
import { WrappedSalesPersonSearchComponent } from './components/salesPerson/salesPersonSearchForm';					
import { WrappedSalesReasonCreateComponent } from './components/salesReason/salesReasonCreateForm';
import { WrappedSalesReasonDetailComponent } from './components/salesReason/salesReasonDetailForm';
import { WrappedSalesReasonEditComponent } from './components/salesReason/salesReasonEditForm';
import { WrappedSalesReasonSearchComponent } from './components/salesReason/salesReasonSearchForm';					
import { WrappedSalesTaxRateCreateComponent } from './components/salesTaxRate/salesTaxRateCreateForm';
import { WrappedSalesTaxRateDetailComponent } from './components/salesTaxRate/salesTaxRateDetailForm';
import { WrappedSalesTaxRateEditComponent } from './components/salesTaxRate/salesTaxRateEditForm';
import { WrappedSalesTaxRateSearchComponent } from './components/salesTaxRate/salesTaxRateSearchForm';					
import { WrappedSalesTerritoryCreateComponent } from './components/salesTerritory/salesTerritoryCreateForm';
import { WrappedSalesTerritoryDetailComponent } from './components/salesTerritory/salesTerritoryDetailForm';
import { WrappedSalesTerritoryEditComponent } from './components/salesTerritory/salesTerritoryEditForm';
import { WrappedSalesTerritorySearchComponent } from './components/salesTerritory/salesTerritorySearchForm';					
import { WrappedShoppingCartItemCreateComponent } from './components/shoppingCartItem/shoppingCartItemCreateForm';
import { WrappedShoppingCartItemDetailComponent } from './components/shoppingCartItem/shoppingCartItemDetailForm';
import { WrappedShoppingCartItemEditComponent } from './components/shoppingCartItem/shoppingCartItemEditForm';
import { WrappedShoppingCartItemSearchComponent } from './components/shoppingCartItem/shoppingCartItemSearchForm';					
import { WrappedSpecialOfferCreateComponent } from './components/specialOffer/specialOfferCreateForm';
import { WrappedSpecialOfferDetailComponent } from './components/specialOffer/specialOfferDetailForm';
import { WrappedSpecialOfferEditComponent } from './components/specialOffer/specialOfferEditForm';
import { WrappedSpecialOfferSearchComponent } from './components/specialOffer/specialOfferSearchForm';					
import { WrappedStoreCreateComponent } from './components/store/storeCreateForm';
import { WrappedStoreDetailComponent } from './components/store/storeDetailForm';
import { WrappedStoreEditComponent } from './components/store/storeEditForm';
import { WrappedStoreSearchComponent } from './components/store/storeSearchForm';					

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search)

  return (
    <BrowserRouter>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
		  <Route path={ClientRoutes.AWBuildVersions + "/create"} component={wrapperHeader(WrappedAWBuildVersionCreateComponent, "AWBuildVersion Create")} />
                      <Route path={ClientRoutes.AWBuildVersions + "/edit/:id"} component={wrapperHeader(WrappedAWBuildVersionEditComponent, "AWBuildVersion Edit")} />
                      <Route path={ClientRoutes.AWBuildVersions + "/:id"} component={wrapperHeader(WrappedAWBuildVersionDetailComponent , "AWBuildVersion Detail")} />
                      <Route path={ClientRoutes.AWBuildVersions} component={wrapperHeader(WrappedAWBuildVersionSearchComponent, "AWBuildVersion Search")} />
					<Route path={ClientRoutes.DatabaseLogs + "/create"} component={wrapperHeader(WrappedDatabaseLogCreateComponent, "DatabaseLog Create")} />
                      <Route path={ClientRoutes.DatabaseLogs + "/edit/:id"} component={wrapperHeader(WrappedDatabaseLogEditComponent, "DatabaseLog Edit")} />
                      <Route path={ClientRoutes.DatabaseLogs + "/:id"} component={wrapperHeader(WrappedDatabaseLogDetailComponent , "DatabaseLog Detail")} />
                      <Route path={ClientRoutes.DatabaseLogs} component={wrapperHeader(WrappedDatabaseLogSearchComponent, "DatabaseLog Search")} />
					<Route path={ClientRoutes.ErrorLogs + "/create"} component={wrapperHeader(WrappedErrorLogCreateComponent, "ErrorLog Create")} />
                      <Route path={ClientRoutes.ErrorLogs + "/edit/:id"} component={wrapperHeader(WrappedErrorLogEditComponent, "ErrorLog Edit")} />
                      <Route path={ClientRoutes.ErrorLogs + "/:id"} component={wrapperHeader(WrappedErrorLogDetailComponent , "ErrorLog Detail")} />
                      <Route path={ClientRoutes.ErrorLogs} component={wrapperHeader(WrappedErrorLogSearchComponent, "ErrorLog Search")} />
					<Route path={ClientRoutes.Departments + "/create"} component={wrapperHeader(WrappedDepartmentCreateComponent, "Department Create")} />
                      <Route path={ClientRoutes.Departments + "/edit/:id"} component={wrapperHeader(WrappedDepartmentEditComponent, "Department Edit")} />
                      <Route path={ClientRoutes.Departments + "/:id"} component={wrapperHeader(WrappedDepartmentDetailComponent , "Department Detail")} />
                      <Route path={ClientRoutes.Departments} component={wrapperHeader(WrappedDepartmentSearchComponent, "Department Search")} />
					<Route path={ClientRoutes.Employees + "/create"} component={wrapperHeader(WrappedEmployeeCreateComponent, "Employee Create")} />
                      <Route path={ClientRoutes.Employees + "/edit/:id"} component={wrapperHeader(WrappedEmployeeEditComponent, "Employee Edit")} />
                      <Route path={ClientRoutes.Employees + "/:id"} component={wrapperHeader(WrappedEmployeeDetailComponent , "Employee Detail")} />
                      <Route path={ClientRoutes.Employees} component={wrapperHeader(WrappedEmployeeSearchComponent, "Employee Search")} />
					<Route path={ClientRoutes.JobCandidates + "/create"} component={wrapperHeader(WrappedJobCandidateCreateComponent, "JobCandidate Create")} />
                      <Route path={ClientRoutes.JobCandidates + "/edit/:id"} component={wrapperHeader(WrappedJobCandidateEditComponent, "JobCandidate Edit")} />
                      <Route path={ClientRoutes.JobCandidates + "/:id"} component={wrapperHeader(WrappedJobCandidateDetailComponent , "JobCandidate Detail")} />
                      <Route path={ClientRoutes.JobCandidates} component={wrapperHeader(WrappedJobCandidateSearchComponent, "JobCandidate Search")} />
					<Route path={ClientRoutes.Shifts + "/create"} component={wrapperHeader(WrappedShiftCreateComponent, "Shift Create")} />
                      <Route path={ClientRoutes.Shifts + "/edit/:id"} component={wrapperHeader(WrappedShiftEditComponent, "Shift Edit")} />
                      <Route path={ClientRoutes.Shifts + "/:id"} component={wrapperHeader(WrappedShiftDetailComponent , "Shift Detail")} />
                      <Route path={ClientRoutes.Shifts} component={wrapperHeader(WrappedShiftSearchComponent, "Shift Search")} />
					<Route path={ClientRoutes.Addresses + "/create"} component={wrapperHeader(WrappedAddressCreateComponent, "Address Create")} />
                      <Route path={ClientRoutes.Addresses + "/edit/:id"} component={wrapperHeader(WrappedAddressEditComponent, "Address Edit")} />
                      <Route path={ClientRoutes.Addresses + "/:id"} component={wrapperHeader(WrappedAddressDetailComponent , "Address Detail")} />
                      <Route path={ClientRoutes.Addresses} component={wrapperHeader(WrappedAddressSearchComponent, "Address Search")} />
					<Route path={ClientRoutes.AddressTypes + "/create"} component={wrapperHeader(WrappedAddressTypeCreateComponent, "AddressType Create")} />
                      <Route path={ClientRoutes.AddressTypes + "/edit/:id"} component={wrapperHeader(WrappedAddressTypeEditComponent, "AddressType Edit")} />
                      <Route path={ClientRoutes.AddressTypes + "/:id"} component={wrapperHeader(WrappedAddressTypeDetailComponent , "AddressType Detail")} />
                      <Route path={ClientRoutes.AddressTypes} component={wrapperHeader(WrappedAddressTypeSearchComponent, "AddressType Search")} />
					<Route path={ClientRoutes.BusinessEntities + "/create"} component={wrapperHeader(WrappedBusinessEntityCreateComponent, "BusinessEntity Create")} />
                      <Route path={ClientRoutes.BusinessEntities + "/edit/:id"} component={wrapperHeader(WrappedBusinessEntityEditComponent, "BusinessEntity Edit")} />
                      <Route path={ClientRoutes.BusinessEntities + "/:id"} component={wrapperHeader(WrappedBusinessEntityDetailComponent , "BusinessEntity Detail")} />
                      <Route path={ClientRoutes.BusinessEntities} component={wrapperHeader(WrappedBusinessEntitySearchComponent, "BusinessEntity Search")} />
					<Route path={ClientRoutes.ContactTypes + "/create"} component={wrapperHeader(WrappedContactTypeCreateComponent, "ContactType Create")} />
                      <Route path={ClientRoutes.ContactTypes + "/edit/:id"} component={wrapperHeader(WrappedContactTypeEditComponent, "ContactType Edit")} />
                      <Route path={ClientRoutes.ContactTypes + "/:id"} component={wrapperHeader(WrappedContactTypeDetailComponent , "ContactType Detail")} />
                      <Route path={ClientRoutes.ContactTypes} component={wrapperHeader(WrappedContactTypeSearchComponent, "ContactType Search")} />
					<Route path={ClientRoutes.CountryRegions + "/create"} component={wrapperHeader(WrappedCountryRegionCreateComponent, "CountryRegion Create")} />
                      <Route path={ClientRoutes.CountryRegions + "/edit/:id"} component={wrapperHeader(WrappedCountryRegionEditComponent, "CountryRegion Edit")} />
                      <Route path={ClientRoutes.CountryRegions + "/:id"} component={wrapperHeader(WrappedCountryRegionDetailComponent , "CountryRegion Detail")} />
                      <Route path={ClientRoutes.CountryRegions} component={wrapperHeader(WrappedCountryRegionSearchComponent, "CountryRegion Search")} />
					<Route path={ClientRoutes.Passwords + "/create"} component={wrapperHeader(WrappedPasswordCreateComponent, "Password Create")} />
                      <Route path={ClientRoutes.Passwords + "/edit/:id"} component={wrapperHeader(WrappedPasswordEditComponent, "Password Edit")} />
                      <Route path={ClientRoutes.Passwords + "/:id"} component={wrapperHeader(WrappedPasswordDetailComponent , "Password Detail")} />
                      <Route path={ClientRoutes.Passwords} component={wrapperHeader(WrappedPasswordSearchComponent, "Password Search")} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent, "Person Create")} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent, "Person Edit")} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent , "Person Detail")} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent, "Person Search")} />
					<Route path={ClientRoutes.PhoneNumberTypes + "/create"} component={wrapperHeader(WrappedPhoneNumberTypeCreateComponent, "PhoneNumberType Create")} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/edit/:id"} component={wrapperHeader(WrappedPhoneNumberTypeEditComponent, "PhoneNumberType Edit")} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/:id"} component={wrapperHeader(WrappedPhoneNumberTypeDetailComponent , "PhoneNumberType Detail")} />
                      <Route path={ClientRoutes.PhoneNumberTypes} component={wrapperHeader(WrappedPhoneNumberTypeSearchComponent, "PhoneNumberType Search")} />
					<Route path={ClientRoutes.StateProvinces + "/create"} component={wrapperHeader(WrappedStateProvinceCreateComponent, "StateProvince Create")} />
                      <Route path={ClientRoutes.StateProvinces + "/edit/:id"} component={wrapperHeader(WrappedStateProvinceEditComponent, "StateProvince Edit")} />
                      <Route path={ClientRoutes.StateProvinces + "/:id"} component={wrapperHeader(WrappedStateProvinceDetailComponent , "StateProvince Detail")} />
                      <Route path={ClientRoutes.StateProvinces} component={wrapperHeader(WrappedStateProvinceSearchComponent, "StateProvince Search")} />
					<Route path={ClientRoutes.BillOfMaterials + "/create"} component={wrapperHeader(WrappedBillOfMaterialCreateComponent, "BillOfMaterial Create")} />
                      <Route path={ClientRoutes.BillOfMaterials + "/edit/:id"} component={wrapperHeader(WrappedBillOfMaterialEditComponent, "BillOfMaterial Edit")} />
                      <Route path={ClientRoutes.BillOfMaterials + "/:id"} component={wrapperHeader(WrappedBillOfMaterialDetailComponent , "BillOfMaterial Detail")} />
                      <Route path={ClientRoutes.BillOfMaterials} component={wrapperHeader(WrappedBillOfMaterialSearchComponent, "BillOfMaterial Search")} />
					<Route path={ClientRoutes.Cultures + "/create"} component={wrapperHeader(WrappedCultureCreateComponent, "Culture Create")} />
                      <Route path={ClientRoutes.Cultures + "/edit/:id"} component={wrapperHeader(WrappedCultureEditComponent, "Culture Edit")} />
                      <Route path={ClientRoutes.Cultures + "/:id"} component={wrapperHeader(WrappedCultureDetailComponent , "Culture Detail")} />
                      <Route path={ClientRoutes.Cultures} component={wrapperHeader(WrappedCultureSearchComponent, "Culture Search")} />
					<Route path={ClientRoutes.Documents + "/create"} component={wrapperHeader(WrappedDocumentCreateComponent, "Document Create")} />
                      <Route path={ClientRoutes.Documents + "/edit/:id"} component={wrapperHeader(WrappedDocumentEditComponent, "Document Edit")} />
                      <Route path={ClientRoutes.Documents + "/:id"} component={wrapperHeader(WrappedDocumentDetailComponent , "Document Detail")} />
                      <Route path={ClientRoutes.Documents} component={wrapperHeader(WrappedDocumentSearchComponent, "Document Search")} />
					<Route path={ClientRoutes.Illustrations + "/create"} component={wrapperHeader(WrappedIllustrationCreateComponent, "Illustration Create")} />
                      <Route path={ClientRoutes.Illustrations + "/edit/:id"} component={wrapperHeader(WrappedIllustrationEditComponent, "Illustration Edit")} />
                      <Route path={ClientRoutes.Illustrations + "/:id"} component={wrapperHeader(WrappedIllustrationDetailComponent , "Illustration Detail")} />
                      <Route path={ClientRoutes.Illustrations} component={wrapperHeader(WrappedIllustrationSearchComponent, "Illustration Search")} />
					<Route path={ClientRoutes.Locations + "/create"} component={wrapperHeader(WrappedLocationCreateComponent, "Location Create")} />
                      <Route path={ClientRoutes.Locations + "/edit/:id"} component={wrapperHeader(WrappedLocationEditComponent, "Location Edit")} />
                      <Route path={ClientRoutes.Locations + "/:id"} component={wrapperHeader(WrappedLocationDetailComponent , "Location Detail")} />
                      <Route path={ClientRoutes.Locations} component={wrapperHeader(WrappedLocationSearchComponent, "Location Search")} />
					<Route path={ClientRoutes.Products + "/create"} component={wrapperHeader(WrappedProductCreateComponent, "Product Create")} />
                      <Route path={ClientRoutes.Products + "/edit/:id"} component={wrapperHeader(WrappedProductEditComponent, "Product Edit")} />
                      <Route path={ClientRoutes.Products + "/:id"} component={wrapperHeader(WrappedProductDetailComponent , "Product Detail")} />
                      <Route path={ClientRoutes.Products} component={wrapperHeader(WrappedProductSearchComponent, "Product Search")} />
					<Route path={ClientRoutes.ProductCategories + "/create"} component={wrapperHeader(WrappedProductCategoryCreateComponent, "ProductCategory Create")} />
                      <Route path={ClientRoutes.ProductCategories + "/edit/:id"} component={wrapperHeader(WrappedProductCategoryEditComponent, "ProductCategory Edit")} />
                      <Route path={ClientRoutes.ProductCategories + "/:id"} component={wrapperHeader(WrappedProductCategoryDetailComponent , "ProductCategory Detail")} />
                      <Route path={ClientRoutes.ProductCategories} component={wrapperHeader(WrappedProductCategorySearchComponent, "ProductCategory Search")} />
					<Route path={ClientRoutes.ProductDescriptions + "/create"} component={wrapperHeader(WrappedProductDescriptionCreateComponent, "ProductDescription Create")} />
                      <Route path={ClientRoutes.ProductDescriptions + "/edit/:id"} component={wrapperHeader(WrappedProductDescriptionEditComponent, "ProductDescription Edit")} />
                      <Route path={ClientRoutes.ProductDescriptions + "/:id"} component={wrapperHeader(WrappedProductDescriptionDetailComponent , "ProductDescription Detail")} />
                      <Route path={ClientRoutes.ProductDescriptions} component={wrapperHeader(WrappedProductDescriptionSearchComponent, "ProductDescription Search")} />
					<Route path={ClientRoutes.ProductModels + "/create"} component={wrapperHeader(WrappedProductModelCreateComponent, "ProductModel Create")} />
                      <Route path={ClientRoutes.ProductModels + "/edit/:id"} component={wrapperHeader(WrappedProductModelEditComponent, "ProductModel Edit")} />
                      <Route path={ClientRoutes.ProductModels + "/:id"} component={wrapperHeader(WrappedProductModelDetailComponent , "ProductModel Detail")} />
                      <Route path={ClientRoutes.ProductModels} component={wrapperHeader(WrappedProductModelSearchComponent, "ProductModel Search")} />
					<Route path={ClientRoutes.ProductPhotoes + "/create"} component={wrapperHeader(WrappedProductPhotoCreateComponent, "ProductPhoto Create")} />
                      <Route path={ClientRoutes.ProductPhotoes + "/edit/:id"} component={wrapperHeader(WrappedProductPhotoEditComponent, "ProductPhoto Edit")} />
                      <Route path={ClientRoutes.ProductPhotoes + "/:id"} component={wrapperHeader(WrappedProductPhotoDetailComponent , "ProductPhoto Detail")} />
                      <Route path={ClientRoutes.ProductPhotoes} component={wrapperHeader(WrappedProductPhotoSearchComponent, "ProductPhoto Search")} />
					<Route path={ClientRoutes.ProductReviews + "/create"} component={wrapperHeader(WrappedProductReviewCreateComponent, "ProductReview Create")} />
                      <Route path={ClientRoutes.ProductReviews + "/edit/:id"} component={wrapperHeader(WrappedProductReviewEditComponent, "ProductReview Edit")} />
                      <Route path={ClientRoutes.ProductReviews + "/:id"} component={wrapperHeader(WrappedProductReviewDetailComponent , "ProductReview Detail")} />
                      <Route path={ClientRoutes.ProductReviews} component={wrapperHeader(WrappedProductReviewSearchComponent, "ProductReview Search")} />
					<Route path={ClientRoutes.ProductSubcategories + "/create"} component={wrapperHeader(WrappedProductSubcategoryCreateComponent, "ProductSubcategory Create")} />
                      <Route path={ClientRoutes.ProductSubcategories + "/edit/:id"} component={wrapperHeader(WrappedProductSubcategoryEditComponent, "ProductSubcategory Edit")} />
                      <Route path={ClientRoutes.ProductSubcategories + "/:id"} component={wrapperHeader(WrappedProductSubcategoryDetailComponent , "ProductSubcategory Detail")} />
                      <Route path={ClientRoutes.ProductSubcategories} component={wrapperHeader(WrappedProductSubcategorySearchComponent, "ProductSubcategory Search")} />
					<Route path={ClientRoutes.ScrapReasons + "/create"} component={wrapperHeader(WrappedScrapReasonCreateComponent, "ScrapReason Create")} />
                      <Route path={ClientRoutes.ScrapReasons + "/edit/:id"} component={wrapperHeader(WrappedScrapReasonEditComponent, "ScrapReason Edit")} />
                      <Route path={ClientRoutes.ScrapReasons + "/:id"} component={wrapperHeader(WrappedScrapReasonDetailComponent , "ScrapReason Detail")} />
                      <Route path={ClientRoutes.ScrapReasons} component={wrapperHeader(WrappedScrapReasonSearchComponent, "ScrapReason Search")} />
					<Route path={ClientRoutes.TransactionHistories + "/create"} component={wrapperHeader(WrappedTransactionHistoryCreateComponent, "TransactionHistory Create")} />
                      <Route path={ClientRoutes.TransactionHistories + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryEditComponent, "TransactionHistory Edit")} />
                      <Route path={ClientRoutes.TransactionHistories + "/:id"} component={wrapperHeader(WrappedTransactionHistoryDetailComponent , "TransactionHistory Detail")} />
                      <Route path={ClientRoutes.TransactionHistories} component={wrapperHeader(WrappedTransactionHistorySearchComponent, "TransactionHistory Search")} />
					<Route path={ClientRoutes.TransactionHistoryArchives + "/create"} component={wrapperHeader(WrappedTransactionHistoryArchiveCreateComponent, "TransactionHistoryArchive Create")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveEditComponent, "TransactionHistoryArchive Edit")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveDetailComponent , "TransactionHistoryArchive Detail")} />
                      <Route path={ClientRoutes.TransactionHistoryArchives} component={wrapperHeader(WrappedTransactionHistoryArchiveSearchComponent, "TransactionHistoryArchive Search")} />
					<Route path={ClientRoutes.UnitMeasures + "/create"} component={wrapperHeader(WrappedUnitMeasureCreateComponent, "UnitMeasure Create")} />
                      <Route path={ClientRoutes.UnitMeasures + "/edit/:id"} component={wrapperHeader(WrappedUnitMeasureEditComponent, "UnitMeasure Edit")} />
                      <Route path={ClientRoutes.UnitMeasures + "/:id"} component={wrapperHeader(WrappedUnitMeasureDetailComponent , "UnitMeasure Detail")} />
                      <Route path={ClientRoutes.UnitMeasures} component={wrapperHeader(WrappedUnitMeasureSearchComponent, "UnitMeasure Search")} />
					<Route path={ClientRoutes.WorkOrders + "/create"} component={wrapperHeader(WrappedWorkOrderCreateComponent, "WorkOrder Create")} />
                      <Route path={ClientRoutes.WorkOrders + "/edit/:id"} component={wrapperHeader(WrappedWorkOrderEditComponent, "WorkOrder Edit")} />
                      <Route path={ClientRoutes.WorkOrders + "/:id"} component={wrapperHeader(WrappedWorkOrderDetailComponent , "WorkOrder Detail")} />
                      <Route path={ClientRoutes.WorkOrders} component={wrapperHeader(WrappedWorkOrderSearchComponent, "WorkOrder Search")} />
					<Route path={ClientRoutes.PurchaseOrderHeaders + "/create"} component={wrapperHeader(WrappedPurchaseOrderHeaderCreateComponent, "PurchaseOrderHeader Create")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderEditComponent, "PurchaseOrderHeader Edit")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderDetailComponent , "PurchaseOrderHeader Detail")} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders} component={wrapperHeader(WrappedPurchaseOrderHeaderSearchComponent, "PurchaseOrderHeader Search")} />
					<Route path={ClientRoutes.ShipMethods + "/create"} component={wrapperHeader(WrappedShipMethodCreateComponent, "ShipMethod Create")} />
                      <Route path={ClientRoutes.ShipMethods + "/edit/:id"} component={wrapperHeader(WrappedShipMethodEditComponent, "ShipMethod Edit")} />
                      <Route path={ClientRoutes.ShipMethods + "/:id"} component={wrapperHeader(WrappedShipMethodDetailComponent , "ShipMethod Detail")} />
                      <Route path={ClientRoutes.ShipMethods} component={wrapperHeader(WrappedShipMethodSearchComponent, "ShipMethod Search")} />
					<Route path={ClientRoutes.Vendors + "/create"} component={wrapperHeader(WrappedVendorCreateComponent, "Vendor Create")} />
                      <Route path={ClientRoutes.Vendors + "/edit/:id"} component={wrapperHeader(WrappedVendorEditComponent, "Vendor Edit")} />
                      <Route path={ClientRoutes.Vendors + "/:id"} component={wrapperHeader(WrappedVendorDetailComponent , "Vendor Detail")} />
                      <Route path={ClientRoutes.Vendors} component={wrapperHeader(WrappedVendorSearchComponent, "Vendor Search")} />
					<Route path={ClientRoutes.CreditCards + "/create"} component={wrapperHeader(WrappedCreditCardCreateComponent, "CreditCard Create")} />
                      <Route path={ClientRoutes.CreditCards + "/edit/:id"} component={wrapperHeader(WrappedCreditCardEditComponent, "CreditCard Edit")} />
                      <Route path={ClientRoutes.CreditCards + "/:id"} component={wrapperHeader(WrappedCreditCardDetailComponent , "CreditCard Detail")} />
                      <Route path={ClientRoutes.CreditCards} component={wrapperHeader(WrappedCreditCardSearchComponent, "CreditCard Search")} />
					<Route path={ClientRoutes.Currencies + "/create"} component={wrapperHeader(WrappedCurrencyCreateComponent, "Currency Create")} />
                      <Route path={ClientRoutes.Currencies + "/edit/:id"} component={wrapperHeader(WrappedCurrencyEditComponent, "Currency Edit")} />
                      <Route path={ClientRoutes.Currencies + "/:id"} component={wrapperHeader(WrappedCurrencyDetailComponent , "Currency Detail")} />
                      <Route path={ClientRoutes.Currencies} component={wrapperHeader(WrappedCurrencySearchComponent, "Currency Search")} />
					<Route path={ClientRoutes.CurrencyRates + "/create"} component={wrapperHeader(WrappedCurrencyRateCreateComponent, "CurrencyRate Create")} />
                      <Route path={ClientRoutes.CurrencyRates + "/edit/:id"} component={wrapperHeader(WrappedCurrencyRateEditComponent, "CurrencyRate Edit")} />
                      <Route path={ClientRoutes.CurrencyRates + "/:id"} component={wrapperHeader(WrappedCurrencyRateDetailComponent , "CurrencyRate Detail")} />
                      <Route path={ClientRoutes.CurrencyRates} component={wrapperHeader(WrappedCurrencyRateSearchComponent, "CurrencyRate Search")} />
					<Route path={ClientRoutes.Customers + "/create"} component={wrapperHeader(WrappedCustomerCreateComponent, "Customer Create")} />
                      <Route path={ClientRoutes.Customers + "/edit/:id"} component={wrapperHeader(WrappedCustomerEditComponent, "Customer Edit")} />
                      <Route path={ClientRoutes.Customers + "/:id"} component={wrapperHeader(WrappedCustomerDetailComponent , "Customer Detail")} />
                      <Route path={ClientRoutes.Customers} component={wrapperHeader(WrappedCustomerSearchComponent, "Customer Search")} />
					<Route path={ClientRoutes.SalesOrderHeaders + "/create"} component={wrapperHeader(WrappedSalesOrderHeaderCreateComponent, "SalesOrderHeader Create")} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedSalesOrderHeaderEditComponent, "SalesOrderHeader Edit")} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/:id"} component={wrapperHeader(WrappedSalesOrderHeaderDetailComponent , "SalesOrderHeader Detail")} />
                      <Route path={ClientRoutes.SalesOrderHeaders} component={wrapperHeader(WrappedSalesOrderHeaderSearchComponent, "SalesOrderHeader Search")} />
					<Route path={ClientRoutes.SalesPersons + "/create"} component={wrapperHeader(WrappedSalesPersonCreateComponent, "SalesPerson Create")} />
                      <Route path={ClientRoutes.SalesPersons + "/edit/:id"} component={wrapperHeader(WrappedSalesPersonEditComponent, "SalesPerson Edit")} />
                      <Route path={ClientRoutes.SalesPersons + "/:id"} component={wrapperHeader(WrappedSalesPersonDetailComponent , "SalesPerson Detail")} />
                      <Route path={ClientRoutes.SalesPersons} component={wrapperHeader(WrappedSalesPersonSearchComponent, "SalesPerson Search")} />
					<Route path={ClientRoutes.SalesReasons + "/create"} component={wrapperHeader(WrappedSalesReasonCreateComponent, "SalesReason Create")} />
                      <Route path={ClientRoutes.SalesReasons + "/edit/:id"} component={wrapperHeader(WrappedSalesReasonEditComponent, "SalesReason Edit")} />
                      <Route path={ClientRoutes.SalesReasons + "/:id"} component={wrapperHeader(WrappedSalesReasonDetailComponent , "SalesReason Detail")} />
                      <Route path={ClientRoutes.SalesReasons} component={wrapperHeader(WrappedSalesReasonSearchComponent, "SalesReason Search")} />
					<Route path={ClientRoutes.SalesTaxRates + "/create"} component={wrapperHeader(WrappedSalesTaxRateCreateComponent, "SalesTaxRate Create")} />
                      <Route path={ClientRoutes.SalesTaxRates + "/edit/:id"} component={wrapperHeader(WrappedSalesTaxRateEditComponent, "SalesTaxRate Edit")} />
                      <Route path={ClientRoutes.SalesTaxRates + "/:id"} component={wrapperHeader(WrappedSalesTaxRateDetailComponent , "SalesTaxRate Detail")} />
                      <Route path={ClientRoutes.SalesTaxRates} component={wrapperHeader(WrappedSalesTaxRateSearchComponent, "SalesTaxRate Search")} />
					<Route path={ClientRoutes.SalesTerritories + "/create"} component={wrapperHeader(WrappedSalesTerritoryCreateComponent, "SalesTerritory Create")} />
                      <Route path={ClientRoutes.SalesTerritories + "/edit/:id"} component={wrapperHeader(WrappedSalesTerritoryEditComponent, "SalesTerritory Edit")} />
                      <Route path={ClientRoutes.SalesTerritories + "/:id"} component={wrapperHeader(WrappedSalesTerritoryDetailComponent , "SalesTerritory Detail")} />
                      <Route path={ClientRoutes.SalesTerritories} component={wrapperHeader(WrappedSalesTerritorySearchComponent, "SalesTerritory Search")} />
					<Route path={ClientRoutes.ShoppingCartItems + "/create"} component={wrapperHeader(WrappedShoppingCartItemCreateComponent, "ShoppingCartItem Create")} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/edit/:id"} component={wrapperHeader(WrappedShoppingCartItemEditComponent, "ShoppingCartItem Edit")} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/:id"} component={wrapperHeader(WrappedShoppingCartItemDetailComponent , "ShoppingCartItem Detail")} />
                      <Route path={ClientRoutes.ShoppingCartItems} component={wrapperHeader(WrappedShoppingCartItemSearchComponent, "ShoppingCartItem Search")} />
					<Route path={ClientRoutes.SpecialOffers + "/create"} component={wrapperHeader(WrappedSpecialOfferCreateComponent, "SpecialOffer Create")} />
                      <Route path={ClientRoutes.SpecialOffers + "/edit/:id"} component={wrapperHeader(WrappedSpecialOfferEditComponent, "SpecialOffer Edit")} />
                      <Route path={ClientRoutes.SpecialOffers + "/:id"} component={wrapperHeader(WrappedSpecialOfferDetailComponent , "SpecialOffer Detail")} />
                      <Route path={ClientRoutes.SpecialOffers} component={wrapperHeader(WrappedSpecialOfferSearchComponent, "SpecialOffer Search")} />
					<Route path={ClientRoutes.Stores + "/create"} component={wrapperHeader(WrappedStoreCreateComponent, "Store Create")} />
                      <Route path={ClientRoutes.Stores + "/edit/:id"} component={wrapperHeader(WrappedStoreEditComponent, "Store Edit")} />
                      <Route path={ClientRoutes.Stores + "/:id"} component={wrapperHeader(WrappedStoreDetailComponent , "Store Detail")} />
                      <Route path={ClientRoutes.Stores} component={wrapperHeader(WrappedStoreSearchComponent, "Store Search")} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>1149ef4aeb3a337c1a191ec28ea99bd1</Hash>
</Codenesium>*/