import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { SalesOrderHeaderTableComponent } from '../shared/salesOrderHeaderTable';
import { SalesPersonQuotaHistoryTableComponent } from '../shared/salesPersonQuotaHistoryTable';
import { SalesTerritoryHistoryTableComponent } from '../shared/salesTerritoryHistoryTable';
import { StoreTableComponent } from '../shared/storeTable';

interface SalesPersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SalesPersonDetailComponentState {
  model?: SalesPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SalesPersonDetailComponent extends React.Component<
  SalesPersonDetailComponentProps,
  SalesPersonDetailComponentState
> {
  state = {
    model: new SalesPersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SalesPersons + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.SalesPersonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new SalesPersonMapper();

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
              <h3>Bonus</h3>
              <p>{String(this.state.model!.bonus)}</p>
            </div>
            <div>
              <h3>Commission Pct</h3>
              <p>{String(this.state.model!.commissionPct)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
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
              <h3>Sales Quota</h3>
              <p>{String(this.state.model!.salesQuota)}</p>
            </div>
            <div>
              <h3>Sales Y T D</h3>
              <p>{String(this.state.model!.salesYTD)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Territory I D</h3>
              <p>
                {String(
                  this.state.model!.territoryIDNavigation &&
                    this.state.model!.territoryIDNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>SalesOrderHeaders</h3>
            <SalesOrderHeaderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesPersons +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.SalesOrderHeaders
              }
            />
          </div>
          <div>
            <h3>SalesPersonQuotaHistories</h3>
            <SalesPersonQuotaHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesPersons +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.SalesPersonQuotaHistories
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
                ApiRoutes.SalesPersons +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.SalesTerritoryHistories
              }
            />
          </div>
          <div>
            <h3>Stores</h3>
            <StoreTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.SalesPersons +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.Stores
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

export const WrappedSalesPersonDetailComponent = Form.create({
  name: 'SalesPerson Detail',
})(SalesPersonDetailComponent);


/*<Codenesium>
    <Hash>f3d15bbae50a84981dfdeb8b7c51375f</Hash>
</Codenesium>*/