import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTerritoryMapper from './salesTerritoryMapper';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { CustomerTableComponent } from '../shared/customerTable';
import { SalesOrderHeaderTableComponent } from '../shared/salesOrderHeaderTable';
import { SalesPersonTableComponent } from '../shared/salesPersonTable';
import { SalesTerritoryHistoryTableComponent } from '../shared/salesTerritoryHistoryTable';

interface SalesTerritoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesTerritoryDetailComponentState {
  model?: SalesTerritoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SalesTerritoryDetailComponent extends React.Component<
  SalesTerritoryDetailComponentProps,
  SalesTerritoryDetailComponentState
> {
  state = {
    model: new SalesTerritoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SalesTerritories + '/edit/' + this.state.model!.territoryID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTerritories +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesTerritoryClientResponseModel;

          console.log(response);

          let mapper = new SalesTerritoryMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>CostLastYear</h3>
              <p>{String(this.state.model!.costLastYear)}</p>
            </div>
            <div>
              <h3>CostYTD</h3>
              <p>{String(this.state.model!.costYTD)}</p>
            </div>
            <div>
              <h3>CountryRegionCode</h3>
              <p>{String(this.state.model!.countryRegionCode)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>SalesLastYear</h3>
              <p>{String(this.state.model!.salesLastYear)}</p>
            </div>
            <div>
              <h3>SalesYTD</h3>
              <p>{String(this.state.model!.salesYTD)}</p>
            </div>
            <div>
              <h3>TerritoryID</h3>
              <p>{String(this.state.model!.territoryID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Customers</h3>
            <CustomerTableComponent
              customerID={this.state.model!.customerID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesTerritories +
                '/' +
                this.state.model!.territoryID +
                '/' +
                ApiRoutes.Customers
              }
            />
          </div>
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
              salesOrderID={this.state.model!.salesOrderID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesTerritories +
                '/' +
                this.state.model!.territoryID +
                '/' +
                ApiRoutes.SalesOrderHeaders
              }
            />
          </div>
          <div>
            <h3>SalesPersons</h3>
            <SalesPersonTableComponent
              businessEntityID={this.state.model!.businessEntityID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesTerritories +
                '/' +
                this.state.model!.territoryID +
                '/' +
                ApiRoutes.SalesPersons
              }
            />
          </div>
          <div>
            <h3>SalesTerritoryHistories</h3>
            <SalesTerritoryHistoryTableComponent
              businessEntityID={this.state.model!.businessEntityID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesTerritories +
                '/' +
                this.state.model!.territoryID +
                '/' +
                ApiRoutes.SalesTerritoryHistories
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedSalesTerritoryDetailComponent = Form.create({
  name: 'SalesTerritory Detail',
})(SalesTerritoryDetailComponent);


/*<Codenesium>
    <Hash>c9fb111f5b051d494e157d3f85c60140</Hash>
</Codenesium>*/