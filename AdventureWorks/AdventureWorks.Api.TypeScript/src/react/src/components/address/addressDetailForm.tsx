import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BusinessEntityAddressTableComponent } from '../shared/businessEntityAddressTable';

interface AddressDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AddressDetailComponentState {
  model?: AddressViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AddressDetailComponent extends React.Component<
  AddressDetailComponentProps,
  AddressDetailComponentState
> {
  state = {
    model: new AddressViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Addresses + '/edit/' + this.state.model!.addressID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.AddressClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Addresses +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AddressMapper();

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
              <h3>Address Line1</h3>
              <p>{String(this.state.model!.addressLine1)}</p>
            </div>
            <div>
              <h3>Address Line2</h3>
              <p>{String(this.state.model!.addressLine2)}</p>
            </div>
            <div>
              <h3>City</h3>
              <p>{String(this.state.model!.city)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Postal Code</h3>
              <p>{String(this.state.model!.postalCode)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>State Province I D</h3>
              <p>
                {String(
                  this.state.model!.stateProvinceIDNavigation &&
                    this.state.model!.stateProvinceIDNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>BusinessEntityAddresses</h3>
            <BusinessEntityAddressTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Addresses +
                '/' +
                this.state.model!.addressID +
                '/' +
                ApiRoutes.BusinessEntityAddresses
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

export const WrappedAddressDetailComponent = Form.create({
  name: 'Address Detail',
})(AddressDetailComponent);


/*<Codenesium>
    <Hash>46cdf6e5d06b6b6d77db5b86023a1e91</Hash>
</Codenesium>*/