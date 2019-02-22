import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ErrorLogDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ErrorLogDetailComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ErrorLogDetailComponent extends React.Component<
  ErrorLogDetailComponentProps,
  ErrorLogDetailComponentState
> {
  state = {
    model: new ErrorLogViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ErrorLogs + '/edit/' + this.state.model!.errorLogID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ErrorLogs +
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
          let response = resp.data as Api.ErrorLogClientResponseModel;

          console.log(response);

          let mapper = new ErrorLogMapper();

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
              <h3>ErrorLine</h3>
              <p>{String(this.state.model!.errorLine)}</p>
            </div>
            <div>
              <h3>ErrorLogID</h3>
              <p>{String(this.state.model!.errorLogID)}</p>
            </div>
            <div>
              <h3>ErrorMessage</h3>
              <p>{String(this.state.model!.errorMessage)}</p>
            </div>
            <div>
              <h3>ErrorNumber</h3>
              <p>{String(this.state.model!.errorNumber)}</p>
            </div>
            <div>
              <h3>ErrorProcedure</h3>
              <p>{String(this.state.model!.errorProcedure)}</p>
            </div>
            <div>
              <h3>ErrorSeverity</h3>
              <p>{String(this.state.model!.errorSeverity)}</p>
            </div>
            <div>
              <h3>ErrorState</h3>
              <p>{String(this.state.model!.errorState)}</p>
            </div>
            <div>
              <h3>ErrorTime</h3>
              <p>{String(this.state.model!.errorTime)}</p>
            </div>
            <div>
              <h3>UserName</h3>
              <p>{String(this.state.model!.userName)}</p>
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

export const WrappedErrorLogDetailComponent = Form.create({
  name: 'ErrorLog Detail',
})(ErrorLogDetailComponent);


/*<Codenesium>
    <Hash>7e30608b30cf359d04829e544ea5276a</Hash>
</Codenesium>*/