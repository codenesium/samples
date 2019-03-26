import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressTypeMapper from './addressTypeMapper';
import AddressTypeViewModel from './addressTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BusinessEntityAddressTableComponent } from '../shared/businessEntityAddressTable';

interface AddressTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AddressTypeDetailComponentState {
  model?: AddressTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AddressTypeDetailComponent extends React.Component<
  AddressTypeDetailComponentProps,
  AddressTypeDetailComponentState
> {
  state = {
    model: new AddressTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.AddressTypes + '/edit/' + this.state.model!.addressTypeID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.AddressTypeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.AddressTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AddressTypeMapper();

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
          </div>
          {message}
          <div>
            <h3>BusinessEntityAddresses</h3>
            <BusinessEntityAddressTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.AddressTypes +
                '/' +
                this.state.model!.addressTypeID +
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

export const WrappedAddressTypeDetailComponent = Form.create({
  name: 'AddressType Detail',
})(AddressTypeDetailComponent);


/*<Codenesium>
    <Hash>5e4bbddfeff7831492363a02114d435e</Hash>
</Codenesium>*/