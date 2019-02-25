import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StoreMapper from './storeMapper';
import StoreViewModel from './storeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { CustomerTableComponent } from '../shared/customerTable';

interface StoreDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StoreDetailComponentState {
  model?: StoreViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class StoreDetailComponent extends React.Component<
  StoreDetailComponentProps,
  StoreDetailComponentState
> {
  state = {
    model: new StoreViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Stores + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Stores +
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
          let response = resp.data as Api.StoreClientResponseModel;

          console.log(response);

          let mapper = new StoreMapper();

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
              <h3>BusinessEntityID</h3>
              <p>{String(this.state.model!.businessEntityID)}</p>
            </div>
            <div>
              <h3>Demographics</h3>
              <p>{String(this.state.model!.demographic)}</p>
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
            <div style={{ marginBottom: '10px' }}>
              <h3>SalesPersonID</h3>
              <p>
                {String(this.state.model!.salesPersonIDNavigation!.toDisplay())}
              </p>
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
                ApiRoutes.Stores +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.Customers
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

export const WrappedStoreDetailComponent = Form.create({
  name: 'Store Detail',
})(StoreDetailComponent);


/*<Codenesium>
    <Hash>1b325bf55c7791c6084db6e3dd2f020a</Hash>
</Codenesium>*/