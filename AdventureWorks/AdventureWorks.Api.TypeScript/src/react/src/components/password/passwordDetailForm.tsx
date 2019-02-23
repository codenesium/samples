import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PasswordMapper from './passwordMapper';
import PasswordViewModel from './passwordViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PasswordDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PasswordDetailComponentState {
  model?: PasswordViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PasswordDetailComponent extends React.Component<
  PasswordDetailComponentProps,
  PasswordDetailComponentState
> {
  state = {
    model: new PasswordViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Passwords + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Passwords +
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
          let response = resp.data as Api.PasswordClientResponseModel;

          console.log(response);

          let mapper = new PasswordMapper();

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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>PasswordHash</h3>
              <p>{String(this.state.model!.passwordHash)}</p>
            </div>
            <div>
              <h3>PasswordSalt</h3>
              <p>{String(this.state.model!.passwordSalt)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
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

export const WrappedPasswordDetailComponent = Form.create({
  name: 'Password Detail',
})(PasswordDetailComponent);


/*<Codenesium>
    <Hash>1efe7308ab1b73639be1eb3948fafc4a</Hash>
</Codenesium>*/