import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesPersonMapper from './salesPersonMapper';
import SalesPersonViewModel from './salesPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SalesPersons +
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
          let response = resp.data as Api.SalesPersonClientResponseModel;

          console.log(response);

          let mapper = new SalesPersonMapper();

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
            loaded: false,
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
              <h3>Bonus</h3>
              <p>{String(this.state.model!.bonus)}</p>
            </div>
            <div>
              <h3>BusinessEntityID</h3>
              <p>{String(this.state.model!.businessEntityID)}</p>
            </div>
            <div>
              <h3>CommissionPct</h3>
              <p>{String(this.state.model!.commissionPct)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
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
              <h3>SalesQuota</h3>
              <p>{String(this.state.model!.salesQuota)}</p>
            </div>
            <div>
              <h3>SalesYTD</h3>
              <p>{String(this.state.model!.salesYTD)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>TerritoryID</h3>
              <p>
                {String(this.state.model!.territoryIDNavigation!.toDisplay())}
              </p>
            </div>
          </div>
          {message}
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
    <Hash>f08f161dd204e09019c66312835847f8</Hash>
</Codenesium>*/