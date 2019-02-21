import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PhoneNumberTypeMapper from './phoneNumberTypeMapper';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PhoneNumberTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PhoneNumberTypeDetailComponentState {
  model?: PhoneNumberTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PhoneNumberTypeDetailComponent extends React.Component<
  PhoneNumberTypeDetailComponentProps,
  PhoneNumberTypeDetailComponentState
> {
  state = {
    model: new PhoneNumberTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PhoneNumberTypes +
        '/edit/' +
        this.state.model!.phoneNumberTypeID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PhoneNumberTypes +
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
          let response = resp.data as Api.PhoneNumberTypeClientResponseModel;

          console.log(response);

          let mapper = new PhoneNumberTypeMapper();

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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>PhoneNumberTypeID</h3>
              <p>{String(this.state.model!.phoneNumberTypeID)}</p>
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

export const WrappedPhoneNumberTypeDetailComponent = Form.create({
  name: 'PhoneNumberType Detail',
})(PhoneNumberTypeDetailComponent);


/*<Codenesium>
    <Hash>32b1fc23196a787469c6fc33c64191be</Hash>
</Codenesium>*/