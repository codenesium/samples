import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CustomerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CustomerDetailComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CustomerDetailComponent extends React.Component<
  CustomerDetailComponentProps,
  CustomerDetailComponentState
> {
  state = {
    model: new CustomerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Customers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CustomerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Customers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CustomerMapper();

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
              <h3>Email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>First Name</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>Last Name</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>Phone</h3>
              <p>{String(this.state.model!.phone)}</p>
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

export const WrappedCustomerDetailComponent = Form.create({
  name: 'Customer Detail',
})(CustomerDetailComponent);


/*<Codenesium>
    <Hash>39b7e9f2482333b00946759a3c3a63be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/