import * as React from 'react';
import { Link } from 'react-router-dom';

interface Props {}

interface State {
  menuExpanded: boolean;
}

export class Header extends React.Component<Props, State> {
  state = { menuExpanded: false };

  handleClick(e: React.FormEvent) {
    this.setState({ menuExpanded: !this.state.menuExpanded });
  }

  render() {
    return (
      <div className="row col-12">
        <nav
          className="navbar navbar-expand-lg navbar-light bg-white"
          id="navbar"
        >
          <a className="navbar-brand" href="#">
            AdventureWorks
          </a>

          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
            onClick={e => this.handleClick(e)}
          >
            <span className="navbar-toggler-icon" />
          </button>

          <div
            className={
              this.state.menuExpanded
                ? 'collapse.expand navbar-collapse'
                : 'collapse navbar-collapse'
            }
            id="navbarSupportedContent"
          >
            <ul className="navbar-nav mr-auto">
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/awbuildversions"
                  onClick={e => this.handleClick(e)}
                >
                  AWBuildVersions
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/databaselogs"
                  onClick={e => this.handleClick(e)}
                >
                  DatabaseLogs
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/errorlogs"
                  onClick={e => this.handleClick(e)}
                >
                  ErrorLogs
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/departments"
                  onClick={e => this.handleClick(e)}
                >
                  Departments
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/employees"
                  onClick={e => this.handleClick(e)}
                >
                  Employees
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/jobcandidates"
                  onClick={e => this.handleClick(e)}
                >
                  JobCandidates
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/shifts"
                  onClick={e => this.handleClick(e)}
                >
                  Shifts
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/addresses"
                  onClick={e => this.handleClick(e)}
                >
                  Addresses
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/addresstypes"
                  onClick={e => this.handleClick(e)}
                >
                  AddressTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/businessentities"
                  onClick={e => this.handleClick(e)}
                >
                  BusinessEntities
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/contacttypes"
                  onClick={e => this.handleClick(e)}
                >
                  ContactTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/countryregions"
                  onClick={e => this.handleClick(e)}
                >
                  CountryRegions
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/passwords"
                  onClick={e => this.handleClick(e)}
                >
                  Passwords
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/people"
                  onClick={e => this.handleClick(e)}
                >
                  People
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/phonenumbertypes"
                  onClick={e => this.handleClick(e)}
                >
                  PhoneNumberTypes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/stateprovinces"
                  onClick={e => this.handleClick(e)}
                >
                  StateProvinces
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/billofmaterials"
                  onClick={e => this.handleClick(e)}
                >
                  BillOfMaterials
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/cultures"
                  onClick={e => this.handleClick(e)}
                >
                  Cultures
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/documents"
                  onClick={e => this.handleClick(e)}
                >
                  Documents
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/illustrations"
                  onClick={e => this.handleClick(e)}
                >
                  Illustrations
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/locations"
                  onClick={e => this.handleClick(e)}
                >
                  Locations
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/products"
                  onClick={e => this.handleClick(e)}
                >
                  Products
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productcategories"
                  onClick={e => this.handleClick(e)}
                >
                  ProductCategories
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productdescriptions"
                  onClick={e => this.handleClick(e)}
                >
                  ProductDescriptions
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productmodels"
                  onClick={e => this.handleClick(e)}
                >
                  ProductModels
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productphotoes"
                  onClick={e => this.handleClick(e)}
                >
                  ProductPhotoes
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productreviews"
                  onClick={e => this.handleClick(e)}
                >
                  ProductReviews
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/productsubcategories"
                  onClick={e => this.handleClick(e)}
                >
                  ProductSubcategories
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/scrapreasons"
                  onClick={e => this.handleClick(e)}
                >
                  ScrapReasons
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/transactionhistories"
                  onClick={e => this.handleClick(e)}
                >
                  TransactionHistories
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/transactionhistoryarchives"
                  onClick={e => this.handleClick(e)}
                >
                  TransactionHistoryArchives
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/unitmeasures"
                  onClick={e => this.handleClick(e)}
                >
                  UnitMeasures
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/workorders"
                  onClick={e => this.handleClick(e)}
                >
                  WorkOrders
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/purchaseorderheaders"
                  onClick={e => this.handleClick(e)}
                >
                  PurchaseOrderHeaders
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/shipmethods"
                  onClick={e => this.handleClick(e)}
                >
                  ShipMethods
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/vendors"
                  onClick={e => this.handleClick(e)}
                >
                  Vendors
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/creditcards"
                  onClick={e => this.handleClick(e)}
                >
                  CreditCards
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/currencies"
                  onClick={e => this.handleClick(e)}
                >
                  Currencies
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/currencyrates"
                  onClick={e => this.handleClick(e)}
                >
                  CurrencyRates
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/customers"
                  onClick={e => this.handleClick(e)}
                >
                  Customers
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/salesorderheaders"
                  onClick={e => this.handleClick(e)}
                >
                  SalesOrderHeaders
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/salespersons"
                  onClick={e => this.handleClick(e)}
                >
                  SalesPersons
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/salesreasons"
                  onClick={e => this.handleClick(e)}
                >
                  SalesReasons
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/salestaxrates"
                  onClick={e => this.handleClick(e)}
                >
                  SalesTaxRates
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/salesterritories"
                  onClick={e => this.handleClick(e)}
                >
                  SalesTerritories
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/shoppingcartitems"
                  onClick={e => this.handleClick(e)}
                >
                  ShoppingCartItems
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/specialoffers"
                  onClick={e => this.handleClick(e)}
                >
                  SpecialOffers
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  className="nav-link"
                  to="/stores"
                  onClick={e => this.handleClick(e)}
                >
                  Stores
                </Link>
              </li>
            </ul>
          </div>
        </nav>
      </div>
    );
  }
}


/*<Codenesium>
    <Hash>efe676fa5b47e1aa86c0872ab0e19189</Hash>
</Codenesium>*/