import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTerritoryMapper from './salesTerritoryMapper';
import SalesTerritoryViewModel from './salesTerritoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
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
      .get<Api.SalesTerritoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesTerritories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesTerritoryMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
              <h3>Cost Last Year</h3>
              <p>{String(this.state.model!.costLastYear)}</p>
            </div>
            <div>
              <h3>Cost Y T D</h3>
              <p>{String(this.state.model!.costYTD)}</p>
            </div>
            <div>
              <h3>Country Region Code</h3>
              <p>{String(this.state.model!.countryRegionCode)}</p>
            </div>
            <div>
              <h3>Group</h3>
              <p>{String(this.state.model!.reservedGroup)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Sales Last Year</h3>
              <p>{String(this.state.model!.salesLastYear)}</p>
            </div>
            <div>
              <h3>Sales Y T D</h3>
              <p>{String(this.state.model!.salesYTD)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Customers</h3>
            <CustomerTableComponent
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
    <Hash>63ffed346c40ae140a0fa569a5a19e94</Hash>
</Codenesium>*/