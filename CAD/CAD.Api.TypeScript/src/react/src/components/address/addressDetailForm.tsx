import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { CallTableComponent } from '../shared/callTable';

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
      ClientRoutes.Addresses + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Addresses +
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
          let response = resp.data as Api.AddressClientResponseModel;

          console.log(response);

          let mapper = new AddressMapper();

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
              <h3>address1</h3>
              <p>{String(this.state.model!.address1)}</p>
            </div>
            <div>
              <h3>address2</h3>
              <p>{String(this.state.model!.address2)}</p>
            </div>
            <div>
              <h3>city</h3>
              <p>{String(this.state.model!.city)}</p>
            </div>
            <div>
              <h3>state</h3>
              <p>{String(this.state.model!.state)}</p>
            </div>
            <div>
              <h3>zip</h3>
              <p>{String(this.state.model!.zip)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Calls</h3>
            <CallTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Addresses +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Calls
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
    <Hash>74bc4738be27dda312b8ce5281173cec</Hash>
</Codenesium>*/